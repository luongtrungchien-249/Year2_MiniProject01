namespace StrokePredictionWinForms.Views
{
    partial class ConfigView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.split = new System.Windows.Forms.SplitContainer();
            this.pnlAi = new System.Windows.Forms.Panel();
            this.lblAiTitle = new System.Windows.Forms.Label();
            this.lblNgrokDesc1 = new System.Windows.Forms.Label();
            this.txtNgrokUrl = new System.Windows.Forms.TextBox();
            this.lblNgrokDesc2 = new System.Windows.Forms.Label();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.nudTimeout = new System.Windows.Forms.NumericUpDown();
            this.lblTimeoutUnit = new System.Windows.Forms.Label();
            this.lblRetry = new System.Windows.Forms.Label();
            this.nudRetry = new System.Windows.Forms.NumericUpDown();
            this.lblRetryUnit = new System.Windows.Forms.Label();
            this.lblApiKeyDesc = new System.Windows.Forms.Label();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.chkShowKey = new System.Windows.Forms.CheckBox();
            this.btnSaveApi = new System.Windows.Forms.Button();
            this.btnPingAi = new System.Windows.Forms.Button();
            this.btnResetApi = new System.Windows.Forms.Button();
            
            this.pnlDb = new System.Windows.Forms.Panel();
            this.lblDbTitle = new System.Windows.Forms.Label();
            this.lblDbDesc = new System.Windows.Forms.Label();
            this.txtDbPath = new System.Windows.Forms.TextBox();
            this.btnBrowseDb = new System.Windows.Forms.Button();
            this.lblDbNote = new System.Windows.Forms.Label();
            this.btnSaveDb = new System.Windows.Forms.Button();
            this.btnTestConnect = new System.Windows.Forms.Button();
            this.spacer = new System.Windows.Forms.Panel();

            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblStatusTitle = new System.Windows.Forms.Label();
            this.pnlStatusDot = new System.Windows.Forms.Panel();
            this.lblStatusLive = new System.Windows.Forms.Label();
            this.sep1 = new System.Windows.Forms.Panel();
            this.lblEndpointTitle = new System.Windows.Forms.Label();
            this.lblEndpoint = new System.Windows.Forms.Label();
            this.line1 = new System.Windows.Forms.Panel();
            this.lblLatencyTitle = new System.Windows.Forms.Label();
            this.lblLatency = new System.Windows.Forms.Label();
            this.line2 = new System.Windows.Forms.Panel();
            this.lblLastPingTitle = new System.Windows.Forms.Label();
            this.lblLastPing = new System.Windows.Forms.Label();
            this.line3 = new System.Windows.Forms.Panel();
            this.lblModelAiTitle = new System.Windows.Forms.Label();
            this.lblModelAi = new System.Windows.Forms.Label();
            this.line4 = new System.Windows.Forms.Panel();
            this.btnRefreshStatus = new System.Windows.Forms.Button();
            this.sep2 = new System.Windows.Forms.Panel();
            this.lblLogTitle = new System.Windows.Forms.Label();
            this.lstLog = new System.Windows.Forms.ListBox();

            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.pnlAi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRetry)).BeginInit();
            this.pnlDb.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();

            // 
            // split
            // 
            this.split.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(17)))), ((int)(((byte)(30)))));
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 0);
            this.split.Name = "split";
            this.split.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.split.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.split.Panel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.split.Size = new System.Drawing.Size(1000, 600);
            this.split.SplitterDistance = 520;
            this.split.SplitterWidth = 8;
            
            // split.Panel1
            this.split.Panel1.Controls.Add(this.pnlDb);
            this.split.Panel1.Controls.Add(this.spacer);
            this.split.Panel1.Controls.Add(this.pnlAi);
            
            // split.Panel2
            this.split.Panel2.Controls.Add(this.pnlStatus);

            // pnlAi
            this.pnlAi.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAi.Height = 300;
            this.pnlAi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.pnlAi.Padding = new System.Windows.Forms.Padding(20);
            
            this.lblAiTitle.Text = "⚙️  Cấu hình AI Service (Ngrok)";
            this.lblAiTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAiTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblAiTitle.Location = new System.Drawing.Point(0, 5);
            this.lblAiTitle.AutoSize = true;

            this.lblNgrokDesc1.Text = "NGROK ENDPOINT URL";
            this.lblNgrokDesc1.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblNgrokDesc1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblNgrokDesc1.Location = new System.Drawing.Point(0, 40);
            this.lblNgrokDesc1.AutoSize = true;

            this.txtNgrokUrl.Text = "https://xxxx-xx-xx-xxx-xx.ngrok-free.app";
            this.txtNgrokUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtNgrokUrl.ForeColor = System.Drawing.Color.White;
            this.txtNgrokUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNgrokUrl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNgrokUrl.Location = new System.Drawing.Point(0, 58);
            this.txtNgrokUrl.Size = new System.Drawing.Size(430, 28);

            this.lblNgrokDesc2.Text = "ℹ️ Lấy URL từ output cell Ngrok trong Google Colab";
            this.lblNgrokDesc2.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblNgrokDesc2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblNgrokDesc2.Location = new System.Drawing.Point(0, 88);
            this.lblNgrokDesc2.AutoSize = true;

            this.lblTimeout.Text = "REQUEST TIMEOUT";
            this.lblTimeout.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblTimeout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblTimeout.Location = new System.Drawing.Point(0, 110);
            this.lblTimeout.AutoSize = true;

            this.lblRetry.Text = "SỐ LẦN THỬ LẠI";
            this.lblRetry.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblRetry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblRetry.Location = new System.Drawing.Point(210, 110);
            this.lblRetry.AutoSize = true;

            this.nudTimeout.Value = 30;
            this.nudTimeout.Minimum = 5;
            this.nudTimeout.Maximum = 120;
            this.nudTimeout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.nudTimeout.ForeColor = System.Drawing.Color.White;
            this.nudTimeout.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudTimeout.Location = new System.Drawing.Point(0, 128);
            this.nudTimeout.Size = new System.Drawing.Size(80, 28);

            this.lblTimeoutUnit.Text = "giây";
            this.lblTimeoutUnit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTimeoutUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblTimeoutUnit.Location = new System.Drawing.Point(85, 131);
            this.lblTimeoutUnit.AutoSize = true;

            this.nudRetry.Value = 3;
            this.nudRetry.Minimum = 0;
            this.nudRetry.Maximum = 10;
            this.nudRetry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.nudRetry.ForeColor = System.Drawing.Color.White;
            this.nudRetry.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudRetry.Location = new System.Drawing.Point(210, 128);
            this.nudRetry.Size = new System.Drawing.Size(80, 28);

            this.lblRetryUnit.Text = "lần";
            this.lblRetryUnit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRetryUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblRetryUnit.Location = new System.Drawing.Point(295, 131);
            this.lblRetryUnit.AutoSize = true;

            this.lblApiKeyDesc.Text = "API SECRET KEY (tuỳ chọn — dùng nếu backend có xác thực)";
            this.lblApiKeyDesc.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblApiKeyDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblApiKeyDesc.Location = new System.Drawing.Point(0, 163);
            this.lblApiKeyDesc.AutoSize = true;

            this.txtApiKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtApiKey.ForeColor = System.Drawing.Color.White;
            this.txtApiKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApiKey.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtApiKey.PasswordChar = '●';
            this.txtApiKey.Location = new System.Drawing.Point(0, 181);
            this.txtApiKey.Size = new System.Drawing.Size(430, 28);

            this.chkShowKey.Text = "Hiện API Key";
            this.chkShowKey.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.chkShowKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.chkShowKey.Location = new System.Drawing.Point(0, 211);
            this.chkShowKey.AutoSize = true;
            this.chkShowKey.CheckedChanged += new System.EventHandler(this.chkShowKey_CheckedChanged);

            this.btnSaveApi.Text = "💾  Lưu cấu hình";
            this.btnSaveApi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnSaveApi.ForeColor = System.Drawing.Color.White;
            this.btnSaveApi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveApi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveApi.Location = new System.Drawing.Point(0, 239);
            this.btnSaveApi.Size = new System.Drawing.Size(135, 32);

            this.btnPingAi.Text = "📡  Ping AI";
            this.btnPingAi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnPingAi.ForeColor = System.Drawing.Color.White;
            this.btnPingAi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPingAi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPingAi.Location = new System.Drawing.Point(145, 239);
            this.btnPingAi.Size = new System.Drawing.Size(110, 32);

            this.btnResetApi.Text = "↺  Mặc định";
            this.btnResetApi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnResetApi.ForeColor = System.Drawing.Color.White;
            this.btnResetApi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetApi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnResetApi.Location = new System.Drawing.Point(265, 239);
            this.btnResetApi.Size = new System.Drawing.Size(110, 32);

            this.pnlAi.Controls.Add(this.lblAiTitle);
            this.pnlAi.Controls.Add(this.lblNgrokDesc1);
            this.pnlAi.Controls.Add(this.txtNgrokUrl);
            this.pnlAi.Controls.Add(this.lblNgrokDesc2);
            this.pnlAi.Controls.Add(this.lblTimeout);
            this.pnlAi.Controls.Add(this.lblRetry);
            this.pnlAi.Controls.Add(this.nudTimeout);
            this.pnlAi.Controls.Add(this.lblTimeoutUnit);
            this.pnlAi.Controls.Add(this.nudRetry);
            this.pnlAi.Controls.Add(this.lblRetryUnit);
            this.pnlAi.Controls.Add(this.lblApiKeyDesc);
            this.pnlAi.Controls.Add(this.txtApiKey);
            this.pnlAi.Controls.Add(this.chkShowKey);
            this.pnlAi.Controls.Add(this.btnSaveApi);
            this.pnlAi.Controls.Add(this.btnPingAi);
            this.pnlAi.Controls.Add(this.btnResetApi);

            // spacer
            this.spacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.spacer.Height = 8;
            this.spacer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(17)))), ((int)(((byte)(30)))));

            // pnlDb
            this.pnlDb.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDb.Height = 170;
            this.pnlDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.pnlDb.Padding = new System.Windows.Forms.Padding(20);
            
            this.lblDbTitle.Text = "🗄️  Cấu hình Cơ sở dữ liệu";
            this.lblDbTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblDbTitle.Location = new System.Drawing.Point(0, 5);
            this.lblDbTitle.AutoSize = true;

            this.lblDbDesc.Text = "ĐƯỜNG DẪN FILE DATABASE (PostgreSQL)";
            this.lblDbDesc.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblDbDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblDbDesc.Location = new System.Drawing.Point(0, 40);
            this.lblDbDesc.AutoSize = true;

            this.txtDbPath.Text = "localhost:5432/stroke_db";
            this.txtDbPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtDbPath.ForeColor = System.Drawing.Color.White;
            this.txtDbPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDbPath.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDbPath.Location = new System.Drawing.Point(0, 58);
            this.txtDbPath.Size = new System.Drawing.Size(380, 28);

            this.btnBrowseDb.Text = "📁";
            this.btnBrowseDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnBrowseDb.ForeColor = System.Drawing.Color.White;
            this.btnBrowseDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseDb.Location = new System.Drawing.Point(385, 58);
            this.btnBrowseDb.Size = new System.Drawing.Size(38, 28);

            this.lblDbNote.Text = "ℹ️ Khuyến nghị cấu hình connection string phù hợp";
            this.lblDbNote.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblDbNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDbNote.Location = new System.Drawing.Point(0, 88);
            this.lblDbNote.AutoSize = true;

            this.btnSaveDb.Text = "💾  Lưu đường dẫn";
            this.btnSaveDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnSaveDb.ForeColor = System.Drawing.Color.White;
            this.btnSaveDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveDb.Location = new System.Drawing.Point(0, 113);
            this.btnSaveDb.Size = new System.Drawing.Size(140, 32);

            this.btnTestConnect.Text = "🔌  Test kết nối";
            this.btnTestConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnTestConnect.ForeColor = System.Drawing.Color.White;
            this.btnTestConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestConnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTestConnect.Location = new System.Drawing.Point(150, 113);
            this.btnTestConnect.Size = new System.Drawing.Size(130, 32);

            this.pnlDb.Controls.Add(this.lblDbTitle);
            this.pnlDb.Controls.Add(this.lblDbDesc);
            this.pnlDb.Controls.Add(this.txtDbPath);
            this.pnlDb.Controls.Add(this.btnBrowseDb);
            this.pnlDb.Controls.Add(this.lblDbNote);
            this.pnlDb.Controls.Add(this.btnSaveDb);
            this.pnlDb.Controls.Add(this.btnTestConnect);

            // pnlStatus
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.pnlStatus.Padding = new System.Windows.Forms.Padding(20);

            this.lblStatusTitle.Text = "📡  Trạng thái kết nối AI";
            this.lblStatusTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatusTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblStatusTitle.Location = new System.Drawing.Point(0, 5);
            this.lblStatusTitle.AutoSize = true;

            this.pnlStatusDot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.pnlStatusDot.Size = new System.Drawing.Size(16, 16);
            this.pnlStatusDot.Location = new System.Drawing.Point(0, 50);

            this.lblStatusLive.Text = "Chưa kiểm tra";
            this.lblStatusLive.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStatusLive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblStatusLive.Location = new System.Drawing.Point(25, 45);
            this.lblStatusLive.AutoSize = true;

            this.sep1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.sep1.Location = new System.Drawing.Point(0, 90);
            this.sep1.Size = new System.Drawing.Size(350, 1);

            int dy = 100;
            this.lblEndpointTitle.Text = "Endpoint";
            this.lblEndpointTitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblEndpointTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblEndpointTitle.Location = new System.Drawing.Point(0, dy);
            this.lblEndpointTitle.AutoSize = true;
            this.lblEndpoint.Text = "—";
            this.lblEndpoint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEndpoint.ForeColor = System.Drawing.Color.White;
            this.lblEndpoint.Location = new System.Drawing.Point(120, dy);
            this.lblEndpoint.AutoSize = true;
            this.line1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.line1.Location = new System.Drawing.Point(0, dy + 20);
            this.line1.Size = new System.Drawing.Size(350, 1);
            dy += 28;

            this.lblLatencyTitle.Text = "Độ trễ (ms)";
            this.lblLatencyTitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblLatencyTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblLatencyTitle.Location = new System.Drawing.Point(0, dy);
            this.lblLatencyTitle.AutoSize = true;
            this.lblLatency.Text = "—";
            this.lblLatency.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLatency.ForeColor = System.Drawing.Color.White;
            this.lblLatency.Location = new System.Drawing.Point(120, dy);
            this.lblLatency.AutoSize = true;
            this.line2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.line2.Location = new System.Drawing.Point(0, dy + 20);
            this.line2.Size = new System.Drawing.Size(350, 1);
            dy += 28;

            this.lblLastPingTitle.Text = "Lần ping cuối";
            this.lblLastPingTitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblLastPingTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblLastPingTitle.Location = new System.Drawing.Point(0, dy);
            this.lblLastPingTitle.AutoSize = true;
            this.lblLastPing.Text = "—";
            this.lblLastPing.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLastPing.ForeColor = System.Drawing.Color.White;
            this.lblLastPing.Location = new System.Drawing.Point(120, dy);
            this.lblLastPing.AutoSize = true;
            this.line3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.line3.Location = new System.Drawing.Point(0, dy + 20);
            this.line3.Size = new System.Drawing.Size(350, 1);
            dy += 28;

            this.lblModelAiTitle.Text = "Model AI";
            this.lblModelAiTitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblModelAiTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblModelAiTitle.Location = new System.Drawing.Point(0, dy);
            this.lblModelAiTitle.AutoSize = true;
            this.lblModelAi.Text = "Stacking (CW)";
            this.lblModelAi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblModelAi.ForeColor = System.Drawing.Color.White;
            this.lblModelAi.Location = new System.Drawing.Point(120, dy);
            this.lblModelAi.AutoSize = true;
            this.line4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.line4.Location = new System.Drawing.Point(0, dy + 20);
            this.line4.Size = new System.Drawing.Size(350, 1);
            dy += 28;

            dy += 5;
            this.btnRefreshStatus.Text = "📡  Kiểm tra ngay";
            this.btnRefreshStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnRefreshStatus.ForeColor = System.Drawing.Color.White;
            this.btnRefreshStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshStatus.Location = new System.Drawing.Point(0, dy);
            this.btnRefreshStatus.Size = new System.Drawing.Size(155, 32);
            dy += 45;

            this.sep2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.sep2.Location = new System.Drawing.Point(0, dy);
            this.sep2.Size = new System.Drawing.Size(350, 1);
            dy += 10;

            this.lblLogTitle.Text = "📋  Nhật ký hoạt động";
            this.lblLogTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLogTitle.ForeColor = System.Drawing.Color.White;
            this.lblLogTitle.Location = new System.Drawing.Point(0, dy);
            this.lblLogTitle.AutoSize = true;
            dy += 28;

            this.lstLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lstLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lstLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLog.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.lstLog.Location = new System.Drawing.Point(0, dy);
            this.lstLog.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;
            this.lstLog.Size = new System.Drawing.Size(350, 200);

            this.pnlStatus.Controls.Add(this.lblStatusTitle);
            this.pnlStatus.Controls.Add(this.pnlStatusDot);
            this.pnlStatus.Controls.Add(this.lblStatusLive);
            this.pnlStatus.Controls.Add(this.sep1);
            this.pnlStatus.Controls.Add(this.lblEndpointTitle);
            this.pnlStatus.Controls.Add(this.lblEndpoint);
            this.pnlStatus.Controls.Add(this.line1);
            this.pnlStatus.Controls.Add(this.lblLatencyTitle);
            this.pnlStatus.Controls.Add(this.lblLatency);
            this.pnlStatus.Controls.Add(this.line2);
            this.pnlStatus.Controls.Add(this.lblLastPingTitle);
            this.pnlStatus.Controls.Add(this.lblLastPing);
            this.pnlStatus.Controls.Add(this.line3);
            this.pnlStatus.Controls.Add(this.lblModelAiTitle);
            this.pnlStatus.Controls.Add(this.lblModelAi);
            this.pnlStatus.Controls.Add(this.line4);
            this.pnlStatus.Controls.Add(this.btnRefreshStatus);
            this.pnlStatus.Controls.Add(this.sep2);
            this.pnlStatus.Controls.Add(this.lblLogTitle);
            this.pnlStatus.Controls.Add(this.lstLog);

            // ConfigView
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.split);
            this.Name = "ConfigView";
            this.Size = new System.Drawing.Size(1000, 600);

            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            this.split.ResumeLayout(false);
            this.pnlAi.ResumeLayout(false);
            this.pnlAi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRetry)).EndInit();
            this.pnlDb.ResumeLayout(false);
            this.pnlDb.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.Panel pnlAi;
        private System.Windows.Forms.Label lblAiTitle;
        private System.Windows.Forms.Label lblNgrokDesc1;
        private System.Windows.Forms.TextBox txtNgrokUrl;
        private System.Windows.Forms.Label lblNgrokDesc2;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.NumericUpDown nudTimeout;
        private System.Windows.Forms.Label lblTimeoutUnit;
        private System.Windows.Forms.Label lblRetry;
        private System.Windows.Forms.NumericUpDown nudRetry;
        private System.Windows.Forms.Label lblRetryUnit;
        private System.Windows.Forms.Label lblApiKeyDesc;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.CheckBox chkShowKey;
        private System.Windows.Forms.Button btnSaveApi;
        private System.Windows.Forms.Button btnPingAi;
        private System.Windows.Forms.Button btnResetApi;

        private System.Windows.Forms.Panel pnlDb;
        private System.Windows.Forms.Label lblDbTitle;
        private System.Windows.Forms.Label lblDbDesc;
        private System.Windows.Forms.TextBox txtDbPath;
        private System.Windows.Forms.Button btnBrowseDb;
        private System.Windows.Forms.Label lblDbNote;
        private System.Windows.Forms.Button btnSaveDb;
        private System.Windows.Forms.Button btnTestConnect;
        private System.Windows.Forms.Panel spacer;

        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblStatusTitle;
        private System.Windows.Forms.Panel pnlStatusDot;
        private System.Windows.Forms.Label lblStatusLive;
        private System.Windows.Forms.Panel sep1;
        private System.Windows.Forms.Label lblEndpointTitle;
        private System.Windows.Forms.Label lblEndpoint;
        private System.Windows.Forms.Panel line1;
        private System.Windows.Forms.Label lblLatencyTitle;
        private System.Windows.Forms.Label lblLatency;
        private System.Windows.Forms.Panel line2;
        private System.Windows.Forms.Label lblLastPingTitle;
        private System.Windows.Forms.Label lblLastPing;
        private System.Windows.Forms.Panel line3;
        private System.Windows.Forms.Label lblModelAiTitle;
        private System.Windows.Forms.Label lblModelAi;
        private System.Windows.Forms.Panel line4;
        private System.Windows.Forms.Button btnRefreshStatus;
        private System.Windows.Forms.Panel sep2;
        private System.Windows.Forms.Label lblLogTitle;
        private System.Windows.Forms.ListBox lstLog;
    }
}
