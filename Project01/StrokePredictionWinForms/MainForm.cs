using System;
using System.Drawing;
using System.Windows.Forms;
using StrokePredictionWinForms.Views;

namespace StrokePredictionWinForms
{
    public partial class MainForm : Form
    {
        private readonly ApiClient _api;
        private Button _currentBtn;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(ApiClient api) : this()
        {
            _api = api;
            if (this.DesignMode) return;

            SetupNavigation();
            LoadUserProfile();

            // Trang mặc định khi mở app
            btnDashboard.PerformClick();
        }

        private void LoadUserProfile()
        {
            lblUsername.Text = _api.CurrentUser ?? "Admin";
            lblRole.Text = "Chuyên gia y tế"; // Hoặc lấy từ API nếu có
        }

        private void SetupNavigation()
        {
            // Đăng ký sự kiện Click cho các button menu
            btnDashboard.Click += (s, e) => OpenView(btnDashboard, new DashboardView(_api), "Thống kê", "Tổng quan dữ liệu và phân tích từ hệ thống AI");
            btnSingle.Click   += (s, e) => OpenView(btnSingle, new SingleCheckView(_api), "Kiểm tra đơn lẻ", "Chẩn đoán nguy cơ đột quỵ cho bệnh nhân cụ thể");
            btnBatch.Click    += (s, e) => OpenView(btnBatch, new BatchScanView(_api), "Quét CSV", "Xử lý dữ liệu bệnh nhân hàng loạt từ tệp tin");
            btnHistory.Click  += (s, e) => OpenView(btnHistory, new HistoryView(_api), "Lịch sử quét", "Xem lại các kết quả chẩn đoán trước đây");
            btnConfig.Click   += (s, e) => OpenView(btnConfig, new ConfigView(_api), "Cấu hình API", "Thiết lập kết nối máy chủ và mô hình AI");

            btnLogout.Click += (s, e) =>
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
            };
        }

        private void OpenView(Button btn, UserControl view, string title, string subTitle)
        {
            if (btn == _currentBtn) return;

            // Highlight button được chọn
            if (_currentBtn != null)
            {
                _currentBtn.BackColor = Color.Transparent;
                _currentBtn.ForeColor = Color.FromArgb(148, 163, 184);
            }

            btn.BackColor = Color.FromArgb(31, 41, 55);
            btn.ForeColor = Color.FromArgb(16, 185, 129);
            _currentBtn = btn;

            // Cập nhật tiêu đề
            lblActiveTitle.Text = title;
            lblActiveSub.Text = subTitle;

            // Hiển thị UserControl
            pnlViewContainer.Controls.Clear();
            view.Dock = DockStyle.Fill;
            pnlViewContainer.Controls.Add(view);
        }

        private void pnlViewContainer_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
