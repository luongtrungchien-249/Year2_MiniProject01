namespace StrokePredictionWinForms.Views
{
    partial class HistoryView
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            pnlFilter = new Panel();
            lblRecordCount = new Label();
            btnDeleteSelected = new Button();
            btnReset = new Button();
            btnFilter = new Button();
            dtpTo = new DateTimePicker();
            lblTo = new Label();
            dtpFrom = new DateTimePicker();
            lblFrom = new Label();
            cboResult = new ComboBox();
            lblRes = new Label();
            txtSearch = new TextBox();
            lblSearch = new Label();
            split = new SplitContainer();
            dgvHistory = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colResult = new DataGridViewTextBoxColumn();
            colConfidence = new DataGridViewTextBoxColumn();
            colTime = new DataGridViewTextBoxColumn();
            lblTitle = new Label();
            lblDetailMainTitle = new Label();
            lblDetailResultIcon = new Label();
            lblDetailResult = new Label();
            sep1 = new Panel();
            lblConfTitle = new Label();
            lblDetailConfidenceVal = new Label();
            sep2 = new Panel();
            lblF1 = new Label();
            lblDetailName = new Label();
            lblF2 = new Label();
            lblDetailTime = new Label();
            lblF3 = new Label();
            lblDetailAge = new Label();
            lblF4 = new Label();
            lblDetailGender = new Label();
            lblF5 = new Label();
            lblDetailGlucose = new Label();
            lblF6 = new Label();
            lblDetailBmi = new Label();
            lblF7 = new Label();
            lblDetailHyper = new Label();
            lblF8 = new Label();
            lblDetailHeart = new Label();
            lblF9 = new Label();
            lblDetailSmoke = new Label();
            btnDeleteRecord = new Button();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)split).BeginInit();
            split.Panel1.SuspendLayout();
            split.Panel2.SuspendLayout();
            split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.FromArgb(17, 24, 39);
            pnlFilter.Controls.Add(lblRecordCount);
            pnlFilter.Controls.Add(btnDeleteSelected);
            pnlFilter.Controls.Add(btnReset);
            pnlFilter.Controls.Add(btnFilter);
            pnlFilter.Controls.Add(dtpTo);
            pnlFilter.Controls.Add(lblTo);
            pnlFilter.Controls.Add(dtpFrom);
            pnlFilter.Controls.Add(lblFrom);
            pnlFilter.Controls.Add(cboResult);
            pnlFilter.Controls.Add(lblRes);
            pnlFilter.Controls.Add(txtSearch);
            pnlFilter.Controls.Add(lblSearch);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(0, 0);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Padding = new Padding(15, 8, 15, 8);
            pnlFilter.Size = new Size(1000, 70);
            pnlFilter.TabIndex = 1;
            // 
            // lblRecordCount
            // 
            lblRecordCount.AutoSize = true;
            lblRecordCount.Font = new Font("Segoe UI", 8F);
            lblRecordCount.ForeColor = Color.FromArgb(100, 116, 139);
            lblRecordCount.Location = new Point(15, 53);
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new Size(56, 13);
            lblRecordCount.TabIndex = 0;
            lblRecordCount.Text = "0 bản ghi";
            // 
            // btnDeleteSelected
            // 
            btnDeleteSelected.BackColor = Color.FromArgb(239, 68, 68);
            btnDeleteSelected.FlatStyle = FlatStyle.Flat;
            btnDeleteSelected.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDeleteSelected.ForeColor = Color.White;
            btnDeleteSelected.Location = new Point(786, 23);
            btnDeleteSelected.Name = "btnDeleteSelected";
            btnDeleteSelected.Size = new Size(80, 30);
            btnDeleteSelected.TabIndex = 1;
            btnDeleteSelected.Text = "🗑️ Xóa";
            btnDeleteSelected.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(51, 65, 85);
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(693, 23);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(85, 30);
            btnReset.TabIndex = 2;
            btnReset.Text = "↺ Reset";
            btnReset.UseVisualStyleBackColor = false;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.FromArgb(16, 185, 129);
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(605, 23);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(80, 30);
            btnFilter.TabIndex = 3;
            btnFilter.Text = "🔍 Lọc";
            btnFilter.UseVisualStyleBackColor = false;
            // 
            // dtpTo
            // 
            dtpTo.Font = new Font("Segoe UI", 9F);
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(455, 25);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(135, 23);
            dtpTo.TabIndex = 4;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblTo.ForeColor = Color.FromArgb(148, 163, 184);
            lblTo.Location = new Point(455, 8);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(30, 13);
            lblTo.TabIndex = 5;
            lblTo.Text = "ĐẾN";
            // 
            // dtpFrom
            // 
            dtpFrom.Font = new Font("Segoe UI", 9F);
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(305, 25);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(135, 23);
            dtpFrom.TabIndex = 6;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblFrom.ForeColor = Color.FromArgb(148, 163, 184);
            lblFrom.Location = new Point(305, 8);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(56, 13);
            lblFrom.TabIndex = 7;
            lblFrom.Text = "TỪ NGÀY";
            // 
            // cboResult
            // 
            cboResult.BackColor = Color.FromArgb(30, 41, 59);
            cboResult.DropDownStyle = ComboBoxStyle.DropDownList;
            cboResult.FlatStyle = FlatStyle.Flat;
            cboResult.Font = new Font("Segoe UI", 9F);
            cboResult.ForeColor = Color.White;
            cboResult.Items.AddRange(new object[] { "Tất cả", "Đột quỵ", "Bình thường" });
            cboResult.Location = new Point(170, 25);
            cboResult.Name = "cboResult";
            cboResult.Size = new Size(120, 23);
            cboResult.TabIndex = 8;
            // 
            // lblRes
            // 
            lblRes.AutoSize = true;
            lblRes.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblRes.ForeColor = Color.FromArgb(148, 163, 184);
            lblRes.Location = new Point(170, 8);
            lblRes.Name = "lblRes";
            lblRes.Size = new Size(53, 13);
            lblRes.TabIndex = 9;
            lblRes.Text = "KẾT QUẢ";
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(30, 41, 59);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(15, 25);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(140, 23);
            txtSearch.TabIndex = 10;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(148, 163, 184);
            lblSearch.Location = new Point(15, 8);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(57, 13);
            lblSearch.TabIndex = 11;
            lblSearch.Text = "TÌM KIẾM";
            // 
            // split
            // 
            split.BackColor = Color.FromArgb(11, 17, 30);
            split.Dock = DockStyle.Fill;
            split.FixedPanel = FixedPanel.Panel2;
            split.Location = new Point(0, 70);
            split.Name = "split";
            // 
            // split.Panel1
            // 
            split.Panel1.BackColor = Color.FromArgb(17, 24, 39);
            split.Panel1.Controls.Add(dgvHistory);
            split.Panel1.Controls.Add(lblTitle);
            // 
            // split.Panel2
            // 
            split.Panel2.AutoScroll = true;
            split.Panel2.BackColor = Color.FromArgb(17, 24, 39);
            split.Panel2.Controls.Add(lblDetailMainTitle);
            split.Panel2.Controls.Add(lblDetailResultIcon);
            split.Panel2.Controls.Add(lblDetailResult);
            split.Panel2.Controls.Add(sep1);
            split.Panel2.Controls.Add(lblConfTitle);
            split.Panel2.Controls.Add(lblDetailConfidenceVal);
            split.Panel2.Controls.Add(sep2);
            split.Panel2.Controls.Add(lblF1);
            split.Panel2.Controls.Add(lblDetailName);
            split.Panel2.Controls.Add(lblF2);
            split.Panel2.Controls.Add(lblDetailTime);
            split.Panel2.Controls.Add(lblF3);
            split.Panel2.Controls.Add(lblDetailAge);
            split.Panel2.Controls.Add(lblF4);
            split.Panel2.Controls.Add(lblDetailGender);
            split.Panel2.Controls.Add(lblF5);
            split.Panel2.Controls.Add(lblDetailGlucose);
            split.Panel2.Controls.Add(lblF6);
            split.Panel2.Controls.Add(lblDetailBmi);
            split.Panel2.Controls.Add(lblF7);
            split.Panel2.Controls.Add(lblDetailHyper);
            split.Panel2.Controls.Add(lblF8);
            split.Panel2.Controls.Add(lblDetailHeart);
            split.Panel2.Controls.Add(lblF9);
            split.Panel2.Controls.Add(lblDetailSmoke);
            split.Panel2.Controls.Add(btnDeleteRecord);
            split.Panel2.Padding = new Padding(15);
            split.Panel2.Paint += split_Panel2_Paint;
            split.Size = new Size(1000, 530);
            split.SplitterDistance = 620;
            split.TabIndex = 0;
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(22, 30, 46);
            dgvHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.BackgroundColor = Color.FromArgb(17, 24, 39);
            dgvHistory.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvHistory.ColumnHeadersHeight = 35;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHistory.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colResult, colConfidence, colTime });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(17, 24, 39);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvHistory.DefaultCellStyle = dataGridViewCellStyle6;
            dgvHistory.Dock = DockStyle.Fill;
            dgvHistory.EnableHeadersVisualStyles = false;
            dgvHistory.GridColor = Color.FromArgb(51, 65, 85);
            dgvHistory.Location = new Point(0, 30);
            dgvHistory.MultiSelect = false;
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.Size = new Size(620, 500);
            dgvHistory.TabIndex = 0;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colName
            // 
            colName.HeaderText = "TÊN BỆNH NHÂN";
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colResult
            // 
            colResult.HeaderText = "KẾT QUẢ";
            colResult.Name = "colResult";
            colResult.ReadOnly = true;
            // 
            // colConfidence
            // 
            colConfidence.HeaderText = "ĐỘ TIN CẬY";
            colConfidence.Name = "colConfidence";
            colConfidence.ReadOnly = true;
            // 
            // colTime
            // 
            colTime.HeaderText = "THỜI GIAN";
            colTime.Name = "colTime";
            colTime.ReadOnly = true;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(10, 8, 0, 0);
            lblTitle.Size = new Size(620, 30);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "📋 LỊCH SỬ QUÉT";
            // 
            // lblDetailMainTitle
            // 
            lblDetailMainTitle.AutoSize = true;
            lblDetailMainTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailMainTitle.ForeColor = Color.White;
            lblDetailMainTitle.Location = new Point(15, 15);
            lblDetailMainTitle.Name = "lblDetailMainTitle";
            lblDetailMainTitle.Size = new Size(141, 20);
            lblDetailMainTitle.TabIndex = 0;
            lblDetailMainTitle.Text = "🔍 Chi tiết bản ghi";
            // 
            // lblDetailResultIcon
            // 
            lblDetailResultIcon.AutoSize = true;
            lblDetailResultIcon.Font = new Font("Segoe UI", 30F);
            lblDetailResultIcon.Location = new Point(22, 39);
            lblDetailResultIcon.Name = "lblDetailResultIcon";
            lblDetailResultIcon.Size = new Size(78, 54);
            lblDetailResultIcon.TabIndex = 1;
            lblDetailResultIcon.Text = "❓";
            // 
            // lblDetailResult
            // 
            lblDetailResult.AutoSize = true;
            lblDetailResult.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDetailResult.ForeColor = Color.FromArgb(148, 163, 184);
            lblDetailResult.Location = new Point(70, 62);
            lblDetailResult.Name = "lblDetailResult";
            lblDetailResult.Size = new Size(31, 25);
            lblDetailResult.TabIndex = 2;
            lblDetailResult.Text = "—";
            // 
            // sep1
            // 
            sep1.BackColor = Color.FromArgb(51, 65, 85);
            sep1.Location = new Point(15, 115);
            sep1.Name = "sep1";
            sep1.Size = new Size(280, 1);
            sep1.TabIndex = 3;
            // 
            // lblConfTitle
            // 
            lblConfTitle.AutoSize = true;
            lblConfTitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblConfTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblConfTitle.Location = new Point(18, 132);
            lblConfTitle.Name = "lblConfTitle";
            lblConfTitle.Size = new Size(69, 13);
            lblConfTitle.TabIndex = 4;
            lblConfTitle.Text = "ĐỘ TIN CẬY";
            // 
            // lblDetailConfidenceVal
            // 
            lblDetailConfidenceVal.AutoSize = true;
            lblDetailConfidenceVal.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblDetailConfidenceVal.ForeColor = Color.FromArgb(16, 185, 129);
            lblDetailConfidenceVal.Location = new Point(41, 145);
            lblDetailConfidenceVal.Name = "lblDetailConfidenceVal";
            lblDetailConfidenceVal.Size = new Size(98, 37);
            lblDetailConfidenceVal.TabIndex = 5;
            lblDetailConfidenceVal.Text = "--.-- %";
            // 
            // sep2
            // 
            sep2.BackColor = Color.FromArgb(51, 65, 85);
            sep2.Location = new Point(15, 190);
            sep2.Name = "sep2";
            sep2.Size = new Size(280, 1);
            sep2.TabIndex = 6;
            // 
            // lblF1
            // 
            lblF1.AutoSize = true;
            lblF1.Font = new Font("Segoe UI", 8F);
            lblF1.ForeColor = Color.FromArgb(100, 116, 139);
            lblF1.Location = new Point(41, 201);
            lblF1.Name = "lblF1";
            lblF1.Size = new Size(85, 13);
            lblF1.TabIndex = 7;
            lblF1.Text = "Tên bệnh nhân";
            // 
            // lblDetailName
            // 
            lblDetailName.AutoSize = true;
            lblDetailName.Font = new Font("Segoe UI", 9F);
            lblDetailName.ForeColor = Color.White;
            lblDetailName.Location = new Point(305, 200);
            lblDetailName.Name = "lblDetailName";
            lblDetailName.Size = new Size(19, 15);
            lblDetailName.TabIndex = 8;
            lblDetailName.Text = "—";
            // 
            // lblF2
            // 
            lblF2.AutoSize = true;
            lblF2.Font = new Font("Segoe UI", 8F);
            lblF2.ForeColor = Color.FromArgb(100, 116, 139);
            lblF2.Location = new Point(41, 225);
            lblF2.Name = "lblF2";
            lblF2.Size = new Size(56, 13);
            lblF2.TabIndex = 9;
            lblF2.Text = "Thời gian";
            // 
            // lblDetailTime
            // 
            lblDetailTime.AutoSize = true;
            lblDetailTime.Font = new Font("Segoe UI", 9F);
            lblDetailTime.ForeColor = Color.White;
            lblDetailTime.Location = new Point(305, 224);
            lblDetailTime.Name = "lblDetailTime";
            lblDetailTime.Size = new Size(19, 15);
            lblDetailTime.TabIndex = 10;
            lblDetailTime.Text = "—";
            // 
            // lblF3
            // 
            lblF3.AutoSize = true;
            lblF3.Font = new Font("Segoe UI", 8F);
            lblF3.ForeColor = Color.FromArgb(100, 116, 139);
            lblF3.Location = new Point(41, 250);
            lblF3.Name = "lblF3";
            lblF3.Size = new Size(30, 13);
            lblF3.TabIndex = 11;
            lblF3.Text = "Tuổi";
            // 
            // lblDetailAge
            // 
            lblDetailAge.AutoSize = true;
            lblDetailAge.Font = new Font("Segoe UI", 9F);
            lblDetailAge.ForeColor = Color.White;
            lblDetailAge.Location = new Point(305, 248);
            lblDetailAge.Name = "lblDetailAge";
            lblDetailAge.Size = new Size(19, 15);
            lblDetailAge.TabIndex = 12;
            lblDetailAge.Text = "—";
            // 
            // lblF4
            // 
            lblF4.AutoSize = true;
            lblF4.Font = new Font("Segoe UI", 8F);
            lblF4.ForeColor = Color.FromArgb(100, 116, 139);
            lblF4.Location = new Point(41, 274);
            lblF4.Name = "lblF4";
            lblF4.Size = new Size(52, 13);
            lblF4.TabIndex = 13;
            lblF4.Text = "Giới tính";
            // 
            // lblDetailGender
            // 
            lblDetailGender.AutoSize = true;
            lblDetailGender.Font = new Font("Segoe UI", 9F);
            lblDetailGender.ForeColor = Color.White;
            lblDetailGender.Location = new Point(305, 274);
            lblDetailGender.Name = "lblDetailGender";
            lblDetailGender.Size = new Size(19, 15);
            lblDetailGender.TabIndex = 14;
            lblDetailGender.Text = "—";
            // 
            // lblF5
            // 
            lblF5.AutoSize = true;
            lblF5.Font = new Font("Segoe UI", 8F);
            lblF5.ForeColor = Color.FromArgb(100, 116, 139);
            lblF5.Location = new Point(41, 296);
            lblF5.Name = "lblF5";
            lblF5.Size = new Size(48, 13);
            lblF5.TabIndex = 15;
            lblF5.Text = "Glucose";
            // 
            // lblDetailGlucose
            // 
            lblDetailGlucose.AutoSize = true;
            lblDetailGlucose.Font = new Font("Segoe UI", 9F);
            lblDetailGlucose.ForeColor = Color.White;
            lblDetailGlucose.Location = new Point(305, 296);
            lblDetailGlucose.Name = "lblDetailGlucose";
            lblDetailGlucose.Size = new Size(19, 15);
            lblDetailGlucose.TabIndex = 16;
            lblDetailGlucose.Text = "—";
            // 
            // lblF6
            // 
            lblF6.AutoSize = true;
            lblF6.Font = new Font("Segoe UI", 8F);
            lblF6.ForeColor = Color.FromArgb(100, 116, 139);
            lblF6.Location = new Point(41, 318);
            lblF6.Name = "lblF6";
            lblF6.Size = new Size(26, 13);
            lblF6.TabIndex = 17;
            lblF6.Text = "BMI";
            // 
            // lblDetailBmi
            // 
            lblDetailBmi.AutoSize = true;
            lblDetailBmi.Font = new Font("Segoe UI", 9F);
            lblDetailBmi.ForeColor = Color.White;
            lblDetailBmi.Location = new Point(305, 318);
            lblDetailBmi.Name = "lblDetailBmi";
            lblDetailBmi.Size = new Size(19, 15);
            lblDetailBmi.TabIndex = 18;
            lblDetailBmi.Text = "—";
            // 
            // lblF7
            // 
            lblF7.AutoSize = true;
            lblF7.Font = new Font("Segoe UI", 8F);
            lblF7.ForeColor = Color.FromArgb(100, 116, 139);
            lblF7.Location = new Point(41, 344);
            lblF7.Name = "lblF7";
            lblF7.Size = new Size(74, 13);
            lblF7.TabIndex = 19;
            lblF7.Text = "Huyết áp cao";
            // 
            // lblDetailHyper
            // 
            lblDetailHyper.AutoSize = true;
            lblDetailHyper.Font = new Font("Segoe UI", 9F);
            lblDetailHyper.ForeColor = Color.White;
            lblDetailHyper.Location = new Point(305, 344);
            lblDetailHyper.Name = "lblDetailHyper";
            lblDetailHyper.Size = new Size(19, 15);
            lblDetailHyper.TabIndex = 20;
            lblDetailHyper.Text = "—";
            // 
            // lblF8
            // 
            lblF8.AutoSize = true;
            lblF8.Font = new Font("Segoe UI", 8F);
            lblF8.ForeColor = Color.FromArgb(100, 116, 139);
            lblF8.Location = new Point(41, 370);
            lblF8.Name = "lblF8";
            lblF8.Size = new Size(52, 13);
            lblF8.TabIndex = 21;
            lblF8.Text = "Bệnh tim";
            // 
            // lblDetailHeart
            // 
            lblDetailHeart.AutoSize = true;
            lblDetailHeart.Font = new Font("Segoe UI", 9F);
            lblDetailHeart.ForeColor = Color.White;
            lblDetailHeart.Location = new Point(305, 368);
            lblDetailHeart.Name = "lblDetailHeart";
            lblDetailHeart.Size = new Size(19, 15);
            lblDetailHeart.TabIndex = 22;
            lblDetailHeart.Text = "—";
            // 
            // lblF9
            // 
            lblF9.AutoSize = true;
            lblF9.Font = new Font("Segoe UI", 8F);
            lblF9.ForeColor = Color.FromArgb(100, 116, 139);
            lblF9.Location = new Point(41, 392);
            lblF9.Name = "lblF9";
            lblF9.Size = new Size(59, 13);
            lblF9.TabIndex = 23;
            lblF9.Text = "Hút thuốc";
            // 
            // lblDetailSmoke
            // 
            lblDetailSmoke.AutoSize = true;
            lblDetailSmoke.Font = new Font("Segoe UI", 9F);
            lblDetailSmoke.ForeColor = Color.White;
            lblDetailSmoke.Location = new Point(305, 390);
            lblDetailSmoke.Name = "lblDetailSmoke";
            lblDetailSmoke.Size = new Size(19, 15);
            lblDetailSmoke.TabIndex = 24;
            lblDetailSmoke.Text = "—";
            // 
            // btnDeleteRecord
            // 
            btnDeleteRecord.BackColor = Color.FromArgb(239, 68, 68);
            btnDeleteRecord.FlatStyle = FlatStyle.Flat;
            btnDeleteRecord.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDeleteRecord.ForeColor = Color.White;
            btnDeleteRecord.Location = new Point(44, 438);
            btnDeleteRecord.Name = "btnDeleteRecord";
            btnDeleteRecord.Size = new Size(297, 34);
            btnDeleteRecord.TabIndex = 25;
            btnDeleteRecord.Text = "🗑️  Xóa bản ghi";
            btnDeleteRecord.UseVisualStyleBackColor = false;
            // 
            // HistoryView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(split);
            Controls.Add(pnlFilter);
            Name = "HistoryView";
            Size = new Size(1000, 600);
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            split.Panel1.ResumeLayout(false);
            split.Panel2.ResumeLayout(false);
            split.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)split).EndInit();
            split.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblRes;
        private System.Windows.Forms.ComboBox cboResult;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Label lblRecordCount;
        
        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConfidence;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        
        private System.Windows.Forms.Label lblDetailMainTitle;
        private System.Windows.Forms.Label lblDetailResultIcon;
        private System.Windows.Forms.Label lblDetailResult;
        private System.Windows.Forms.Panel sep1;
        private System.Windows.Forms.Label lblConfTitle;
        private System.Windows.Forms.Label lblDetailConfidenceVal;
        private System.Windows.Forms.Panel sep2;
        
        private System.Windows.Forms.Label lblF1; private System.Windows.Forms.Label lblDetailName;
        private System.Windows.Forms.Label lblF2; private System.Windows.Forms.Label lblDetailTime;
        private System.Windows.Forms.Label lblF3; private System.Windows.Forms.Label lblDetailAge;
        private System.Windows.Forms.Label lblF4; private System.Windows.Forms.Label lblDetailGender;
        private System.Windows.Forms.Label lblF5; private System.Windows.Forms.Label lblDetailGlucose;
        private System.Windows.Forms.Label lblF6; private System.Windows.Forms.Label lblDetailBmi;
        private System.Windows.Forms.Label lblF7; private System.Windows.Forms.Label lblDetailHyper;
        private System.Windows.Forms.Label lblF8; private System.Windows.Forms.Label lblDetailHeart;
        private System.Windows.Forms.Label lblF9; private System.Windows.Forms.Label lblDetailSmoke;
        
        private System.Windows.Forms.Button btnDeleteRecord;
    }
}
