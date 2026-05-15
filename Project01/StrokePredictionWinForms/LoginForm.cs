using System;
using System.Windows.Forms;

namespace StrokePredictionWinForms
{
    public partial class LoginForm : Form
    {
        private readonly ApiClient _api;
        public ApiClient Api => _api;

        // Constructor không tham số cho Designer
        public LoginForm()
        {
            _api = new ApiClient();
            InitializeComponent();

            if (!this.DesignMode)
            {
                chkShowPass.CheckedChanged += ChkShowPass_CheckedChanged;
                btnLogin.Click += BtnLogin_Click;
            }
        }

        // Constructor thực tế dùng trong ứng dụng (nếu truyền ApiClient từ bên ngoài)
        public LoginForm(ApiClient api) : this()
        {
            _api = api;
        }

        private void ChkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            // Chuyển đổi hiển thị mật khẩu
            txtPassword.PasswordChar = chkShowPass.Checked ? '\0' : '●';
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập Email và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "⏳ ĐANG XỬ LÝ...";

            try
            {
                if (await _api.LoginAsync(user, pass))
                {
                    // Đăng nhập thành công
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Email hoặc mật khẩu không chính xác!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "ĐĂNG NHẬP";
            }
        }
    }
}
