namespace StrokePredictionWinForms.Views
{
    partial class BatchScanView
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
            pnlDropZone = new Panel();
            pnlBtnWrap = new Panel();
            btnBrowse = new Button();
            lblDropSub = new Label();
            lblDropTitle = new Label();
            lblDropIcon = new Label();
            pnlActions = new Panel();
            lblFileInfo = new Label();
            btnStartScan = new Button();
            btnStopScan = new Button();
            btnExportResults = new Button();
            btnClearAll = new Button();
            pnlProgress = new Panel();
            lblScanStatus = new Label();
            lblScanPct = new Label();
            progressBar = new ProgressBar();
            lblProgressMsg = new Label();
            tlpStats = new TableLayoutPanel();
            pnlStat1 = new Panel();
            lblIcon1 = new Label();
            lblStatTotalVal = new Label();
            lblTitle1 = new Label();
            pnlStat2 = new Panel();
            lblIcon2 = new Label();
            lblStatStrokeVal = new Label();
            lblTitle2 = new Label();
            pnlStat3 = new Panel();
            lblIcon3 = new Label();
            lblStatNormalVal = new Label();
            lblTitle3 = new Label();
            pnlStat4 = new Panel();
            lblIcon4 = new Label();
            lblStatRateVal = new Label();
            lblTitle4 = new Label();
            pnlResults = new Panel();
            dgvResults = new DataGridView();
            lblResultTitle = new Label();
            pnlDropZone.SuspendLayout();
            pnlBtnWrap.SuspendLayout();
            pnlActions.SuspendLayout();
            pnlProgress.SuspendLayout();
            tlpStats.SuspendLayout();
            pnlStat1.SuspendLayout();
            pnlStat2.SuspendLayout();
            pnlStat3.SuspendLayout();
            pnlStat4.SuspendLayout();
            pnlResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // pnlDropZone
            // 
            pnlDropZone.AllowDrop = true;
            pnlDropZone.BackColor = Color.FromArgb(17, 24, 39);
            pnlDropZone.Controls.Add(pnlBtnWrap);
            pnlDropZone.Controls.Add(lblDropSub);
            pnlDropZone.Controls.Add(lblDropTitle);
            pnlDropZone.Controls.Add(lblDropIcon);
            pnlDropZone.Cursor = Cursors.Hand;
            pnlDropZone.Dock = DockStyle.Top;
            pnlDropZone.Location = new Point(0, 0);
            pnlDropZone.Margin = new Padding(0, 0, 0, 8);
            pnlDropZone.Name = "pnlDropZone";
            pnlDropZone.Size = new Size(1000, 140);
            pnlDropZone.TabIndex = 0;
            // 
            // pnlBtnWrap
            // 
            pnlBtnWrap.Controls.Add(btnBrowse);
            pnlBtnWrap.Dock = DockStyle.Top;
            pnlBtnWrap.Location = new Point(0, 105);
            pnlBtnWrap.Name = "pnlBtnWrap";
            pnlBtnWrap.Size = new Size(1000, 38);
            pnlBtnWrap.TabIndex = 0;
            // 
            // btnBrowse
            // 
            btnBrowse.Anchor = AnchorStyles.Top;
            btnBrowse.BackColor = Color.FromArgb(30, 41, 59);
            btnBrowse.Cursor = Cursors.Hand;
            btnBrowse.FlatAppearance.BorderColor = Color.FromArgb(51, 65, 85);
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBrowse.ForeColor = Color.FromArgb(16, 185, 129);
            btnBrowse.Location = new Point(422, 1);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(150, 32);
            btnBrowse.TabIndex = 0;
            btnBrowse.Text = "📁  Chọn file CSV";
            btnBrowse.UseVisualStyleBackColor = false;
            // 
            // lblDropSub
            // 
            lblDropSub.Dock = DockStyle.Top;
            lblDropSub.Font = new Font("Segoe UI", 8.5F);
            lblDropSub.ForeColor = Color.FromArgb(148, 163, 184);
            lblDropSub.Location = new Point(0, 78);
            lblDropSub.Name = "lblDropSub";
            lblDropSub.Size = new Size(1000, 27);
            lblDropSub.TabIndex = 1;
            lblDropSub.Text = "hoặc nhấn nút bên dưới để chọn file  ·  Định dạng: .csv  ·  Tối đa 10,000 dòng";
            lblDropSub.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDropTitle
            // 
            lblDropTitle.Dock = DockStyle.Top;
            lblDropTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblDropTitle.ForeColor = Color.White;
            lblDropTitle.Location = new Point(0, 50);
            lblDropTitle.Name = "lblDropTitle";
            lblDropTitle.Size = new Size(1000, 28);
            lblDropTitle.TabIndex = 2;
            lblDropTitle.Text = "Kéo thả file CSV vào đây";
            lblDropTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDropIcon
            // 
            lblDropIcon.Dock = DockStyle.Top;
            lblDropIcon.Font = new Font("Segoe UI", 28F);
            lblDropIcon.ForeColor = Color.FromArgb(16, 185, 129);
            lblDropIcon.Location = new Point(0, 0);
            lblDropIcon.Name = "lblDropIcon";
            lblDropIcon.Size = new Size(1000, 50);
            lblDropIcon.TabIndex = 3;
            lblDropIcon.Text = "📂";
            lblDropIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlActions
            // 
            pnlActions.BackColor = Color.FromArgb(17, 24, 39);
            pnlActions.Controls.Add(lblFileInfo);
            pnlActions.Controls.Add(btnStartScan);
            pnlActions.Controls.Add(btnStopScan);
            pnlActions.Controls.Add(btnExportResults);
            pnlActions.Controls.Add(btnClearAll);
            pnlActions.Dock = DockStyle.Top;
            pnlActions.Location = new Point(0, 140);
            pnlActions.Name = "pnlActions";
            pnlActions.Padding = new Padding(10, 5, 10, 5);
            pnlActions.Size = new Size(1000, 42);
            pnlActions.TabIndex = 1;
            // 
            // lblFileInfo
            // 
            lblFileInfo.AutoSize = true;
            lblFileInfo.Font = new Font("Segoe UI", 9F);
            lblFileInfo.ForeColor = Color.FromArgb(148, 163, 184);
            lblFileInfo.Location = new Point(10, 11);
            lblFileInfo.Name = "lblFileInfo";
            lblFileInfo.Size = new Size(137, 15);
            lblFileInfo.TabIndex = 0;
            lblFileInfo.Text = "Chưa tải file — 0 bản ghi";
            // 
            // btnStartScan
            // 
            btnStartScan.BackColor = Color.FromArgb(16, 185, 129);
            btnStartScan.Cursor = Cursors.Hand;
            btnStartScan.FlatStyle = FlatStyle.Flat;
            btnStartScan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnStartScan.ForeColor = Color.White;
            btnStartScan.Location = new Point(280, 4);
            btnStartScan.Name = "btnStartScan";
            btnStartScan.Size = new Size(160, 32);
            btnStartScan.TabIndex = 1;
            btnStartScan.Text = "▶  BẮT ĐẦU QUÉT";
            btnStartScan.UseVisualStyleBackColor = false;
            // 
            // btnStopScan
            // 
            btnStopScan.BackColor = Color.FromArgb(239, 68, 68);
            btnStopScan.Cursor = Cursors.Hand;
            btnStopScan.Enabled = false;
            btnStopScan.FlatStyle = FlatStyle.Flat;
            btnStopScan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnStopScan.ForeColor = Color.White;
            btnStopScan.Location = new Point(448, 4);
            btnStopScan.Name = "btnStopScan";
            btnStopScan.Size = new Size(90, 32);
            btnStopScan.TabIndex = 2;
            btnStopScan.Text = "⏹  Dừng";
            btnStopScan.UseVisualStyleBackColor = false;
            // 
            // btnExportResults
            // 
            btnExportResults.BackColor = Color.FromArgb(51, 65, 85);
            btnExportResults.Cursor = Cursors.Hand;
            btnExportResults.FlatStyle = FlatStyle.Flat;
            btnExportResults.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExportResults.ForeColor = Color.White;
            btnExportResults.Location = new Point(546, 4);
            btnExportResults.Name = "btnExportResults";
            btnExportResults.Size = new Size(115, 32);
            btnExportResults.TabIndex = 3;
            btnExportResults.Text = "📊  Xuất CSV";
            btnExportResults.UseVisualStyleBackColor = false;
            // 
            // btnClearAll
            // 
            btnClearAll.BackColor = Color.FromArgb(51, 65, 85);
            btnClearAll.Cursor = Cursors.Hand;
            btnClearAll.FlatStyle = FlatStyle.Flat;
            btnClearAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearAll.ForeColor = Color.White;
            btnClearAll.Location = new Point(669, 4);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(120, 32);
            btnClearAll.TabIndex = 4;
            btnClearAll.Text = "🗑️  Xóa tất cả";
            btnClearAll.UseVisualStyleBackColor = false;
            // 
            // pnlProgress
            // 
            pnlProgress.BackColor = Color.FromArgb(17, 24, 39);
            pnlProgress.Controls.Add(lblScanStatus);
            pnlProgress.Controls.Add(lblScanPct);
            pnlProgress.Controls.Add(progressBar);
            pnlProgress.Controls.Add(lblProgressMsg);
            pnlProgress.Dock = DockStyle.Top;
            pnlProgress.Location = new Point(0, 182);
            pnlProgress.Name = "pnlProgress";
            pnlProgress.Padding = new Padding(10, 5, 10, 5);
            pnlProgress.Size = new Size(1000, 55);
            pnlProgress.TabIndex = 2;
            // 
            // lblScanStatus
            // 
            lblScanStatus.AutoSize = true;
            lblScanStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblScanStatus.ForeColor = Color.FromArgb(148, 163, 184);
            lblScanStatus.Location = new Point(10, 5);
            lblScanStatus.Name = "lblScanStatus";
            lblScanStatus.Size = new Size(90, 15);
            lblScanStatus.TabIndex = 0;
            lblScanStatus.Text = "⏸️ CHƯA QUÉT";
            // 
            // lblScanPct
            // 
            lblScanPct.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblScanPct.AutoSize = true;
            lblScanPct.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblScanPct.ForeColor = Color.FromArgb(148, 163, 184);
            lblScanPct.Location = new Point(950, 5);
            lblScanPct.Name = "lblScanPct";
            lblScanPct.Size = new Size(24, 15);
            lblScanPct.TabIndex = 1;
            lblScanPct.Text = "0%";
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(10, 25);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(980, 8);
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.TabIndex = 2;
            // 
            // lblProgressMsg
            // 
            lblProgressMsg.AutoSize = true;
            lblProgressMsg.Font = new Font("Segoe UI", 8F);
            lblProgressMsg.ForeColor = Color.FromArgb(100, 116, 139);
            lblProgressMsg.Location = new Point(10, 37);
            lblProgressMsg.Name = "lblProgressMsg";
            lblProgressMsg.Size = new Size(54, 13);
            lblProgressMsg.TabIndex = 3;
            lblProgressMsg.Text = "Sẵn sàng";
            // 
            // tlpStats
            // 
            tlpStats.BackColor = Color.Transparent;
            tlpStats.ColumnCount = 4;
            tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpStats.Controls.Add(pnlStat1, 0, 0);
            tlpStats.Controls.Add(pnlStat2, 1, 0);
            tlpStats.Controls.Add(pnlStat3, 2, 0);
            tlpStats.Controls.Add(pnlStat4, 3, 0);
            tlpStats.Dock = DockStyle.Top;
            tlpStats.Location = new Point(0, 237);
            tlpStats.Margin = new Padding(0, 5, 0, 5);
            tlpStats.Name = "tlpStats";
            tlpStats.RowCount = 1;
            tlpStats.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpStats.Size = new Size(1000, 65);
            tlpStats.TabIndex = 3;
            // 
            // pnlStat1
            // 
            pnlStat1.BackColor = Color.FromArgb(17, 24, 39);
            pnlStat1.Controls.Add(lblIcon1);
            pnlStat1.Controls.Add(lblStatTotalVal);
            pnlStat1.Controls.Add(lblTitle1);
            pnlStat1.Dock = DockStyle.Fill;
            pnlStat1.Location = new Point(0, 0);
            pnlStat1.Margin = new Padding(0, 0, 4, 0);
            pnlStat1.Name = "pnlStat1";
            pnlStat1.Size = new Size(246, 65);
            pnlStat1.TabIndex = 0;
            // 
            // lblIcon1
            // 
            lblIcon1.AutoSize = true;
            lblIcon1.Font = new Font("Segoe UI", 18F);
            lblIcon1.Location = new Point(10, 10);
            lblIcon1.Name = "lblIcon1";
            lblIcon1.Size = new Size(47, 32);
            lblIcon1.TabIndex = 0;
            lblIcon1.Text = "📋";
            // 
            // lblStatTotalVal
            // 
            lblStatTotalVal.AutoSize = true;
            lblStatTotalVal.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblStatTotalVal.ForeColor = Color.FromArgb(59, 130, 246);
            lblStatTotalVal.Location = new Point(50, 10);
            lblStatTotalVal.Name = "lblStatTotalVal";
            lblStatTotalVal.Size = new Size(28, 32);
            lblStatTotalVal.TabIndex = 1;
            lblStatTotalVal.Text = "0";
            // 
            // lblTitle1
            // 
            lblTitle1.AutoSize = true;
            lblTitle1.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblTitle1.ForeColor = Color.FromArgb(148, 163, 184);
            lblTitle1.Location = new Point(10, 45);
            lblTitle1.Name = "lblTitle1";
            lblTitle1.Size = new Size(79, 12);
            lblTitle1.TabIndex = 2;
            lblTitle1.Text = "TỔNG BẢN GHI";
            // 
            // pnlStat2
            // 
            pnlStat2.BackColor = Color.FromArgb(17, 24, 39);
            pnlStat2.Controls.Add(lblIcon2);
            pnlStat2.Controls.Add(lblStatStrokeVal);
            pnlStat2.Controls.Add(lblTitle2);
            pnlStat2.Dock = DockStyle.Fill;
            pnlStat2.Location = new Point(254, 0);
            pnlStat2.Margin = new Padding(4, 0, 4, 0);
            pnlStat2.Name = "pnlStat2";
            pnlStat2.Size = new Size(242, 65);
            pnlStat2.TabIndex = 1;
            // 
            // lblIcon2
            // 
            lblIcon2.AutoSize = true;
            lblIcon2.Font = new Font("Segoe UI", 18F);
            lblIcon2.Location = new Point(10, 10);
            lblIcon2.Name = "lblIcon2";
            lblIcon2.Size = new Size(47, 32);
            lblIcon2.TabIndex = 0;
            lblIcon2.Text = "🔴";
            // 
            // lblStatStrokeVal
            // 
            lblStatStrokeVal.AutoSize = true;
            lblStatStrokeVal.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblStatStrokeVal.ForeColor = Color.FromArgb(239, 68, 68);
            lblStatStrokeVal.Location = new Point(50, 10);
            lblStatStrokeVal.Name = "lblStatStrokeVal";
            lblStatStrokeVal.Size = new Size(28, 32);
            lblStatStrokeVal.TabIndex = 1;
            lblStatStrokeVal.Text = "0";
            // 
            // lblTitle2
            // 
            lblTitle2.AutoSize = true;
            lblTitle2.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblTitle2.ForeColor = Color.FromArgb(148, 163, 184);
            lblTitle2.Location = new Point(10, 45);
            lblTitle2.Name = "lblTitle2";
            lblTitle2.Size = new Size(50, 12);
            lblTitle2.TabIndex = 2;
            lblTitle2.Text = "ĐỘT QUỴ";
            // 
            // pnlStat3
            // 
            pnlStat3.BackColor = Color.FromArgb(17, 24, 39);
            pnlStat3.Controls.Add(lblIcon3);
            pnlStat3.Controls.Add(lblStatNormalVal);
            pnlStat3.Controls.Add(lblTitle3);
            pnlStat3.Dock = DockStyle.Fill;
            pnlStat3.Location = new Point(504, 0);
            pnlStat3.Margin = new Padding(4, 0, 4, 0);
            pnlStat3.Name = "pnlStat3";
            pnlStat3.Size = new Size(242, 65);
            pnlStat3.TabIndex = 2;
            // 
            // lblIcon3
            // 
            lblIcon3.AutoSize = true;
            lblIcon3.Font = new Font("Segoe UI", 18F);
            lblIcon3.Location = new Point(10, 10);
            lblIcon3.Name = "lblIcon3";
            lblIcon3.Size = new Size(47, 32);
            lblIcon3.TabIndex = 0;
            lblIcon3.Text = "✅";
            // 
            // lblStatNormalVal
            // 
            lblStatNormalVal.AutoSize = true;
            lblStatNormalVal.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblStatNormalVal.ForeColor = Color.FromArgb(34, 197, 94);
            lblStatNormalVal.Location = new Point(50, 10);
            lblStatNormalVal.Name = "lblStatNormalVal";
            lblStatNormalVal.Size = new Size(28, 32);
            lblStatNormalVal.TabIndex = 1;
            lblStatNormalVal.Text = "0";
            // 
            // lblTitle3
            // 
            lblTitle3.AutoSize = true;
            lblTitle3.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblTitle3.ForeColor = Color.FromArgb(148, 163, 184);
            lblTitle3.Location = new Point(10, 45);
            lblTitle3.Name = "lblTitle3";
            lblTitle3.Size = new Size(78, 12);
            lblTitle3.TabIndex = 2;
            lblTitle3.Text = "BÌNH THƯỜNG";
            // 
            // pnlStat4
            // 
            pnlStat4.BackColor = Color.FromArgb(17, 24, 39);
            pnlStat4.Controls.Add(lblIcon4);
            pnlStat4.Controls.Add(lblStatRateVal);
            pnlStat4.Controls.Add(lblTitle4);
            pnlStat4.Dock = DockStyle.Fill;
            pnlStat4.Location = new Point(754, 0);
            pnlStat4.Margin = new Padding(4, 0, 0, 0);
            pnlStat4.Name = "pnlStat4";
            pnlStat4.Size = new Size(246, 65);
            pnlStat4.TabIndex = 3;
            // 
            // lblIcon4
            // 
            lblIcon4.AutoSize = true;
            lblIcon4.Font = new Font("Segoe UI", 18F);
            lblIcon4.Location = new Point(10, 10);
            lblIcon4.Name = "lblIcon4";
            lblIcon4.Size = new Size(47, 32);
            lblIcon4.TabIndex = 0;
            lblIcon4.Text = "📊";
            // 
            // lblStatRateVal
            // 
            lblStatRateVal.AutoSize = true;
            lblStatRateVal.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblStatRateVal.ForeColor = Color.FromArgb(245, 158, 11);
            lblStatRateVal.Location = new Point(50, 10);
            lblStatRateVal.Name = "lblStatRateVal";
            lblStatRateVal.Size = new Size(70, 32);
            lblStatRateVal.TabIndex = 1;
            lblStatRateVal.Text = "0.0%";
            // 
            // lblTitle4
            // 
            lblTitle4.AutoSize = true;
            lblTitle4.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblTitle4.ForeColor = Color.FromArgb(148, 163, 184);
            lblTitle4.Location = new Point(10, 45);
            lblTitle4.Name = "lblTitle4";
            lblTitle4.Size = new Size(78, 12);
            lblTitle4.TabIndex = 2;
            lblTitle4.Text = "TỶ LỆ ĐỘT QUỴ";
            // 
            // pnlResults
            // 
            pnlResults.Controls.Add(dgvResults);
            pnlResults.Controls.Add(lblResultTitle);
            pnlResults.Dock = DockStyle.Fill;
            pnlResults.Location = new Point(0, 302);
            pnlResults.Name = "pnlResults";
            pnlResults.Size = new Size(1000, 298);
            pnlResults.TabIndex = 4;
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.BackgroundColor = Color.FromArgb(17, 24, 39);
            dgvResults.BorderStyle = BorderStyle.None;
            dgvResults.ColumnHeadersHeight = 35;
            dgvResults.Dock = DockStyle.Fill;
            dgvResults.EnableHeadersVisualStyles = false;
            dgvResults.Location = new Point(0, 28);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.RowHeadersVisible = false;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.Size = new Size(1000, 270);
            dgvResults.TabIndex = 0;
            // 
            // lblResultTitle
            // 
            lblResultTitle.BackColor = SystemColors.ActiveCaption;
            lblResultTitle.Dock = DockStyle.Top;
            lblResultTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblResultTitle.ForeColor = Color.White;
            lblResultTitle.Location = new Point(0, 0);
            lblResultTitle.Name = "lblResultTitle";
            lblResultTitle.Padding = new Padding(0, 5, 0, 0);
            lblResultTitle.Size = new Size(1000, 28);
            lblResultTitle.TabIndex = 1;
            lblResultTitle.Text = "📋 KẾT QUẢ PHÂN TÍCH CHI TIẾT";
            // 
            // BatchScanView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlResults);
            Controls.Add(tlpStats);
            Controls.Add(pnlProgress);
            Controls.Add(pnlActions);
            Controls.Add(pnlDropZone);
            Name = "BatchScanView";
            Size = new Size(1000, 600);
            pnlDropZone.ResumeLayout(false);
            pnlBtnWrap.ResumeLayout(false);
            pnlActions.ResumeLayout(false);
            pnlActions.PerformLayout();
            pnlProgress.ResumeLayout(false);
            pnlProgress.PerformLayout();
            tlpStats.ResumeLayout(false);
            pnlStat1.ResumeLayout(false);
            pnlStat1.PerformLayout();
            pnlStat2.ResumeLayout(false);
            pnlStat2.PerformLayout();
            pnlStat3.ResumeLayout(false);
            pnlStat3.PerformLayout();
            pnlStat4.ResumeLayout(false);
            pnlStat4.PerformLayout();
            pnlResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlDropZone;
        private System.Windows.Forms.Label lblDropIcon;
        private System.Windows.Forms.Label lblDropTitle;
        private System.Windows.Forms.Label lblDropSub;
        private System.Windows.Forms.Panel pnlBtnWrap;
        private System.Windows.Forms.Button btnBrowse;
        
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Label lblFileInfo;
        private System.Windows.Forms.Button btnStartScan;
        private System.Windows.Forms.Button btnStopScan;
        private System.Windows.Forms.Button btnExportResults;
        private System.Windows.Forms.Button btnClearAll;
        
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.Label lblScanStatus;
        private System.Windows.Forms.Label lblScanPct;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgressMsg;
        
        private System.Windows.Forms.TableLayoutPanel tlpStats;
        private System.Windows.Forms.Panel pnlStat1;
        private System.Windows.Forms.Label lblIcon1;
        private System.Windows.Forms.Label lblStatTotalVal;
        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.Panel pnlStat2;
        private System.Windows.Forms.Label lblIcon2;
        private System.Windows.Forms.Label lblStatStrokeVal;
        private System.Windows.Forms.Label lblTitle2;
        private System.Windows.Forms.Panel pnlStat3;
        private System.Windows.Forms.Label lblIcon3;
        private System.Windows.Forms.Label lblStatNormalVal;
        private System.Windows.Forms.Label lblTitle3;
        private System.Windows.Forms.Panel pnlStat4;
        private System.Windows.Forms.Label lblIcon4;
        private System.Windows.Forms.Label lblStatRateVal;
        private System.Windows.Forms.Label lblTitle4;
        
        private System.Windows.Forms.Panel pnlResults;
        private System.Windows.Forms.Label lblResultTitle;
        private System.Windows.Forms.DataGridView dgvResults;
    }
}
