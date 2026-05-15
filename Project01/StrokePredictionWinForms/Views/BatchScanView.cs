using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrokePredictionWinForms.Views
{
    public partial class BatchScanView : UserControl
    {
        private readonly ApiClient _api;
        private CancellationTokenSource _cts;
        private string _csvPath = "";
        private List<string[]> _csvRows = new();
        private string[] _csvHeaders = Array.Empty<string>();

        public BatchScanView() { InitializeComponent(); }

        // Thống kê
        private int _totalRecords = 0;
        private int _strokeDetected = 0;
        private int _normalDetected = 0;
        private int _errorCount = 0;

        public BatchScanView(ApiClient api) : this()
        {
            _api = api;
            if (DesignMode) return;
            
            SetupModernDesign();
            SetupEvents();
        }

        private void SetupModernDesign()
        {
            this.BackColor = Color.FromArgb(15, 23, 42); 
            
            var hdr = dgvResults.ColumnHeadersDefaultCellStyle;
            hdr.BackColor = Color.FromArgb(30, 41, 59);
            hdr.ForeColor = Color.White;
            hdr.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvResults.EnableHeadersVisualStyles = false;
            dgvResults.BorderStyle = BorderStyle.None;
            dgvResults.BackgroundColor = Color.FromArgb(15, 23, 42);
            dgvResults.DefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvResults.DefaultCellStyle.ForeColor = Color.Gainsboro;
            dgvResults.DefaultCellStyle.SelectionBackColor = Color.FromArgb(59, 130, 246);
            dgvResults.GridColor = Color.FromArgb(51, 65, 85);
            dgvResults.RowTemplate.Height = 35;
        }

        private void SetupEvents()
        {
            btnBrowse.Click += BtnBrowse_Click;
            btnStartScan.Click += BtnStartScan_Click;
            btnStopScan.Click += BtnStopScan_Click;
            btnExportResults.Click += BtnExportResults_Click;
            btnClearAll.Click += BtnClearAll_Click;
            
            pnlDropZone.AllowDrop = true;
            pnlDropZone.DragEnter += (s, e) => { if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy; };
            pnlDropZone.DragDrop += (s, e) => {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0 && files[0].EndsWith(".csv", StringComparison.OrdinalIgnoreCase)) LoadCsvFile(files[0]);
            };

            btnStopScan.Enabled = false;
        }

        // ═══════════════════════════════════════════
        // CSV LOADING
        // ═══════════════════════════════════════════
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog { Filter = "CSV files|*.csv" };
            if (ofd.ShowDialog() == DialogResult.OK)
                LoadCsvFile(ofd.FileName);
        }

        private void LoadCsvFile(string path)
        {
            try
            {
                var lines = File.ReadAllLines(path, Encoding.UTF8);
                if (lines.Length < 2) { MessageBox.Show("File rỗng hoặc không hợp lệ."); return; }
                if (lines.Length > 10001) { MessageBox.Show("File vượt quá 10,000 dòng."); return; }

                _csvPath = path;
                _csvHeaders = ParseCsvLine(lines[0]);
                _csvRows = lines.Skip(1).Where(l => !string.IsNullOrWhiteSpace(l))
                                .Select(l => ParseCsvLine(l)).ToList();

                lblFileInfo.Text = $"📄 {Path.GetFileName(path)} — {_csvRows.Count:N0} bản ghi";
                lblFileInfo.ForeColor = Color.White;
                lblDropTitle.Text = $"✅ Đã tải: {Path.GetFileName(path)}";
                lblDropTitle.ForeColor = Color.FromArgb(16, 185, 129);

                // Build grid columns
                dgvResults.Columns.Clear();
                dgvResults.Rows.Clear();
                foreach (var h in _csvHeaders)
                    dgvResults.Columns.Add(h.Trim(), h.Trim());
                dgvResults.Columns.Add("Kết quả", "Kết quả");
                dgvResults.Columns.Add("Độ tin cậy", "Độ tin cậy");

                // Fill data rows
                foreach (var row in _csvRows)
                {
                    int idx = dgvResults.Rows.Add();
                    for (int c = 0; c < row.Length && c < _csvHeaders.Length; c++)
                        dgvResults.Rows[idx].Cells[c].Value = row[c].Trim();
                    dgvResults.Rows[idx].Cells["Kết quả"].Value = "—";
                    dgvResults.Rows[idx].Cells["Độ tin cậy"].Value = "—";
                }

                UpdateStats(0, 0);
                lblStatTotalVal.Text = _csvRows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đọc file: {ex.Message}");
            }
        }

        /// <summary>
        /// Parse một dòng CSV có hỗ trợ quoted fields (e.g. "value, with comma").
        /// </summary>
        private static string[] ParseCsvLine(string line)
        {
            var fields = new List<string>();
            bool inQuote = false;
            var current = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (c == '"')
                {
                    if (inQuote && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        current.Append('"'); // escaped quote
                        i++;
                    }
                    else
                    {
                        inQuote = !inQuote;
                    }
                }
                else if (c == ',' && !inQuote)
                {
                    fields.Add(current.ToString());
                    current.Clear();
                }
                else
                {
                    current.Append(c);
                }
            }
            fields.Add(current.ToString());
            return fields.ToArray();
        }

        // ═══════════════════════════════════════════
        // SCAN LOGIC
        // ═══════════════════════════════════════════
        private async void BtnStartScan_Click(object sender, EventArgs e)
        {
            if (dgvResults.Rows.Count == 0) { MessageBox.Show("Chưa tải file CSV."); return; }

            _cts = new CancellationTokenSource();
            btnStartScan.Enabled = false;
            btnStopScan.Enabled = true;
            btnBrowse.Enabled = false;
            lblScanStatus.Text = "🔄 ĐANG QUÉT";
            lblScanStatus.ForeColor = Color.FromArgb(245, 158, 11);

            int total = dgvResults.Rows.Count;
            int strokeCount = 0, normalCount = 0;

            for (int i = 0; i < total; i++)
            {
                if (_cts.Token.IsCancellationRequested) break;

                try
                {
                    var row = dgvResults.Rows[i];
                    var payload = BuildRowPayload(row);
                    string json = await _api.PredictAsync(payload);
                    var result = JsonSerializer.Deserialize<JsonElement>(json);

                    int pred = result.GetProperty("prediction").GetInt32();
                    double prob = result.GetProperty("probability").GetDouble();

                    row.Cells["Kết quả"].Value = pred == 1 ? "Đột quỵ" : "Bình thường";
                    row.Cells["Độ tin cậy"].Value = $"{prob * 100:F1}%";

                    if (pred == 1) strokeCount++; else normalCount++;
                }
                catch (Exception ex)
                {
                    dgvResults.Rows[i].Cells["Kết quả"].Value = "Lỗi: " + ex.Message;
                    dgvResults.Rows[i].Cells["Độ tin cậy"].Value = "—";
                    normalCount++;
                }

                int pct = (int)((i + 1) * 100.0 / total);
                progressBar.Value = pct;
                lblScanPct.Text = $"{pct}%";
                lblProgressMsg.Text = $"Đang xử lý... {i + 1}/{total}";
                UpdateStats(strokeCount, normalCount);
            }

            lblScanStatus.Text = _cts.Token.IsCancellationRequested ? "⏹ ĐÃ DỪNG" : "✅ HOÀN TẤT";
            lblScanStatus.ForeColor = _cts.Token.IsCancellationRequested
                ? Color.FromArgb(239, 68, 68) : Color.FromArgb(16, 185, 129);
            lblProgressMsg.Text = _cts.Token.IsCancellationRequested ? "Đã dừng bởi người dùng." : "Quét xong!";

            btnStartScan.Enabled = true;
            btnStopScan.Enabled = false;
            btnBrowse.Enabled = true;
        }

        private void BtnStopScan_Click(object sender, EventArgs e) => _cts?.Cancel();

        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            dgvResults.Columns.Clear();
            dgvResults.Rows.Clear();
            _csvRows.Clear();
            _csvPath = "";
            lblFileInfo.Text = "Chưa tải file — 0 bản ghi";
            lblFileInfo.ForeColor = Color.FromArgb(148, 163, 184);
            lblDropTitle.Text = "Kéo thả file CSV vào đây";
            lblDropTitle.ForeColor = Color.White;
            progressBar.Value = 0;
            lblScanPct.Text = "0%";
            lblScanStatus.Text = "⏸️ CHƯA QUÉT";
            lblScanStatus.ForeColor = Color.FromArgb(148, 163, 184);
            lblProgressMsg.Text = "Sẵn sàng";
            UpdateStats(0, 0);
            lblStatTotalVal.Text = "0";
        }

        private void BtnExportResults_Click(object sender, EventArgs e)
        {
            if (dgvResults.Rows.Count == 0) { MessageBox.Show("Chưa có dữ liệu."); return; }
            using var sfd = new SaveFileDialog { Filter = "CSV file|*.csv", FileName = "KetQuaQuet.csv" };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            var sb = new StringBuilder();
            // Header
            for (int c = 0; c < dgvResults.Columns.Count; c++)
            {
                if (c > 0) sb.Append(',');
                sb.Append(dgvResults.Columns[c].HeaderText);
            }
            sb.AppendLine();
            // Rows
            foreach (DataGridViewRow row in dgvResults.Rows)
            {
                for (int c = 0; c < dgvResults.Columns.Count; c++)
                {
                    if (c > 0) sb.Append(',');
                    sb.Append(row.Cells[c].Value?.ToString() ?? "");
                }
                sb.AppendLine();
            }
            File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));
            MessageBox.Show("✅ Xuất file thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ═══════════════════════════════════════════
        // HELPERS
        // ═══════════════════════════════════════════
        private string GetVal(DataGridViewRow row, string colName)
        {
            // Tìm cột trong DataGridView dựa trên danh sách header đã nạp
            string actualCol = _csvHeaders.FirstOrDefault(h => 
                string.Equals(h.Trim(), colName, StringComparison.OrdinalIgnoreCase) || 
                colName.StartsWith(h.Trim(), StringComparison.OrdinalIgnoreCase) ||
                h.Trim().StartsWith(colName, StringComparison.OrdinalIgnoreCase) ||
                (colName == "smoking_status" && h.Trim().ToLower().Contains("smok")) ||
                (colName == "work_type" && h.Trim().ToLower().Contains("work")) ||
                (colName == "Residence_type" && h.Trim().ToLower().Contains("residen")));

            if (actualCol != null)
            {
                var cell = row.Cells[actualCol];
                if (cell.Value != null)
                {
                    string val = cell.Value.ToString().Trim();
                    
                    // Chuẩn hóa dữ liệu cho Enums (Thay dấu cách, dấu gạch ngang bằng gạch dưới)
                    if (new[] { "gender", "ever_married", "work_type", "Residence_type", "smoking_status" }.Contains(colName))
                    {
                        // Chuyển "never smoked" -> "never_smoked", "Self-employed" -> "Self_employed"
                        return val.Replace(" ", "_").Replace("-", "_");
                    }
                    return val;
                }
            }
            
            // Giá trị mặc định nếu không tìm thấy hoặc dữ liệu trống
            if (colName == "smoking_status") return "Unknown";
            if (colName == "gender") return "Other";
            return "";
        }

        private PatientInput BuildRowPayload(DataGridViewRow row)
        {
            return new PatientInput
            {
                fullName = GetVal(row, "full_name"),
                gender = GetVal(row, "gender"),
                age = double.TryParse(GetVal(row, "age"), out var a) ? a : 0,
                hypertension = GetVal(row, "hypertension") == "1" ? 1 : 0,
                heartDisease = GetVal(row, "heart_disease") == "1" ? 1 : 0,
                everMarried = GetVal(row, "ever_married"),
                workType = GetVal(row, "work_type"),
                residenceType = GetVal(row, "Residence_type"),
                avgGlucoseLevel = double.TryParse(GetVal(row, "avg_glucose_level"), out var g) ? g : 0,
                bmi = double.TryParse(GetVal(row, "bmi"), out var b) ? b : 0,
                smokingStatus = GetVal(row, "smoking_status")
            };
        }

        private void UpdateStats(int stroke, int normal)
        {
            int total = stroke + normal;
            lblStatStrokeVal.Text = stroke.ToString();
            lblStatNormalVal.Text = normal.ToString();
            lblStatRateVal.Text = total > 0 ? $"{stroke * 100.0 / total:F1}%" : "0.0%";
        }

        private void DgvResults_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvResults.Columns[e.ColumnIndex].HeaderText == "Kết quả" && e.Value != null)
            {
                string val = e.Value.ToString();
                if (val == "Đột quỵ")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(239, 68, 68);
                    e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
                else if (val == "Bình thường")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(34, 197, 94);
                    e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
            }
        }
    }
}
