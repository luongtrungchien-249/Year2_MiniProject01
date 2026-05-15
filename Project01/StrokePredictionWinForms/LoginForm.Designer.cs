namespace StrokePredictionWinForms
{
    partial class LoginForm
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
            splitMain = new SplitContainer();
            lblBrandDesc = new Label();
            lblBrandName = new Label();
            picLogo = new PictureBox();
            pnlLine = new Panel();
            btnLogin = new Button();
            chkShowPass = new CheckBox();
            txtPassword = new TextBox();
            lblPassTag = new Label();
            txtUsername = new TextBox();
            lblUserTag = new Label();
            lblLoginSub = new Label();
            lblLoginTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // splitMain
            // 
            splitMain.Dock = DockStyle.Fill;
            splitMain.IsSplitterFixed = true;
            splitMain.Location = new Point(0, 0);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.BackColor = Color.FromArgb(30, 41, 59);
            splitMain.Panel1.Controls.Add(lblBrandDesc);
            splitMain.Panel1.Controls.Add(lblBrandName);
            splitMain.Panel1.Controls.Add(picLogo);
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.BackColor = Color.FromArgb(30, 41, 59);
            splitMain.Panel2.Controls.Add(pnlLine);
            splitMain.Panel2.Controls.Add(btnLogin);
            splitMain.Panel2.Controls.Add(chkShowPass);
            splitMain.Panel2.Controls.Add(txtPassword);
            splitMain.Panel2.Controls.Add(lblPassTag);
            splitMain.Panel2.Controls.Add(txtUsername);
            splitMain.Panel2.Controls.Add(lblUserTag);
            splitMain.Panel2.Controls.Add(lblLoginSub);
            splitMain.Panel2.Controls.Add(lblLoginTitle);
            splitMain.Panel2.Padding = new Padding(60, 80, 60, 60);
            splitMain.Size = new Size(950, 600);
            splitMain.SplitterDistance = 400;
            splitMain.TabIndex = 0;
            // 
            // lblBrandDesc
            // 
            lblBrandDesc.Font = new Font("Segoe UI", 10F);
            lblBrandDesc.ForeColor = Color.FromArgb(148, 163, 184);
            lblBrandDesc.Location = new Point(50, 360);
            lblBrandDesc.Name = "lblBrandDesc";
            lblBrandDesc.Size = new Size(300, 50);
            lblBrandDesc.TabIndex = 2;
            lblBrandDesc.Text = "Hệ thống chẩn đoán và dự đoán nguy cơ đột quỵ dựa trên AI";
            lblBrandDesc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBrandName
            // 
            lblBrandName.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblBrandName.ForeColor = Color.White;
            lblBrandName.Location = new Point(0, 300);
            lblBrandName.Name = "lblBrandName";
            lblBrandName.Size = new Size(400, 60);
            lblBrandName.TabIndex = 1;
            lblBrandName.Text = "STROKE.AI";
            lblBrandName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            picLogo.BackgroundImage = Properties.Resources.stroke1;
            picLogo.BackgroundImageLayout = ImageLayout.Stretch;
            picLogo.Location = new Point(125, 120);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(150, 150);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // pnlLine
            // 
            pnlLine.BackColor = Color.FromArgb(16, 185, 129);
            pnlLine.Location = new Point(64, 121);
            pnlLine.Name = "pnlLine";
            pnlLine.Size = new Size(308, 6);
            pnlLine.TabIndex = 8;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(16, 185, 129);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(64, 391);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(420, 50);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "ĐĂNG NHẬP";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // chkShowPass
            // 
            chkShowPass.AutoSize = true;
            chkShowPass.Font = new Font("Segoe UI", 9F);
            chkShowPass.ForeColor = Color.FromArgb(148, 163, 184);
            chkShowPass.Location = new Point(64, 351);
            chkShowPass.Name = "chkShowPass";
            chkShowPass.Size = new Size(104, 19);
            chkShowPass.TabIndex = 6;
            chkShowPass.Text = "Hiện mật khẩu";
            chkShowPass.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(30, 41, 59);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(64, 295);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(420, 29);
            txtPassword.TabIndex = 5;
            // 
            // lblPassTag
            // 
            lblPassTag.AutoSize = true;
            lblPassTag.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblPassTag.ForeColor = Color.FromArgb(148, 163, 184);
            lblPassTag.Location = new Point(64, 270);
            lblPassTag.Name = "lblPassTag";
            lblPassTag.Size = new Size(68, 15);
            lblPassTag.TabIndex = 4;
            lblPassTag.Text = "MẬT KHẨU";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(30, 41, 59);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.ForeColor = Color.White;
            txtUsername.Location = new Point(64, 215);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(420, 29);
            txtUsername.TabIndex = 3;
            // 
            // lblUserTag
            // 
            lblUserTag.AutoSize = true;
            lblUserTag.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblUserTag.ForeColor = Color.FromArgb(148, 163, 184);
            lblUserTag.Location = new Point(64, 190);
            lblUserTag.Name = "lblUserTag";
            lblUserTag.Size = new Size(102, 15);
            lblUserTag.TabIndex = 2;
            lblUserTag.Text = "TÊN ĐĂNG NHẬP";
            // 
            // lblLoginSub
            // 
            lblLoginSub.AutoSize = true;
            lblLoginSub.Font = new Font("Segoe UI", 10F);
            lblLoginSub.ForeColor = Color.FromArgb(148, 163, 184);
            lblLoginSub.Location = new Point(64, 130);
            lblLoginSub.Name = "lblLoginSub";
            lblLoginSub.Size = new Size(313, 19);
            lblLoginSub.TabIndex = 1;
            lblLoginSub.Text = "Vui lòng đăng nhập để tiếp tục sử dụng hệ thống";
            // 
            // lblLoginTitle
            // 
            lblLoginTitle.AutoSize = true;
            lblLoginTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblLoginTitle.ForeColor = Color.White;
            lblLoginTitle.Location = new Point(64, 57);
            lblLoginTitle.Name = "lblLoginTitle";
            lblLoginTitle.Size = new Size(184, 45);
            lblLoginTitle.TabIndex = 0;
            lblLoginTitle.Text = "Đăng nhập";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 600);
            Controls.Add(splitMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống chẩn đoán đột quỵ - Đăng nhập";
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            splitMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);

        }

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblBrandName;
        private System.Windows.Forms.Label lblBrandDesc;
        private System.Windows.Forms.Label lblLoginTitle;
        private System.Windows.Forms.Label lblLoginSub;
        private System.Windows.Forms.Label lblUserTag;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassTag;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkShowPass;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel pnlLine;
    }
}
