namespace StrokePredictionWinForms.Views
{
    partial class SingleCheckView
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
            pnlMain = new SplitContainer();
            lblTitleInput = new Label();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblGender = new Label();
            cboGender = new ComboBox();
            lblAge = new Label();
            txtAge = new TextBox();
            lblHypertension = new Label();
            cboHypertension = new ComboBox();
            lblHeartDisease = new Label();
            cboHeartDisease = new ComboBox();
            lblEverMarried = new Label();
            cboEverMarried = new ComboBox();
            lblWorkType = new Label();
            cboWorkType = new ComboBox();
            lblResidence = new Label();
            cboResidence = new ComboBox();
            lblGlucose = new Label();
            txtGlucose = new TextBox();
            lblBmi = new Label();
            txtBmi = new TextBox();
            lblSmoking = new Label();
            cboSmoking = new ComboBox();
            btnAnalyze = new Button();
            btnClear = new Button();
            btnSave = new Button();
            lblResultTitle = new Label();
            pnlResultBox = new Panel();
            lblRiskLevel = new Label();
            lblRiskPct = new Label();
            lblRiskMsg = new Label();
            lblDetailTitle = new Label();
            pnlDetailBox = new Panel();
            lblDetailInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)pnlMain).BeginInit();
            pnlMain.Panel1.SuspendLayout();
            pnlMain.Panel2.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlResultBox.SuspendLayout();
            pnlDetailBox.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            // 
            // pnlMain.Panel1
            // 
            pnlMain.Panel1.BackColor = Color.FromArgb(15, 23, 42);
            pnlMain.Panel1.Controls.Add(lblTitleInput);
            pnlMain.Panel1.Controls.Add(lblFullName);
            pnlMain.Panel1.Controls.Add(txtFullName);
            pnlMain.Panel1.Controls.Add(lblPhone);
            pnlMain.Panel1.Controls.Add(txtPhone);
            pnlMain.Panel1.Controls.Add(lblGender);
            pnlMain.Panel1.Controls.Add(cboGender);
            pnlMain.Panel1.Controls.Add(lblAge);
            pnlMain.Panel1.Controls.Add(txtAge);
            pnlMain.Panel1.Controls.Add(lblHypertension);
            pnlMain.Panel1.Controls.Add(cboHypertension);
            pnlMain.Panel1.Controls.Add(lblHeartDisease);
            pnlMain.Panel1.Controls.Add(cboHeartDisease);
            pnlMain.Panel1.Controls.Add(lblEverMarried);
            pnlMain.Panel1.Controls.Add(cboEverMarried);
            pnlMain.Panel1.Controls.Add(lblWorkType);
            pnlMain.Panel1.Controls.Add(cboWorkType);
            pnlMain.Panel1.Controls.Add(lblResidence);
            pnlMain.Panel1.Controls.Add(cboResidence);
            pnlMain.Panel1.Controls.Add(lblGlucose);
            pnlMain.Panel1.Controls.Add(txtGlucose);
            pnlMain.Panel1.Controls.Add(lblBmi);
            pnlMain.Panel1.Controls.Add(txtBmi);
            pnlMain.Panel1.Controls.Add(lblSmoking);
            pnlMain.Panel1.Controls.Add(cboSmoking);
            pnlMain.Panel1.Controls.Add(btnAnalyze);
            pnlMain.Panel1.Controls.Add(btnClear);
            pnlMain.Panel1.Controls.Add(btnSave);
            // 
            // pnlMain.Panel2
            // 
            pnlMain.Panel2.BackColor = Color.FromArgb(15, 23, 42);
            pnlMain.Panel2.Controls.Add(lblResultTitle);
            pnlMain.Panel2.Controls.Add(pnlResultBox);
            pnlMain.Panel2.Controls.Add(lblDetailTitle);
            pnlMain.Panel2.Controls.Add(pnlDetailBox);
            pnlMain.Size = new Size(1200, 800);
            pnlMain.SplitterDistance = 783;
            pnlMain.TabIndex = 0;
            // 
            // lblTitleInput
            // 
            lblTitleInput.AutoSize = true;
            lblTitleInput.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitleInput.ForeColor = Color.White;
            lblTitleInput.Location = new Point(20, 20);
            lblTitleInput.Name = "lblTitleInput";
            lblTitleInput.Size = new Size(247, 21);
            lblTitleInput.TabIndex = 0;
            lblTitleInput.Text = "📝 Nhập thông tin người bệnh";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 12F);
            lblFullName.ForeColor = Color.White;
            lblFullName.Location = new Point(20, 94);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(59, 21);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Họ tên:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(150, 98);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(220, 23);
            txtFullName.TabIndex = 2;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 12F);
            lblPhone.ForeColor = Color.White;
            lblPhone.Location = new Point(20, 148);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(41, 21);
            lblPhone.TabIndex = 3;
            lblPhone.Text = "SĐT:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(150, 150);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(220, 23);
            txtPhone.TabIndex = 4;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 12F);
            lblGender.ForeColor = Color.White;
            lblGender.Location = new Point(20, 213);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(73, 21);
            lblGender.TabIndex = 5;
            lblGender.Text = "Giới tính:";
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.Items.AddRange(new object[] { "Male", "Female" });
            cboGender.Location = new Point(150, 217);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(220, 23);
            cboGender.TabIndex = 6;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new Font("Segoe UI", 12F);
            lblAge.ForeColor = Color.White;
            lblAge.Location = new Point(20, 281);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(43, 21);
            lblAge.TabIndex = 7;
            lblAge.Text = "Tuổi:";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(150, 283);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(220, 23);
            txtAge.TabIndex = 8;
            // 
            // lblHypertension
            // 
            lblHypertension.AutoSize = true;
            lblHypertension.Font = new Font("Segoe UI", 12F);
            lblHypertension.ForeColor = Color.White;
            lblHypertension.Location = new Point(20, 340);
            lblHypertension.Name = "lblHypertension";
            lblHypertension.Size = new Size(104, 21);
            lblHypertension.TabIndex = 9;
            lblHypertension.Text = "Cao huyết áp:";
            // 
            // cboHypertension
            // 
            cboHypertension.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHypertension.Items.AddRange(new object[] { "Không (0)", "Có (1)" });
            cboHypertension.Location = new Point(150, 342);
            cboHypertension.Name = "cboHypertension";
            cboHypertension.Size = new Size(220, 23);
            cboHypertension.TabIndex = 10;
            // 
            // lblHeartDisease
            // 
            lblHeartDisease.AutoSize = true;
            lblHeartDisease.Font = new Font("Segoe UI", 12F);
            lblHeartDisease.ForeColor = Color.White;
            lblHeartDisease.Location = new Point(20, 410);
            lblHeartDisease.Name = "lblHeartDisease";
            lblHeartDisease.Size = new Size(75, 21);
            lblHeartDisease.TabIndex = 11;
            lblHeartDisease.Text = "Bệnh tim:";
            // 
            // cboHeartDisease
            // 
            cboHeartDisease.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHeartDisease.Items.AddRange(new object[] { "Không (0)", "Có (1)" });
            cboHeartDisease.Location = new Point(150, 412);
            cboHeartDisease.Name = "cboHeartDisease";
            cboHeartDisease.Size = new Size(220, 23);
            cboHeartDisease.TabIndex = 12;
            // 
            // lblEverMarried
            // 
            lblEverMarried.AutoSize = true;
            lblEverMarried.Font = new Font("Segoe UI", 12F);
            lblEverMarried.ForeColor = Color.White;
            lblEverMarried.Location = new Point(425, 93);
            lblEverMarried.Name = "lblEverMarried";
            lblEverMarried.Size = new Size(88, 21);
            lblEverMarried.TabIndex = 13;
            lblEverMarried.Text = "Đã kết hôn:";
            // 
            // cboEverMarried
            // 
            cboEverMarried.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEverMarried.Items.AddRange(new object[] { "Yes", "No" });
            cboEverMarried.Location = new Point(549, 96);
            cboEverMarried.Name = "cboEverMarried";
            cboEverMarried.Size = new Size(220, 23);
            cboEverMarried.TabIndex = 14;
            // 
            // lblWorkType
            // 
            lblWorkType.AutoSize = true;
            lblWorkType.Font = new Font("Segoe UI", 12F);
            lblWorkType.ForeColor = Color.White;
            lblWorkType.Location = new Point(425, 158);
            lblWorkType.Name = "lblWorkType";
            lblWorkType.Size = new Size(103, 21);
            lblWorkType.TabIndex = 15;
            lblWorkType.Text = "Nghề nghiệp:";
            // 
            // cboWorkType
            // 
            cboWorkType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWorkType.Items.AddRange(new object[] { "Private", "Self_employed", "Govt_job", "children", "Never_worked" });
            cboWorkType.Location = new Point(549, 154);
            cboWorkType.Name = "cboWorkType";
            cboWorkType.Size = new Size(220, 23);
            cboWorkType.TabIndex = 16;
            // 
            // lblResidence
            // 
            lblResidence.AutoSize = true;
            lblResidence.Font = new Font("Segoe UI", 12F);
            lblResidence.ForeColor = Color.White;
            lblResidence.Location = new Point(435, 219);
            lblResidence.Name = "lblResidence";
            lblResidence.Size = new Size(53, 21);
            lblResidence.TabIndex = 17;
            lblResidence.Text = "Nơi ở:";
            // 
            // cboResidence
            // 
            cboResidence.DropDownStyle = ComboBoxStyle.DropDownList;
            cboResidence.Items.AddRange(new object[] { "Urban", "Rural" });
            cboResidence.Location = new Point(549, 217);
            cboResidence.Name = "cboResidence";
            cboResidence.Size = new Size(220, 23);
            cboResidence.TabIndex = 18;
            // 
            // lblGlucose
            // 
            lblGlucose.AutoSize = true;
            lblGlucose.Font = new Font("Segoe UI", 12F);
            lblGlucose.ForeColor = Color.White;
            lblGlucose.Location = new Point(426, 288);
            lblGlucose.Name = "lblGlucose";
            lblGlucose.Size = new Size(102, 21);
            lblGlucose.TabIndex = 19;
            lblGlucose.Text = "Mức Glucose:";
            // 
            // txtGlucose
            // 
            txtGlucose.Location = new Point(549, 283);
            txtGlucose.Name = "txtGlucose";
            txtGlucose.Size = new Size(220, 23);
            txtGlucose.TabIndex = 20;
            // 
            // lblBmi
            // 
            lblBmi.AutoSize = true;
            lblBmi.Font = new Font("Segoe UI", 12F);
            lblBmi.ForeColor = Color.White;
            lblBmi.Location = new Point(426, 348);
            lblBmi.Name = "lblBmi";
            lblBmi.Size = new Size(87, 21);
            lblBmi.TabIndex = 21;
            lblBmi.Text = "Chỉ số BMI:";
            // 
            // txtBmi
            // 
            txtBmi.Location = new Point(549, 338);
            txtBmi.Name = "txtBmi";
            txtBmi.Size = new Size(220, 23);
            txtBmi.TabIndex = 22;
            // 
            // lblSmoking
            // 
            lblSmoking.AutoSize = true;
            lblSmoking.Font = new Font("Segoe UI", 12F);
            lblSmoking.ForeColor = Color.White;
            lblSmoking.Location = new Point(432, 410);
            lblSmoking.Name = "lblSmoking";
            lblSmoking.Size = new Size(81, 21);
            lblSmoking.TabIndex = 23;
            lblSmoking.Text = "Hút thuốc:";
            // 
            // cboSmoking
            // 
            cboSmoking.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSmoking.Items.AddRange(new object[] { "formerly_smoked", "never_smoked", "smokes", "Unknown" });
            cboSmoking.Location = new Point(549, 410);
            cboSmoking.Name = "cboSmoking";
            cboSmoking.Size = new Size(220, 23);
            cboSmoking.TabIndex = 24;
            // 
            // btnAnalyze
            // 
            btnAnalyze.BackColor = Color.FromArgb(192, 192, 255);
            btnAnalyze.Font = new Font("Segoe UI", 11.25F);
            btnAnalyze.Location = new Point(147, 477);
            btnAnalyze.Name = "btnAnalyze";
            btnAnalyze.Size = new Size(107, 96);
            btnAnalyze.TabIndex = 25;
            btnAnalyze.Text = "🔬 Phân tích";
            btnAnalyze.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(192, 192, 255);
            btnClear.Font = new Font("Segoe UI", 11.25F);
            btnClear.Location = new Point(528, 477);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(107, 96);
            btnClear.TabIndex = 26;
            btnClear.Text = "🗑️ Xóa";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(192, 192, 255);
            btnSave.Font = new Font("Segoe UI", 11.25F);
            btnSave.Location = new Point(335, 477);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 96);
            btnSave.TabIndex = 27;
            btnSave.Text = "💾 Lưu DB";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // lblResultTitle
            // 
            lblResultTitle.AutoSize = true;
            lblResultTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblResultTitle.ForeColor = Color.White;
            lblResultTitle.Location = new Point(15, 20);
            lblResultTitle.Name = "lblResultTitle";
            lblResultTitle.Size = new Size(171, 21);
            lblResultTitle.TabIndex = 0;
            lblResultTitle.Text = "📊 Kết quả Phân tích";
            // 
            // pnlResultBox
            // 
            pnlResultBox.BackColor = Color.FromArgb(30, 41, 59);
            pnlResultBox.Controls.Add(lblRiskLevel);
            pnlResultBox.Controls.Add(lblRiskPct);
            pnlResultBox.Controls.Add(lblRiskMsg);
            pnlResultBox.Location = new Point(15, 60);
            pnlResultBox.Name = "pnlResultBox";
            pnlResultBox.Size = new Size(380, 185);
            pnlResultBox.TabIndex = 1;
            // 
            // lblRiskLevel
            // 
            lblRiskLevel.AutoSize = true;
            lblRiskLevel.ForeColor = Color.FromArgb(148, 163, 184);
            lblRiskLevel.Location = new Point(15, 12);
            lblRiskLevel.Name = "lblRiskLevel";
            lblRiskLevel.Size = new Size(93, 15);
            lblRiskLevel.TabIndex = 0;
            lblRiskLevel.Text = "Chưa có kết quả";
            // 
            // lblRiskPct
            // 
            lblRiskPct.AutoSize = true;
            lblRiskPct.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
            lblRiskPct.ForeColor = Color.FromArgb(148, 163, 184);
            lblRiskPct.Location = new Point(15, 45);
            lblRiskPct.Name = "lblRiskPct";
            lblRiskPct.Size = new Size(121, 72);
            lblRiskPct.TabIndex = 1;
            lblRiskPct.Text = "--%";
            // 
            // lblRiskMsg
            // 
            lblRiskMsg.AutoSize = true;
            lblRiskMsg.ForeColor = Color.FromArgb(148, 163, 184);
            lblRiskMsg.Location = new Point(15, 125);
            lblRiskMsg.Name = "lblRiskMsg";
            lblRiskMsg.Size = new Size(221, 15);
            lblRiskMsg.TabIndex = 2;
            lblRiskMsg.Text = "Vui lòng nhập dữ liệu và nhấn phân tích.";
            // 
            // lblDetailTitle
            // 
            lblDetailTitle.AutoSize = true;
            lblDetailTitle.ForeColor = Color.White;
            lblDetailTitle.Location = new Point(15, 270);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Size = new Size(105, 15);
            lblDetailTitle.TabIndex = 2;
            lblDetailTitle.Text = "📋 Chi tiết đầu vào";
            // 
            // pnlDetailBox
            // 
            pnlDetailBox.BackColor = Color.FromArgb(30, 41, 59);
            pnlDetailBox.Controls.Add(lblDetailInfo);
            pnlDetailBox.Location = new Point(15, 300);
            pnlDetailBox.Name = "pnlDetailBox";
            pnlDetailBox.Size = new Size(380, 273);
            pnlDetailBox.TabIndex = 3;
            // 
            // lblDetailInfo
            // 
            lblDetailInfo.AutoSize = true;
            lblDetailInfo.ForeColor = Color.White;
            lblDetailInfo.Location = new Point(8, 8);
            lblDetailInfo.Name = "lblDetailInfo";
            lblDetailInfo.Size = new Size(146, 15);
            lblDetailInfo.TabIndex = 0;
            lblDetailInfo.Text = "Chưa có dữ liệu phân tích.";
            // 
            // SingleCheckView
            // 
            Controls.Add(pnlMain);
            Name = "SingleCheckView";
            Size = new Size(1200, 800);
            pnlMain.Panel1.ResumeLayout(false);
            pnlMain.Panel1.PerformLayout();
            pnlMain.Panel2.ResumeLayout(false);
            pnlMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlMain).EndInit();
            pnlMain.ResumeLayout(false);
            pnlResultBox.ResumeLayout(false);
            pnlResultBox.PerformLayout();
            pnlDetailBox.ResumeLayout(false);
            pnlDetailBox.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.SplitContainer pnlMain;
        private System.Windows.Forms.Label lblTitleInput;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label lblHypertension;
        private System.Windows.Forms.ComboBox cboHypertension;
        private System.Windows.Forms.Label lblHeartDisease;
        private System.Windows.Forms.ComboBox cboHeartDisease;
        private System.Windows.Forms.Label lblEverMarried;
        private System.Windows.Forms.ComboBox cboEverMarried;
        private System.Windows.Forms.Label lblWorkType;
        private System.Windows.Forms.ComboBox cboWorkType;
        private System.Windows.Forms.Label lblResidence;
        private System.Windows.Forms.ComboBox cboResidence;
        private System.Windows.Forms.Label lblGlucose;
        private System.Windows.Forms.TextBox txtGlucose;
        private System.Windows.Forms.Label lblBmi;
        private System.Windows.Forms.TextBox txtBmi;
        private System.Windows.Forms.Label lblSmoking;
        private System.Windows.Forms.ComboBox cboSmoking;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblResultTitle;
        private System.Windows.Forms.Panel pnlResultBox;
        private System.Windows.Forms.Label lblRiskLevel;
        private System.Windows.Forms.Label lblRiskPct;
        private System.Windows.Forms.Label lblRiskMsg;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Panel pnlDetailBox;
        private System.Windows.Forms.Label lblDetailInfo;
    }
}
