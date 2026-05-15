using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace StrokePredictionWinForms.Views
{
    public partial class HistoryView : UserControl
    {
        private readonly ApiClient _api;

        public HistoryView() { InitializeComponent(); }

        public HistoryView(ApiClient api) : this()
        {
            _api = api;
            if (DesignMode) return;

            // Events
            btnFilter.Click += BtnFilter_Click;
            btnReset.Click += BtnReset_Click;
            btnDeleteSelected.Click += BtnDeleteSelected_Click;
            btnDeleteRecord.Click += BtnDeleteRecord_Click;
            dgvHistory.SelectionChanged += DgvHistory_SelectionChanged;
            dgvHistory.CellFormatting += DgvHistory_CellFormatting;

            LoadHistoryData();
        }

        // ═══════════════════════════════════════════
        // LOAD DATA FROM API
        // ═══════════════════════════════════════════
        private async void LoadHistoryData()
        {
            try
            {
                string json = await _api.GetHistoryAsync(1, 100);
                var data = JsonSerializer.Deserialize<JsonElement>(json);
                var records = data.GetProperty("records");

                dgvHistory.Rows.Clear();
                foreach (var r in records.EnumerateArray())
                {
                    string name = r.TryGetProperty("fullName", out var fn) ? fn.GetString() ?? "—" : "—";
                    int pred = r.TryGetProperty("prediction", out var pr) ? pr.GetInt32() : 0;
                    double prob = r.TryGetProperty("probability", out var pb) ? pb.GetDouble() : 0;
                    string time = r.TryGetProperty("createdAt", out var ca) ? ca.GetDateTime().ToString("HH:mm dd/MM/yyyy") : "—";
                    string id = r.TryGetProperty("id", out var idp) ? idp.GetString() ?? "—" : "—";

                    string resultText = pred == 1 ? "Đột quỵ" : "Bình thường";
                    string confText = $"{prob * 100:F1}%";

                    // Apply search filter
                    string search = txtSearch.Text.Trim().ToLower();
                    if (!string.IsNullOrEmpty(search) && !name.ToLower().Contains(search))
                        continue;

                    // Apply result filter
                    if (cboResult.SelectedIndex == 1 && pred != 1) continue; // Đột quỵ only
                    if (cboResult.SelectedIndex == 2 && pred != 0) continue; // Bình thường only

                    int idx = dgvHistory.Rows.Add();
                    dgvHistory.Rows[idx].Cells["colId"].Value = id;
                    dgvHistory.Rows[idx].Cells["colName"].Value = name;
                    dgvHistory.Rows[idx].Cells["colResult"].Value = resultText;
                    dgvHistory.Rows[idx].Cells["colConfidence"].Value = confText;
                    dgvHistory.Rows[idx].Cells["colTime"].Value = time;

                    // Store extra data in Tag for detail panel
                    dgvHistory.Rows[idx].Tag = r.Clone();
                }

                lblRecordCount.Text = $"{dgvHistory.Rows.Count} bản ghi";
            }
            catch (Exception ex)
            {
                lblRecordCount.Text = "Lỗi tải dữ liệu";
            }
        }

        // ═══════════════════════════════════════════
        // EVENTS
        // ═══════════════════════════════════════════
        private void BtnFilter_Click(object sender, EventArgs e)
        {
            LoadHistoryData();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboResult.SelectedIndex = 0;
            dtpFrom.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = DateTime.Now;
            ResetDetail();
            LoadHistoryData();
        }

        private void BtnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count == 0) return;
            var confirm = MessageBox.Show("Bạn chắc chắn muốn xóa bản ghi đã chọn?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                dgvHistory.Rows.RemoveAt(dgvHistory.SelectedRows[0].Index);
                lblRecordCount.Text = $"{dgvHistory.Rows.Count} bản ghi";
                ResetDetail();
            }
        }

        private void BtnDeleteRecord_Click(object sender, EventArgs e)
        {
            BtnDeleteSelected_Click(sender, e);
        }

        private void DgvHistory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count == 0) { ResetDetail(); return; }

            var row = dgvHistory.SelectedRows[0];
            string result = row.Cells["colResult"].Value?.ToString() ?? "";
            string confidence = row.Cells["colConfidence"].Value?.ToString() ?? "";

            bool isStroke = result.Contains("Đột quỵ", StringComparison.OrdinalIgnoreCase);

            lblDetailResult.Text = isStroke ? "NGUY CƠ ĐỘT QUỴ" : "BÌNH THƯỜNG";
            lblDetailResult.ForeColor = isStroke ? Color.FromArgb(239, 68, 68) : Color.FromArgb(34, 197, 94);
            lblDetailResultIcon.Text = isStroke ? "⚠️" : "✅";
            lblDetailConfidenceVal.Text = confidence;
            lblDetailConfidenceVal.ForeColor = isStroke ? Color.FromArgb(239, 68, 68) : Color.FromArgb(16, 185, 129);
            lblDetailName.Text = row.Cells["colName"].Value?.ToString() ?? "—";
            lblDetailTime.Text = row.Cells["colTime"].Value?.ToString() ?? "—";

            // Try to get extra info from Tag (JsonElement)
            if (row.Tag is JsonElement r)
            {
                lblDetailAge.Text = r.TryGetProperty("age", out var ag) ? ag.GetDouble().ToString("F0") : "—";
            }
        }

        private void DgvHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHistory.Columns[e.ColumnIndex].Name == "colResult" && e.Value != null)
            {
                string v = e.Value.ToString() ?? "";
                if (v.Contains("Đột quỵ"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(239, 68, 68);
                    e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
                else if (v.Contains("Bình thường"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(34, 197, 94);
                    e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
            }
        }

        private void ResetDetail()
        {
            lblDetailResult.Text = "—";
            lblDetailResult.ForeColor = Color.FromArgb(148, 163, 184);
            lblDetailResultIcon.Text = "❓";
            lblDetailConfidenceVal.Text = "--.-- %";
            lblDetailConfidenceVal.ForeColor = Color.FromArgb(16, 185, 129);
            lblDetailName.Text = "—"; lblDetailTime.Text = "—";
            lblDetailAge.Text = "—"; lblDetailGender.Text = "—";
            lblDetailGlucose.Text = "—"; lblDetailBmi.Text = "—";
            lblDetailHyper.Text = "—"; lblDetailHeart.Text = "—";
            lblDetailSmoke.Text = "—";
        }

        private void split_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        // ═══════════════════════════════════════════
        // HELPERS
        // ═══════════════════════════════════════════
    }
}
