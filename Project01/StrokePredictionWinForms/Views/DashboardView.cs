using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StrokePredictionWinForms.Views
{
    public partial class DashboardView : UserControl
    {
        private readonly ApiClient _api;

        public DashboardView()
        {
            InitializeComponent();
        }

        public DashboardView(ApiClient api) : this()
        {
            _api = api;
            if (this.DesignMode) return;

            SetupUI();
            btnRefresh.Click += (s, e) => LoadDashboardData();
            btnExportCsv.Click += BtnExportCsv_Click;
            LoadDashboardData();
        }

        // ═══════════════════════════════════════════════════════
        // SETUP UI — Cấu hình giao diện khởi tạo
        // ═══════════════════════════════════════════════════════
        private void SetupUI()
        {
            // DataGridView — Dark mode styling + đúng cột yêu cầu
            dgvRecent.EnableHeadersVisualStyles = false;
            dgvRecent.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(17, 24, 39);
            dgvRecent.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRecent.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvRecent.DefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvRecent.DefaultCellStyle.ForeColor = Color.White;
            dgvRecent.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 65, 85);
            dgvRecent.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvRecent.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(24, 34, 50);
            dgvRecent.GridColor = Color.FromArgb(51, 65, 85);
            dgvRecent.RowHeadersVisible = false;
            dgvRecent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecent.ReadOnly = true;
            dgvRecent.AllowUserToAddRows = false;
            dgvRecent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Đặt ngày mặc định
            dtpStart.Value = DateTime.Now.AddMonths(-1);
            dtpEnd.Value = DateTime.Now;
        }

        // ═══════════════════════════════════════════════════════
        // LOAD DATA — Nạp toàn bộ dữ liệu Dashboard
        // ═══════════════════════════════════════════════════════
        private int _totalScans = 0, _strokeDetected = 0, _normalCount = 0;
        private double _strokeRate = 0;

        private async void LoadDashboardData()
        {
            btnRefresh.Enabled = false;
            btnRefresh.Text = "⏳ Đang tải...";

            try
            {
                string json = await _api.GetDashboardStatsAsync();
                var data = System.Text.Json.JsonSerializer.Deserialize<System.Text.Json.JsonElement>(json);

                _totalScans = data.GetProperty("totalScans").GetInt32();
                _strokeDetected = data.GetProperty("strokeDetected").GetInt32();
                _normalCount = data.GetProperty("normal").GetInt32();
                _strokeRate = data.GetProperty("spamRate").GetDouble();
            }
            catch
            {
                // Fallback: dữ liệu mẫu nếu API chưa khả dụng
                _totalScans = 0; _strokeDetected = 0; _normalCount = 0; _strokeRate = 0;
            }

            RenderKPIs();
            RenderDistribution();
            RenderConfidenceBars();
            await LoadRecentScans();

            btnRefresh.Enabled = true;
            btnRefresh.Text = "🔄 Làm mới";
        }

        private void RenderKPIs()
        {
            lblKpiTotalVal.Text = _totalScans.ToString("N0");
            lblKpiStrokeVal.Text = _strokeDetected.ToString("N0");
            lblKpiNormalVal.Text = _normalCount.ToString("N0");
            lblKpiRateVal.Text = $"{_strokeRate * 100:F1}%";
        }

        private void RenderDistribution()
        {
            int strokeCount = _strokeDetected;
            int normalCount = _normalCount;
            int total = strokeCount + normalCount;
            double strokePct = total > 0 ? (double)strokeCount / total * 100 : 0;
            double normalPct = total > 0 ? (double)normalCount / total * 100 : 0;

            lblDistStrokePercent.Text = $"{strokePct:F1} %";
            lblDistNormalPercent.Text = $"{normalPct:F1} %";
        }

        private void RenderConfidenceBars()
        {
            string[] ranges = { "0–20%", "20–40%", "40–60%", "60–80%", "80–100%" };
            int[] values = { 10, 45, 120, 350, 715 }; // Dữ liệu mẫu
            int maxVal = 800;

            lblConfVal1.Text = values[0].ToString(); pnlConfFill1.Width = maxVal > 0 ? (values[0] * 220) / maxVal : 0;
            lblConfVal2.Text = values[1].ToString(); pnlConfFill2.Width = maxVal > 0 ? (values[1] * 220) / maxVal : 0;
            lblConfVal3.Text = values[2].ToString(); pnlConfFill3.Width = maxVal > 0 ? (values[2] * 220) / maxVal : 0;
            lblConfVal4.Text = values[3].ToString(); pnlConfFill4.Width = maxVal > 0 ? (values[3] * 220) / maxVal : 0;
            lblConfVal5.Text = values[4].ToString(); pnlConfFill5.Width = maxVal > 0 ? (values[4] * 220) / maxVal : 0;
        }

        // ═══════════════════════════════════════════════════════
        // PANEL 5 (RIGHT): DataGridView — Top 50 bản ghi
        // Cột: Mã, Tên, Glucose, BMI, Tuổi, Kết quả, Thời gian quét
        // ═══════════════════════════════════════════════════════
        private async Task LoadRecentScans()
        {
            try
            {
                string json = await _api.GetHistoryAsync(1, 50);
                var data = System.Text.Json.JsonSerializer.Deserialize<System.Text.Json.JsonElement>(json);
                var records = data.GetProperty("records");

                var list = new List<object>();
                foreach (var r in records.EnumerateArray())
                {
                    list.Add(new
                    {
                        Ma = r.TryGetProperty("patientCode", out var pc) ? pc.GetString() ?? "—" : "—",
                        Ten = r.TryGetProperty("fullName", out var fn) ? fn.GetString() ?? "—" : "—",
                        Glucose = "—",
                        BMI = "—",
                        Tuoi = r.TryGetProperty("age", out var ag) ? ag.GetDouble().ToString("F0") : "—",
                        KetQua = r.TryGetProperty("prediction", out var pr) ? (pr.GetInt32() == 1 ? "Nguy cơ cao" : "Bình thường") : "—",
                        ThoiGian = r.TryGetProperty("createdAt", out var ca) ? ca.GetDateTime().ToString("HH:mm dd/MM") : "—"
                    });
                }

                dgvRecent.DataSource = list.Count > 0 ? list : null;
            }
            catch
            {
                // Fallback: dữ liệu mẫu
                var data = new List<object>
                {
                    new { Ma = "—", Ten = "Chưa có dữ liệu", Glucose = "—", BMI = "—", Tuoi = "—", KetQua = "—", ThoiGian = "—" },
                };
                dgvRecent.DataSource = data;
            }

            if (dgvRecent.Columns.Count > 0)
            {
                dgvRecent.Columns["Ma"].HeaderText = "Mã";
                dgvRecent.Columns["Ten"].HeaderText = "Tên";
                dgvRecent.Columns["Glucose"].HeaderText = "Glucose";
                dgvRecent.Columns["BMI"].HeaderText = "BMI";
                dgvRecent.Columns["Tuoi"].HeaderText = "Tuổi";
                dgvRecent.Columns["KetQua"].HeaderText = "Kết quả";
                dgvRecent.Columns["ThoiGian"].HeaderText = "Thời gian quét";

                dgvRecent.Columns["Ma"].Width = 60;
                dgvRecent.Columns["Glucose"].Width = 75;
                dgvRecent.Columns["BMI"].Width = 55;
                dgvRecent.Columns["Tuoi"].Width = 50;
            }

            dgvRecent.CellFormatting -= DgvRecent_CellFormatting;
            dgvRecent.CellFormatting += DgvRecent_CellFormatting;
        }

        /// <summary>Tô màu cột "Kết quả" theo mức nguy cơ.</summary>
        private void DgvRecent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRecent.Columns[e.ColumnIndex].Name == "KetQua" && e.Value != null)
            {
                string val = e.Value.ToString();
                if (val.Contains("cao"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(239, 68, 68);  // Red
                    e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
                else if (val.Contains("thường"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(34, 197, 94); // Green
                }
                else if (val.Contains("thấp"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(245, 158, 11); // Orange
                }
            }
        }

        // ═══════════════════════════════════════════════════════
        // EXPORT CSV — Xuất dữ liệu ra file CSV
        // ═══════════════════════════════════════════════════════
        private void BtnExportCsv_Click(object sender, EventArgs e)
        {
            if (dgvRecent.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.FileName = $"BaoCaoThongKe_{DateTime.Now:yyyyMMdd_HHmm}";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();

                        // Header row
                        for (int i = 0; i < dgvRecent.Columns.Count; i++)
                        {
                            sb.Append(dgvRecent.Columns[i].HeaderText);
                            if (i < dgvRecent.Columns.Count - 1) sb.Append(",");
                        }
                        sb.AppendLine();

                        // Data rows
                        foreach (DataGridViewRow row in dgvRecent.Rows)
                        {
                            for (int i = 0; i < dgvRecent.Columns.Count; i++)
                            {
                                sb.Append(row.Cells[i].Value?.ToString() ?? "");
                                if (i < dgvRecent.Columns.Count - 1) sb.Append(",");
                            }
                            sb.AppendLine();
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show($"Đã xuất thành công!\n📁 {sfd.FileName}", "Xuất CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất CSV: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
