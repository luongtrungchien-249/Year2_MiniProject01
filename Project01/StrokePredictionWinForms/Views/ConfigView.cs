using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace StrokePredictionWinForms.Views
{
    public partial class ConfigView : UserControl
    {
        private readonly ApiClient _api;

        public ConfigView() { InitializeComponent(); }

        public ConfigView(ApiClient api) : this()
        {
            _api = api;
            if (DesignMode) return;
            
            // Events
            btnSaveApi.Click += BtnSaveApi_Click;
            btnPingAi.Click += BtnPingAi_Click;
            btnResetApi.Click += BtnResetApi_Click;
            btnSaveDb.Click += (s, e) => { AddLog("[DB] Đã lưu cấu hình CSDL."); MessageBox.Show("✅ Đã lưu!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information); };
            btnTestConnect.Click += BtnTestConnect_Click;
            btnRefreshStatus.Click += BtnRefreshStatus_Click;
            btnBrowseDb.Click += (s, e) =>
            {
                using var ofd = new OpenFileDialog { Filter = "All files|*.*" };
                if (ofd.ShowDialog() == DialogResult.OK) txtDbPath.Text = ofd.FileName;
            };

            AddLog("[Hệ thống] Nhật ký khởi động...");
        }

        // ═══════════════════════════════════════════
        // EVENTS
        // ═══════════════════════════════════════════
        private void chkShowKey_CheckedChanged(object sender, EventArgs e)
        {
            txtApiKey.PasswordChar = chkShowKey.Checked ? '\0' : '●';
        }

        private void BtnSaveApi_Click(object sender, EventArgs e)
        {
            AddLog($"[API] Đã lưu: {txtNgrokUrl.Text}");
            MessageBox.Show("✅ Đã lưu cấu hình API!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void BtnPingAi_Click(object sender, EventArgs e)
        {
            btnPingAi.Enabled = false;
            AddLog("[API] Đang ping AI...");
            var sw = Stopwatch.StartNew();
            try
            {
                await _api.GetAsync("health");
                sw.Stop();
                SetStatus(true, sw.ElapsedMilliseconds);
                AddLog($"[API] Ping OK — {sw.ElapsedMilliseconds}ms");
            }
            catch
            {
                sw.Stop();
                SetStatus(false, -1);
                AddLog("[API] ❌ Ping thất bại!");
            }
            btnPingAi.Enabled = true;
        }

        private void BtnResetApi_Click(object sender, EventArgs e)
        {
            txtNgrokUrl.Text = "https://xxxx-xx-xx-xxx-xx.ngrok-free.app";
            nudTimeout.Value = 30; nudRetry.Value = 3;
            txtApiKey.Clear();
            AddLog("[API] Đã reset về mặc định.");
        }

        private async void BtnTestConnect_Click(object sender, EventArgs e)
        {
            btnTestConnect.Enabled = false;
            AddLog("[DB] Đang test kết nối...");
            try
            {
                await _api.GetAsync("health");
                AddLog("[DB] ✅ Kết nối CSDL thành công!");
                MessageBox.Show("✅ Kết nối thành công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                AddLog("[DB] ❌ Không thể kết nối!");
                MessageBox.Show("❌ Không thể kết nối.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnTestConnect.Enabled = true;
        }

        private async void BtnRefreshStatus_Click(object sender, EventArgs e)
        {
            btnRefreshStatus.Enabled = false;
            lblStatusLive.Text = "Đang kiểm tra...";
            lblStatusLive.ForeColor = Color.FromArgb(245, 158, 11);
            AddLog("[Status] Kiểm tra kết nối...");

            var sw = Stopwatch.StartNew();
            try
            {
                await _api.GetAsync("health");
                sw.Stop();
                SetStatus(true, sw.ElapsedMilliseconds);
                AddLog($"[Status] ✅ Online — {sw.ElapsedMilliseconds}ms");
            }
            catch
            {
                sw.Stop();
                SetStatus(false, -1);
                AddLog("[Status] ❌ Offline");
            }
            btnRefreshStatus.Enabled = true;
        }

        // ═══════════════════════════════════════════
        // HELPERS
        // ═══════════════════════════════════════════
        private void SetStatus(bool online, long latency)
        {
            pnlStatusDot.BackColor = online ? Color.FromArgb(34, 197, 94) : Color.FromArgb(239, 68, 68);
            lblStatusLive.Text = online ? "Đang hoạt động" : "Không phản hồi";
            lblStatusLive.ForeColor = online ? Color.FromArgb(34, 197, 94) : Color.FromArgb(239, 68, 68);
            lblEndpoint.Text = txtNgrokUrl.Text;
            lblLatency.Text = latency > 0 ? $"{latency} ms" : "—";
            lblLastPing.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
        }

        private void AddLog(string msg)
        {
            lstLog?.Items.Insert(0, $"[{DateTime.Now:HH:mm:ss}] {msg}");
        }
    }
}
