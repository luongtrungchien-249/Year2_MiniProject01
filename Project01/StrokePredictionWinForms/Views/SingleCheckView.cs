using System;
using System.Drawing;
using System.Text.Json;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace StrokePredictionWinForms.Views
{
    public partial class SingleCheckView : UserControl
    {
        private readonly ApiClient _api;

        public SingleCheckView() { InitializeComponent(); }

        public SingleCheckView(ApiClient api) : this()
        {
            _api = api;
            if (this.DesignMode) return;

            // Đăng ký sự kiện
            btnAnalyze.Click += BtnAnalyze_Click;
            btnClear.Click += BtnClear_Click;
            btnSave.Click += BtnSave_Click;
        }

        // ═══════════════════════════════════════════════════════
        // SỰ KIỆN: Phân tích
        // ═══════════════════════════════════════════════════════
        private async void BtnAnalyze_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            btnAnalyze.Enabled = false;
            btnAnalyze.Text = "⏳ Đang phân tích...";
            lblRiskPct.Text = "...";
            lblRiskLevel.Text = "Đang xử lý";
            lblRiskLevel.ForeColor = Color.FromArgb(245, 158, 11);

            try
            {
                var payload = BuildPayload();
                string json = await _api.PredictAsync(payload);

                var result = JsonSerializer.Deserialize<JsonElement>(json);
                double probability = result.GetProperty("probability").GetDouble();
                string riskLevel = result.GetProperty("riskLevel").GetString() ?? "N/A";
                int prediction = result.GetProperty("prediction").GetInt32();
                string message = result.GetProperty("message").GetString() ?? "";

                // Hiển thị kết quả
                lblRiskPct.Text = $"{probability * 100:F1}%";

                if (prediction == 1)
                {
                    lblRiskLevel.Text = "⚠️ NGUY CƠ ĐỘT QUỴ";
                    lblRiskPct.ForeColor = Color.FromArgb(239, 68, 68);
                    lblRiskLevel.ForeColor = Color.FromArgb(239, 68, 68);
                    pnlResultBox.BackColor = Color.FromArgb(50, 30, 30);
                    lblRiskMsg.Text = $"Mức nguy cơ: {riskLevel}\nĐộ tin cậy: {probability * 100:F1}%\n\n{message}";
                }
                else
                {
                    lblRiskLevel.Text = "✅ BÌNH THƯỜNG";
                    lblRiskPct.ForeColor = Color.FromArgb(34, 197, 94);
                    lblRiskLevel.ForeColor = Color.FromArgb(34, 197, 94);
                    pnlResultBox.BackColor = Color.FromArgb(20, 40, 30);
                    lblRiskMsg.Text = $"Mức nguy cơ: {riskLevel}\nĐộ tin cậy: {(1 - probability) * 100:F1}%\n\n{message}";
                }
                lblRiskMsg.ForeColor = Color.Gainsboro;

                UpdateDetailInfo(probability, riskLevel, prediction);
            }
            catch (Exception ex)
            {
                lblRiskLevel.Text = "❌ LỖI";
                lblRiskLevel.ForeColor = Color.FromArgb(239, 68, 68);
                lblRiskPct.Text = "--";
                lblRiskPct.ForeColor = Color.FromArgb(239, 68, 68);
                lblRiskMsg.Text = $"Lỗi khi gọi API:\n{ex.Message}";
                lblRiskMsg.ForeColor = Color.FromArgb(239, 68, 68);
            }
            finally
            {
                btnAnalyze.Enabled = true;
                btnAnalyze.Text = "🔬 Phân tích";
            }
        }

        // ═══════════════════════════════════════════════════════
        // SỰ KIỆN: Xóa
        // ═══════════════════════════════════════════════════════
        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtFullName.Clear(); txtPhone.Clear(); txtAge.Clear();
            txtGlucose.Clear(); txtBmi.Clear();
            cboGender.SelectedIndex = -1;
            cboHypertension.SelectedIndex = -1;
            cboHeartDisease.SelectedIndex = -1;
            cboEverMarried.SelectedIndex = -1;
            cboWorkType.SelectedIndex = -1;
            cboResidence.SelectedIndex = -1;
            cboSmoking.SelectedIndex = -1;

            lblRiskPct.Text = "--%";
            lblRiskPct.ForeColor = Color.FromArgb(148, 163, 184);
            lblRiskLevel.Text = "Chưa có kết quả";
            lblRiskLevel.ForeColor = Color.FromArgb(148, 163, 184);
            lblRiskMsg.Text = "Vui lòng nhập dữ liệu và nhấn\n\"Phân tích\" để xem kết quả.";
            lblRiskMsg.ForeColor = Color.FromArgb(148, 163, 184);
            pnlResultBox.BackColor = Color.FromArgb(30, 41, 59);
            lblDetailInfo.Text = "Chưa có dữ liệu phân tích.";
        }

        // ═══════════════════════════════════════════════════════
        // SỰ KIỆN: Lưu vào CSDL
        // ═══════════════════════════════════════════════════════
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            btnSave.Enabled = false;
            btnSave.Text = "⏳ Đang lưu...";

            try
            {
                var payload = BuildPayload();
                string json = await _api.PredictAsync(payload);

                MessageBox.Show(
                    "✅ Đã lưu thành công vào CSDL!\n\nBệnh nhân và kết quả dự đoán đã được ghi nhận.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"❌ Lỗi khi lưu:\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text = "💾 Lưu DB";
            }
        }

        // ═══════════════════════════════════════════════════════
        // HELPERS
        // ═══════════════════════════════════════════════════════

        private object BuildPayload()
        {
            return new
            {
                fullName = txtFullName.Text.Trim(),
                gender = cboGender.Text,
                age = double.Parse(txtAge.Text.Trim()),
                hypertension = cboHypertension.SelectedIndex == 1 ? 1 : 0,
                heartDisease = cboHeartDisease.SelectedIndex == 1 ? 1 : 0,
                everMarried = cboEverMarried.Text,
                workType = cboWorkType.Text,
                residenceType = cboResidence.Text,
                avgGlucoseLevel = double.Parse(txtGlucose.Text.Trim()),
                bmi = double.Parse(txtBmi.Text.Trim()),
                smokingStatus = cboSmoking.Text
            };
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtAge.Text) ||
                string.IsNullOrWhiteSpace(txtGlucose.Text) ||
                string.IsNullOrWhiteSpace(txtBmi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ: Tuổi, Glucose, BMI.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboGender.SelectedIndex < 0 || cboWorkType.SelectedIndex < 0 ||
                cboResidence.SelectedIndex < 0 || cboSmoking.SelectedIndex < 0 ||
                cboEverMarried.SelectedIndex < 0 || cboHypertension.SelectedIndex < 0 ||
                cboHeartDisease.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ các mục.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!double.TryParse(txtAge.Text, out _) ||
                !double.TryParse(txtGlucose.Text, out _) ||
                !double.TryParse(txtBmi.Text, out _))
            {
                MessageBox.Show("Tuổi, Glucose, BMI phải là số hợp lệ.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void UpdateDetailInfo(double probability, string riskLevel, int prediction)
        {
            lblDetailInfo.Text =
                $"👤 Họ tên: {txtFullName.Text}\n" +
                $"📞 SĐT: {txtPhone.Text}\n" +
                $"⚧ Giới tính: {cboGender.Text}\n" +
                $"🎂 Tuổi: {txtAge.Text}\n" +
                $"💉 Tăng huyết áp: {cboHypertension.Text}\n" +
                $"❤️ Bệnh tim: {cboHeartDisease.Text}\n" +
                $"💍 Đã kết hôn: {cboEverMarried.Text}\n" +
                $"💼 Nghề nghiệp: {cboWorkType.Text}\n" +
                $"🏠 Nơi ở: {cboResidence.Text}\n" +
                $"🩸 Glucose: {txtGlucose.Text}\n" +
                $"📏 BMI: {txtBmi.Text}\n" +
                $"🚬 Hút thuốc: {cboSmoking.Text}\n" +
                $"──────────────────────\n" +
                $"🎯 Kết quả: {(prediction == 1 ? "Có nguy cơ" : "Bình thường")}\n" +
                $"📊 Xác suất: {probability * 100:F2}%\n" +
                $"⚡ Mức nguy cơ: {riskLevel}";
        }

        private void pnlMain_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
