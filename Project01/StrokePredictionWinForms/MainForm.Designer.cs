namespace StrokePredictionWinForms
{
    partial class MainForm
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

        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            pnlMenu = new Panel();
            btnConfig = new Button();
            btnHistory = new Button();
            btnBatch = new Button();
            btnSingle = new Button();
            btnDashboard = new Button();
            pnlUser = new Panel();
            btnLogout = new Button();
            lblRole = new Label();
            lblUsername = new Label();
            picUser = new PictureBox();
            pnlLogo = new Panel();
            lblVersion = new Label();
            lblAppName = new Label();
            picMainLogo = new PictureBox();
            splitContent = new SplitContainer();
            lblActiveSub = new Label();
            lblActiveTitle = new Label();
            pnlViewContainer = new Panel();
            pnlSidebar.SuspendLayout();
            pnlMenu.SuspendLayout();
            pnlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picUser).BeginInit();
            pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMainLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContent).BeginInit();
            splitContent.Panel1.SuspendLayout();
            splitContent.Panel2.SuspendLayout();
            splitContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(17, 24, 39);
            pnlSidebar.Controls.Add(pnlMenu);
            pnlSidebar.Controls.Add(pnlUser);
            pnlSidebar.Controls.Add(pnlLogo);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(260, 720);
            pnlSidebar.TabIndex = 0;
            // 
            // pnlMenu
            // 
            pnlMenu.Controls.Add(btnConfig);
            pnlMenu.Controls.Add(btnHistory);
            pnlMenu.Controls.Add(btnBatch);
            pnlMenu.Controls.Add(btnSingle);
            pnlMenu.Controls.Add(btnDashboard);
            pnlMenu.Dock = DockStyle.Fill;
            pnlMenu.Location = new Point(0, 140);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Padding = new Padding(10);
            pnlMenu.Size = new Size(260, 440);
            pnlMenu.TabIndex = 1;
            // 
            // btnConfig
            // 
            btnConfig.Cursor = Cursors.Hand;
            btnConfig.Dock = DockStyle.Top;
            btnConfig.FlatAppearance.BorderSize = 0;
            btnConfig.FlatStyle = FlatStyle.Flat;
            btnConfig.Font = new Font("Segoe UI Semibold", 10F);
            btnConfig.ForeColor = Color.FromArgb(148, 163, 184);
            btnConfig.Location = new Point(10, 210);
            btnConfig.Name = "btnConfig";
            btnConfig.Size = new Size(240, 50);
            btnConfig.TabIndex = 4;
            btnConfig.Text = "⚙️  Cấu hình API";
            btnConfig.TextAlign = ContentAlignment.MiddleLeft;
            btnConfig.UseVisualStyleBackColor = true;
            // 
            // btnHistory
            // 
            btnHistory.Cursor = Cursors.Hand;
            btnHistory.Dock = DockStyle.Top;
            btnHistory.FlatAppearance.BorderSize = 0;
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.Font = new Font("Segoe UI Semibold", 10F);
            btnHistory.ForeColor = Color.FromArgb(148, 163, 184);
            btnHistory.Location = new Point(10, 160);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(240, 50);
            btnHistory.TabIndex = 3;
            btnHistory.Text = "🕒  Lịch sử quét";
            btnHistory.TextAlign = ContentAlignment.MiddleLeft;
            btnHistory.UseVisualStyleBackColor = true;
            // 
            // btnBatch
            // 
            btnBatch.Cursor = Cursors.Hand;
            btnBatch.Dock = DockStyle.Top;
            btnBatch.FlatAppearance.BorderSize = 0;
            btnBatch.FlatStyle = FlatStyle.Flat;
            btnBatch.Font = new Font("Segoe UI Semibold", 10F);
            btnBatch.ForeColor = Color.FromArgb(148, 163, 184);
            btnBatch.Location = new Point(10, 110);
            btnBatch.Name = "btnBatch";
            btnBatch.Size = new Size(240, 50);
            btnBatch.TabIndex = 2;
            btnBatch.Text = "📁  Quét CSV";
            btnBatch.TextAlign = ContentAlignment.MiddleLeft;
            btnBatch.UseVisualStyleBackColor = true;
            // 
            // btnSingle
            // 
            btnSingle.Cursor = Cursors.Hand;
            btnSingle.Dock = DockStyle.Top;
            btnSingle.FlatAppearance.BorderSize = 0;
            btnSingle.FlatStyle = FlatStyle.Flat;
            btnSingle.Font = new Font("Segoe UI Semibold", 10F);
            btnSingle.ForeColor = Color.FromArgb(148, 163, 184);
            btnSingle.Location = new Point(10, 60);
            btnSingle.Name = "btnSingle";
            btnSingle.Size = new Size(240, 50);
            btnSingle.TabIndex = 1;
            btnSingle.Text = "🔍  Kiểm tra đơn lẻ";
            btnSingle.TextAlign = ContentAlignment.MiddleLeft;
            btnSingle.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(10, 10);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(240, 50);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "📊  Thống kê";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = true;
            // 
            // pnlUser
            // 
            pnlUser.BackColor = Color.FromArgb(15, 23, 42);
            pnlUser.Controls.Add(btnLogout);
            pnlUser.Controls.Add(lblRole);
            pnlUser.Controls.Add(lblUsername);
            pnlUser.Controls.Add(picUser);
            pnlUser.Dock = DockStyle.Bottom;
            pnlUser.Location = new Point(0, 580);
            pnlUser.Name = "pnlUser";
            pnlUser.Size = new Size(260, 140);
            pnlUser.TabIndex = 2;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(127, 29, 29);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Microsoft Sans Serif", 9F);
            btnLogout.ForeColor = Color.FromArgb(252, 165, 165);
            btnLogout.Location = new Point(15, 80);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(230, 40);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "🚪  Đăng xuất";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 8F);
            lblRole.ForeColor = Color.FromArgb(148, 163, 184);
            lblRole.Location = new Point(77, 42);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(30, 13);
            lblRole.TabIndex = 2;
            lblRole.Text = "User";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(77, 15);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(74, 19);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "username";
            // 
            // picUser
            // 
            picUser.Location = new Point(15, 15);
            picUser.Name = "picUser";
            picUser.Size = new Size(40, 40);
            picUser.SizeMode = PictureBoxSizeMode.Zoom;
            picUser.TabIndex = 0;
            picUser.TabStop = false;
            // 
            // pnlLogo
            // 
            pnlLogo.Controls.Add(lblVersion);
            pnlLogo.Controls.Add(lblAppName);
            pnlLogo.Controls.Add(picMainLogo);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(260, 140);
            pnlLogo.TabIndex = 0;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Segoe UI", 8F);
            lblVersion.ForeColor = Color.FromArgb(148, 163, 184);
            lblVersion.Location = new Point(77, 75);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(105, 13);
            lblVersion.TabIndex = 2;
            lblVersion.Text = "v1.0.0 • AI-Powered";
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(75, 45);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(123, 30);
            lblAppName.TabIndex = 1;
            lblAppName.Text = "STROKE.AI";
            // 
            // picMainLogo
            // 
            picMainLogo.BackgroundImage = Properties.Resources.stroke1;
            picMainLogo.BackgroundImageLayout = ImageLayout.Stretch;
            picMainLogo.Location = new Point(15, 40);
            picMainLogo.Name = "picMainLogo";
            picMainLogo.Size = new Size(55, 55);
            picMainLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picMainLogo.TabIndex = 0;
            picMainLogo.TabStop = false;
            // 
            // splitContent
            // 
            splitContent.Dock = DockStyle.Fill;
            splitContent.FixedPanel = FixedPanel.Panel1;
            splitContent.IsSplitterFixed = true;
            splitContent.Location = new Point(260, 0);
            splitContent.Name = "splitContent";
            splitContent.Orientation = Orientation.Horizontal;
            // 
            // splitContent.Panel1
            // 
            splitContent.Panel1.BackColor = Color.FromArgb(15, 23, 42);
            splitContent.Panel1.Controls.Add(lblActiveSub);
            splitContent.Panel1.Controls.Add(lblActiveTitle);
            splitContent.Panel1.Padding = new Padding(30, 20, 0, 0);
            // 
            // splitContent.Panel2
            // 
            splitContent.Panel2.BackColor = Color.FromArgb(11, 17, 30);
            splitContent.Panel2.Controls.Add(pnlViewContainer);
            splitContent.Size = new Size(1020, 720);
            splitContent.SplitterDistance = 90;
            splitContent.TabIndex = 1;
            // 
            // lblActiveSub
            // 
            lblActiveSub.AutoSize = true;
            lblActiveSub.Font = new Font("Segoe UI", 10F);
            lblActiveSub.ForeColor = Color.FromArgb(148, 163, 184);
            lblActiveSub.Location = new Point(30, 60);
            lblActiveSub.Name = "lblActiveSub";
            lblActiveSub.Size = new Size(293, 19);
            lblActiveSub.TabIndex = 1;
            lblActiveSub.Text = "Tổng quan dữ liệu và phân tích từ hệ thống AI";
            // 
            // lblActiveTitle
            // 
            lblActiveTitle.AutoSize = true;
            lblActiveTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblActiveTitle.ForeColor = Color.White;
            lblActiveTitle.Location = new Point(25, 15);
            lblActiveTitle.Name = "lblActiveTitle";
            lblActiveTitle.Size = new Size(161, 45);
            lblActiveTitle.TabIndex = 0;
            lblActiveTitle.Text = "Thống kê";
            // 
            // pnlViewContainer
            // 
            pnlViewContainer.Dock = DockStyle.Fill;
            pnlViewContainer.Location = new Point(0, 0);
            pnlViewContainer.Name = "pnlViewContainer";
            pnlViewContainer.Size = new Size(1020, 626);
            pnlViewContainer.TabIndex = 0;
            pnlViewContainer.Paint += pnlViewContainer_Paint;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(1280, 720);
            Controls.Add(splitContent);
            Controls.Add(pnlSidebar);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "STROKE.AI - Hệ thống chẩn đoán đột quỵ thông minh";
            pnlSidebar.ResumeLayout(false);
            pnlMenu.ResumeLayout(false);
            pnlUser.ResumeLayout(false);
            pnlUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picUser).EndInit();
            pnlLogo.ResumeLayout(false);
            pnlLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picMainLogo).EndInit();
            splitContent.Panel1.ResumeLayout(false);
            splitContent.Panel1.PerformLayout();
            splitContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContent).EndInit();
            splitContent.ResumeLayout(false);
            ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.PictureBox picMainLogo;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnSingle;
        private System.Windows.Forms.Button btnBatch;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.SplitContainer splitContent;
        private System.Windows.Forms.Label lblActiveTitle;
        private System.Windows.Forms.Label lblActiveSub;
        private System.Windows.Forms.Panel pnlViewContainer;
    }
}
