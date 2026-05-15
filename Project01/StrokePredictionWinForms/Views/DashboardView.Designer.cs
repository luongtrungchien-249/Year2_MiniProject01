namespace StrokePredictionWinForms.Views
{
    partial class DashboardView
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
            pnlHeader = new Panel();
            lblTitleView = new Label();
            pnlFilter = new Panel();
            btnExportCsv = new Button();
            btnRefresh = new Button();
            dtpEnd = new DateTimePicker();
            lblTo = new Label();
            dtpStart = new DateTimePicker();
            lblFrom = new Label();
            tlpKPI = new TableLayoutPanel();
            
            pnlKpi1 = new Panel();
            lblKpiTotalVal = new Label();
            lblKpiTitle1 = new Label();
            lblKpiIcon1 = new Label();
            pnlAccent1 = new Panel();
            
            pnlKpi2 = new Panel();
            lblKpiStrokeVal = new Label();
            lblKpiTitle2 = new Label();
            lblKpiIcon2 = new Label();
            pnlAccent2 = new Panel();
            
            pnlKpi3 = new Panel();
            lblKpiNormalVal = new Label();
            lblKpiTitle3 = new Label();
            lblKpiIcon3 = new Label();
            pnlAccent3 = new Panel();
            
            pnlKpi4 = new Panel();
            lblKpiRateVal = new Label();
            lblKpiTitle4 = new Label();
            lblKpiIcon4 = new Label();
            pnlAccent4 = new Panel();

            tlpCharts = new TableLayoutPanel();
            pnlDistribute = new Panel();
            lblDistTitle = new Label();
            lblDistStrokePercent = new Label();
            lblDistNormalPercent = new Label();
            lblLegendStroke = new Label();
            lblLegendNormal = new Label();
            
            pnlTrend = new Panel();
            lblTrendTitle = new Label();
            
            tlpBottom = new TableLayoutPanel();
            pnlConfidence = new Panel();
            lblConfTitle = new Label();
            
            lblConf1 = new Label(); lblConfVal1 = new Label(); pnlConfBase1 = new Panel(); pnlConfFill1 = new Panel();
            lblConf2 = new Label(); lblConfVal2 = new Label(); pnlConfBase2 = new Panel(); pnlConfFill2 = new Panel();
            lblConf3 = new Label(); lblConfVal3 = new Label(); pnlConfBase3 = new Panel(); pnlConfFill3 = new Panel();
            lblConf4 = new Label(); lblConfVal4 = new Label(); pnlConfBase4 = new Panel(); pnlConfFill4 = new Panel();
            lblConf5 = new Label(); lblConfVal5 = new Label(); pnlConfBase5 = new Panel(); pnlConfFill5 = new Panel();

            pnlRecent = new Panel();
            dgvRecent = new DataGridView();
            lblRecentTitle = new Label();
            
            pnlHeader.SuspendLayout();
            pnlFilter.SuspendLayout();
            tlpKPI.SuspendLayout();
            
            pnlKpi1.SuspendLayout();
            pnlKpi2.SuspendLayout();
            pnlKpi3.SuspendLayout();
            pnlKpi4.SuspendLayout();
            
            tlpCharts.SuspendLayout();
            pnlDistribute.SuspendLayout();
            pnlTrend.SuspendLayout();
            tlpBottom.SuspendLayout();
            pnlConfidence.SuspendLayout();
            pnlConfBase1.SuspendLayout();
            pnlConfBase2.SuspendLayout();
            pnlConfBase3.SuspendLayout();
            pnlConfBase4.SuspendLayout();
            pnlConfBase5.SuspendLayout();
            pnlRecent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecent).BeginInit();
            SuspendLayout();
            
            // pnlHeader
            pnlHeader.Controls.Add(lblTitleView);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(15, 15);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1318, 50);
            
            // lblTitleView
            lblTitleView.AutoSize = true;
            lblTitleView.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitleView.ForeColor = Color.White;
            lblTitleView.Location = new Point(0, 5);
            lblTitleView.Name = "lblTitleView";
            lblTitleView.Size = new Size(253, 32);
            lblTitleView.Text = "📊 Báo cáo thống kê";
            
            // pnlFilter
            pnlFilter.BackColor = Color.FromArgb(20, 20, 20);
            pnlFilter.Controls.Add(btnExportCsv);
            pnlFilter.Controls.Add(btnRefresh);
            pnlFilter.Controls.Add(dtpEnd);
            pnlFilter.Controls.Add(lblTo);
            pnlFilter.Controls.Add(dtpStart);
            pnlFilter.Controls.Add(lblFrom);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(15, 65);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(1318, 60);
            
            // btnExportCsv
            btnExportCsv.BackColor = Color.FromArgb(51, 65, 85);
            btnExportCsv.FlatAppearance.BorderSize = 0;
            btnExportCsv.FlatStyle = FlatStyle.Flat;
            btnExportCsv.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExportCsv.ForeColor = Color.White;
            btnExportCsv.Location = new Point(530, 15);
            btnExportCsv.Name = "btnExportCsv";
            btnExportCsv.Size = new Size(100, 30);
            btnExportCsv.Text = "💾 Xuất CSV";
            
            // btnRefresh
            btnRefresh.BackColor = Color.FromArgb(16, 185, 129);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(420, 15);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 30);
            btnRefresh.Text = "🔄 Làm mới";
            
            // dtpEnd
            dtpEnd.Format = DateTimePickerFormat.Short;
            dtpEnd.Location = new Point(265, 18);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(130, 23);
            
            // lblTo
            lblTo.AutoSize = true;
            lblTo.ForeColor = Color.Gray;
            lblTo.Location = new Point(220, 22);
            lblTo.Name = "lblTo";
            lblTo.Text = "Đến:";
            
            // dtpStart
            dtpStart.Format = DateTimePickerFormat.Short;
            dtpStart.Location = new Point(50, 18);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(130, 23);
            
            // lblFrom
            lblFrom.AutoSize = true;
            lblFrom.ForeColor = Color.Gray;
            lblFrom.Location = new Point(10, 22);
            lblFrom.Name = "lblFrom";
            lblFrom.Text = "Từ:";
            
            // tlpKPI
            tlpKPI.ColumnCount = 4;
            tlpKPI.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpKPI.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpKPI.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpKPI.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpKPI.Controls.Add(pnlKpi1, 0, 0);
            tlpKPI.Controls.Add(pnlKpi2, 1, 0);
            tlpKPI.Controls.Add(pnlKpi3, 2, 0);
            tlpKPI.Controls.Add(pnlKpi4, 3, 0);
            tlpKPI.Dock = DockStyle.Top;
            tlpKPI.Location = new Point(15, 125);
            tlpKPI.Name = "tlpKPI";
            tlpKPI.Padding = new Padding(0, 10, 0, 10);
            tlpKPI.RowCount = 1;
            tlpKPI.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpKPI.Size = new Size(1318, 140);
            
            // pnlKpi1
            pnlKpi1.BackColor = Color.FromArgb(31, 41, 55);
            pnlKpi1.Controls.Add(lblKpiIcon1);
            pnlKpi1.Controls.Add(lblKpiTitle1);
            pnlKpi1.Controls.Add(lblKpiTotalVal);
            pnlKpi1.Controls.Add(pnlAccent1);
            pnlKpi1.Dock = DockStyle.Fill;
            pnlKpi1.Margin = new Padding(5);
            
            lblKpiIcon1.Text = "🔍";
            lblKpiIcon1.Font = new Font("Segoe UI", 20);
            lblKpiIcon1.ForeColor = Color.FromArgb(6, 182, 212);
            lblKpiIcon1.AutoSize = true;
            lblKpiIcon1.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            lblKpiIcon1.Location = new Point(265, 15);
            
            lblKpiTitle1.Text = "Tổng lượt quét\n— tháng này";
            lblKpiTitle1.ForeColor = Color.FromArgb(148, 163, 184);
            lblKpiTitle1.Font = new Font("Segoe UI", 9);
            lblKpiTitle1.Location = new Point(15, 15);
            lblKpiTitle1.AutoSize = true;
            
            lblKpiTotalVal.Text = "0";
            lblKpiTotalVal.ForeColor = Color.FromArgb(6, 182, 212);
            lblKpiTotalVal.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblKpiTotalVal.Location = new Point(15, 55);
            lblKpiTotalVal.AutoSize = true;
            
            pnlAccent1.BackColor = Color.FromArgb(6, 182, 212);
            pnlAccent1.Height = 4;
            pnlAccent1.Dock = DockStyle.Bottom;
            
            // pnlKpi2
            pnlKpi2.BackColor = Color.FromArgb(31, 41, 55);
            pnlKpi2.Controls.Add(lblKpiIcon2);
            pnlKpi2.Controls.Add(lblKpiTitle2);
            pnlKpi2.Controls.Add(lblKpiStrokeVal);
            pnlKpi2.Controls.Add(pnlAccent2);
            pnlKpi2.Dock = DockStyle.Fill;
            pnlKpi2.Margin = new Padding(5);
            
            lblKpiIcon2.Text = "🚨";
            lblKpiIcon2.Font = new Font("Segoe UI", 20);
            lblKpiIcon2.ForeColor = Color.FromArgb(239, 68, 68);
            lblKpiIcon2.AutoSize = true;
            lblKpiIcon2.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            lblKpiIcon2.Location = new Point(265, 15);
            
            lblKpiTitle2.Text = "Bệnh nhân Đột quỵ\n— phát hiện";
            lblKpiTitle2.ForeColor = Color.FromArgb(148, 163, 184);
            lblKpiTitle2.Font = new Font("Segoe UI", 9);
            lblKpiTitle2.Location = new Point(15, 15);
            lblKpiTitle2.AutoSize = true;
            
            lblKpiStrokeVal.Text = "0";
            lblKpiStrokeVal.ForeColor = Color.FromArgb(239, 68, 68);
            lblKpiStrokeVal.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblKpiStrokeVal.Location = new Point(15, 55);
            lblKpiStrokeVal.AutoSize = true;
            
            pnlAccent2.BackColor = Color.FromArgb(239, 68, 68);
            pnlAccent2.Height = 4;
            pnlAccent2.Dock = DockStyle.Bottom;
            
            // pnlKpi3
            pnlKpi3.BackColor = Color.FromArgb(31, 41, 55);
            pnlKpi3.Controls.Add(lblKpiIcon3);
            pnlKpi3.Controls.Add(lblKpiTitle3);
            pnlKpi3.Controls.Add(lblKpiNormalVal);
            pnlKpi3.Controls.Add(pnlAccent3);
            pnlKpi3.Dock = DockStyle.Fill;
            pnlKpi3.Margin = new Padding(5);
            
            lblKpiIcon3.Text = "✅";
            lblKpiIcon3.Font = new Font("Segoe UI", 20);
            lblKpiIcon3.ForeColor = Color.FromArgb(34, 197, 94);
            lblKpiIcon3.AutoSize = true;
            lblKpiIcon3.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            lblKpiIcon3.Location = new Point(265, 15);
            
            lblKpiTitle3.Text = "Người Bình thường\n— xác nhận";
            lblKpiTitle3.ForeColor = Color.FromArgb(148, 163, 184);
            lblKpiTitle3.Font = new Font("Segoe UI", 9);
            lblKpiTitle3.Location = new Point(15, 15);
            lblKpiTitle3.AutoSize = true;
            
            lblKpiNormalVal.Text = "0";
            lblKpiNormalVal.ForeColor = Color.FromArgb(34, 197, 94);
            lblKpiNormalVal.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblKpiNormalVal.Location = new Point(15, 55);
            lblKpiNormalVal.AutoSize = true;
            
            pnlAccent3.BackColor = Color.FromArgb(34, 197, 94);
            pnlAccent3.Height = 4;
            pnlAccent3.Dock = DockStyle.Bottom;
            
            // pnlKpi4
            pnlKpi4.BackColor = Color.FromArgb(31, 41, 55);
            pnlKpi4.Controls.Add(lblKpiIcon4);
            pnlKpi4.Controls.Add(lblKpiTitle4);
            pnlKpi4.Controls.Add(lblKpiRateVal);
            pnlKpi4.Controls.Add(pnlAccent4);
            pnlKpi4.Dock = DockStyle.Fill;
            pnlKpi4.Margin = new Padding(5);
            
            lblKpiIcon4.Text = "📈";
            lblKpiIcon4.Font = new Font("Segoe UI", 20);
            lblKpiIcon4.ForeColor = Color.FromArgb(245, 158, 11);
            lblKpiIcon4.AutoSize = true;
            lblKpiIcon4.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            lblKpiIcon4.Location = new Point(265, 15);
            
            lblKpiTitle4.Text = "Tỷ lệ Đột quỵ\n— trên tổng quét";
            lblKpiTitle4.ForeColor = Color.FromArgb(148, 163, 184);
            lblKpiTitle4.Font = new Font("Segoe UI", 9);
            lblKpiTitle4.Location = new Point(15, 15);
            lblKpiTitle4.AutoSize = true;
            
            lblKpiRateVal.Text = "0.0%";
            lblKpiRateVal.ForeColor = Color.FromArgb(245, 158, 11);
            lblKpiRateVal.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblKpiRateVal.Location = new Point(15, 55);
            lblKpiRateVal.AutoSize = true;
            
            pnlAccent4.BackColor = Color.FromArgb(245, 158, 11);
            pnlAccent4.Height = 4;
            pnlAccent4.Dock = DockStyle.Bottom;

            // tlpCharts
            tlpCharts.ColumnCount = 2;
            tlpCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpCharts.Controls.Add(pnlDistribute, 0, 0);
            tlpCharts.Controls.Add(pnlTrend, 1, 0);
            tlpCharts.Dock = DockStyle.Top;
            tlpCharts.Location = new Point(15, 265);
            tlpCharts.Name = "tlpCharts";
            tlpCharts.RowCount = 1;
            tlpCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpCharts.Size = new Size(1318, 200);
            
            // pnlDistribute
            pnlDistribute.BackColor = Color.FromArgb(15, 23, 42);
            pnlDistribute.Controls.Add(lblDistStrokePercent);
            pnlDistribute.Controls.Add(lblDistNormalPercent);
            pnlDistribute.Controls.Add(lblLegendStroke);
            pnlDistribute.Controls.Add(lblLegendNormal);
            pnlDistribute.Controls.Add(lblDistTitle);
            pnlDistribute.Dock = DockStyle.Fill;
            pnlDistribute.Location = new Point(3, 3);
            pnlDistribute.Name = "pnlDistribute";
            
            lblDistTitle.AutoSize = true;
            lblDistTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDistTitle.ForeColor = Color.FromArgb(6, 182, 212);
            lblDistTitle.Location = new Point(10, 10);
            lblDistTitle.Text = "☺ Phân bố kết quả phân loại";
            
            lblDistStrokePercent.Text = "0.0 %";
            lblDistStrokePercent.ForeColor = Color.FromArgb(239, 68, 68);
            lblDistStrokePercent.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblDistStrokePercent.Location = new Point(30, 70);
            lblDistStrokePercent.AutoSize = true;
            
            lblDistNormalPercent.Text = "0.0 %";
            lblDistNormalPercent.ForeColor = Color.FromArgb(34, 197, 94);
            lblDistNormalPercent.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblDistNormalPercent.Location = new Point(200, 70);
            lblDistNormalPercent.AutoSize = true;
            
            lblLegendStroke.Text = "🔴 Đột quỵ";
            lblLegendStroke.ForeColor = Color.Gray;
            lblLegendStroke.Font = new Font("Segoe UI", 9);
            lblLegendStroke.Location = new Point(30, 140);
            lblLegendStroke.AutoSize = true;
            
            lblLegendNormal.Text = "🟢 Bình thường";
            lblLegendNormal.ForeColor = Color.Gray;
            lblLegendNormal.Font = new Font("Segoe UI", 9);
            lblLegendNormal.Location = new Point(200, 140);
            lblLegendNormal.AutoSize = true;

            // pnlTrend
            pnlTrend.BackColor = Color.FromArgb(15, 23, 42);
            pnlTrend.Controls.Add(lblTrendTitle);
            pnlTrend.Dock = DockStyle.Fill;
            pnlTrend.Location = new Point(530, 3);
            pnlTrend.Name = "pnlTrend";
            
            lblTrendTitle.AutoSize = true;
            lblTrendTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTrendTitle.ForeColor = Color.White;
            lblTrendTitle.Location = new Point(10, 10);
            lblTrendTitle.Text = "📈 Xu hướng quét theo ngày";

            // tlpBottom
            tlpBottom.ColumnCount = 2;
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpBottom.Controls.Add(pnlConfidence, 0, 0);
            tlpBottom.Controls.Add(pnlRecent, 1, 0);
            tlpBottom.Dock = DockStyle.Fill;
            tlpBottom.Location = new Point(15, 465);
            tlpBottom.Name = "tlpBottom";
            tlpBottom.RowCount = 1;
            tlpBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpBottom.Size = new Size(1318, 305);
            
            // pnlConfidence
            pnlConfidence.BackColor = Color.FromArgb(15, 23, 42);
            pnlConfidence.Controls.Add(lblConf1); pnlConfidence.Controls.Add(lblConfVal1); pnlConfidence.Controls.Add(pnlConfBase1);
            pnlConfidence.Controls.Add(lblConf2); pnlConfidence.Controls.Add(lblConfVal2); pnlConfidence.Controls.Add(pnlConfBase2);
            pnlConfidence.Controls.Add(lblConf3); pnlConfidence.Controls.Add(lblConfVal3); pnlConfidence.Controls.Add(pnlConfBase3);
            pnlConfidence.Controls.Add(lblConf4); pnlConfidence.Controls.Add(lblConfVal4); pnlConfidence.Controls.Add(pnlConfBase4);
            pnlConfidence.Controls.Add(lblConf5); pnlConfidence.Controls.Add(lblConfVal5); pnlConfidence.Controls.Add(pnlConfBase5);
            pnlConfidence.Controls.Add(lblConfTitle);
            pnlConfidence.Dock = DockStyle.Fill;
            pnlConfidence.Location = new Point(3, 10);
            pnlConfidence.Margin = new Padding(3, 10, 3, 3);
            pnlConfidence.Name = "pnlConfidence";
            
            lblConfTitle.AutoSize = true;
            lblConfTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblConfTitle.ForeColor = Color.FromArgb(245, 158, 11);
            lblConfTitle.Location = new Point(10, 10);
            lblConfTitle.Text = "📊 Phân bố độ tin cậy (Confidence)";

            // Conf 1
            lblConf1.Text = "0–20%"; lblConf1.ForeColor = Color.Gray; lblConf1.Font = new Font("Segoe UI", 9); lblConf1.Location = new Point(15, 50); lblConf1.AutoSize = true;
            pnlConfBase1.BackColor = Color.FromArgb(30, 41, 59); pnlConfBase1.Location = new Point(85, 52); pnlConfBase1.Size = new Size(220, 14);
            pnlConfFill1.BackColor = Color.FromArgb(16, 185, 129); pnlConfFill1.Width = 0; pnlConfFill1.Dock = DockStyle.Left; pnlConfBase1.Controls.Add(pnlConfFill1);
            lblConfVal1.Text = "0"; lblConfVal1.ForeColor = Color.White; lblConfVal1.Font = new Font("Segoe UI", 9); lblConfVal1.Location = new Point(315, 50); lblConfVal1.AutoSize = true;

            // Conf 2
            lblConf2.Text = "20–40%"; lblConf2.ForeColor = Color.Gray; lblConf2.Font = new Font("Segoe UI", 9); lblConf2.Location = new Point(15, 85); lblConf2.AutoSize = true;
            pnlConfBase2.BackColor = Color.FromArgb(30, 41, 59); pnlConfBase2.Location = new Point(85, 87); pnlConfBase2.Size = new Size(220, 14);
            pnlConfFill2.BackColor = Color.FromArgb(16, 185, 129); pnlConfFill2.Width = 0; pnlConfFill2.Dock = DockStyle.Left; pnlConfBase2.Controls.Add(pnlConfFill2);
            lblConfVal2.Text = "0"; lblConfVal2.ForeColor = Color.White; lblConfVal2.Font = new Font("Segoe UI", 9); lblConfVal2.Location = new Point(315, 85); lblConfVal2.AutoSize = true;

            // Conf 3
            lblConf3.Text = "40–60%"; lblConf3.ForeColor = Color.Gray; lblConf3.Font = new Font("Segoe UI", 9); lblConf3.Location = new Point(15, 120); lblConf3.AutoSize = true;
            pnlConfBase3.BackColor = Color.FromArgb(30, 41, 59); pnlConfBase3.Location = new Point(85, 122); pnlConfBase3.Size = new Size(220, 14);
            pnlConfFill3.BackColor = Color.FromArgb(16, 185, 129); pnlConfFill3.Width = 0; pnlConfFill3.Dock = DockStyle.Left; pnlConfBase3.Controls.Add(pnlConfFill3);
            lblConfVal3.Text = "0"; lblConfVal3.ForeColor = Color.White; lblConfVal3.Font = new Font("Segoe UI", 9); lblConfVal3.Location = new Point(315, 120); lblConfVal3.AutoSize = true;

            // Conf 4
            lblConf4.Text = "60–80%"; lblConf4.ForeColor = Color.Gray; lblConf4.Font = new Font("Segoe UI", 9); lblConf4.Location = new Point(15, 155); lblConf4.AutoSize = true;
            pnlConfBase4.BackColor = Color.FromArgb(30, 41, 59); pnlConfBase4.Location = new Point(85, 157); pnlConfBase4.Size = new Size(220, 14);
            pnlConfFill4.BackColor = Color.FromArgb(16, 185, 129); pnlConfFill4.Width = 0; pnlConfFill4.Dock = DockStyle.Left; pnlConfBase4.Controls.Add(pnlConfFill4);
            lblConfVal4.Text = "0"; lblConfVal4.ForeColor = Color.White; lblConfVal4.Font = new Font("Segoe UI", 9); lblConfVal4.Location = new Point(315, 155); lblConfVal4.AutoSize = true;

            // Conf 5
            lblConf5.Text = "80–100%"; lblConf5.ForeColor = Color.Gray; lblConf5.Font = new Font("Segoe UI", 9); lblConf5.Location = new Point(15, 190); lblConf5.AutoSize = true;
            pnlConfBase5.BackColor = Color.FromArgb(30, 41, 59); pnlConfBase5.Location = new Point(85, 192); pnlConfBase5.Size = new Size(220, 14);
            pnlConfFill5.BackColor = Color.FromArgb(16, 185, 129); pnlConfFill5.Width = 0; pnlConfFill5.Dock = DockStyle.Left; pnlConfBase5.Controls.Add(pnlConfFill5);
            lblConfVal5.Text = "0"; lblConfVal5.ForeColor = Color.White; lblConfVal5.Font = new Font("Segoe UI", 9); lblConfVal5.Location = new Point(315, 190); lblConfVal5.AutoSize = true;

            // pnlRecent
            pnlRecent.BackColor = Color.FromArgb(15, 23, 42);
            pnlRecent.Controls.Add(dgvRecent);
            pnlRecent.Controls.Add(lblRecentTitle);
            pnlRecent.Dock = DockStyle.Fill;
            pnlRecent.Location = new Point(530, 10);
            pnlRecent.Margin = new Padding(3, 10, 3, 3);
            pnlRecent.Name = "pnlRecent";
            
            // dgvRecent
            dgvRecent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRecent.BackgroundColor = Color.FromArgb(30, 41, 59);
            dgvRecent.BorderStyle = BorderStyle.None;
            dgvRecent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecent.Location = new Point(10, 40);
            dgvRecent.Name = "dgvRecent";
            dgvRecent.Size = new Size(765, 242);
            
            // lblRecentTitle
            lblRecentTitle.AutoSize = true;
            lblRecentTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRecentTitle.ForeColor = Color.FromArgb(45, 212, 191);
            lblRecentTitle.Location = new Point(10, 10);
            lblRecentTitle.Text = "📋 Danh sách quét gần đây (Top 50)";
            
            // DashboardView
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 17, 30);
            Controls.Add(tlpBottom);
            Controls.Add(tlpCharts);
            Controls.Add(tlpKPI);
            Controls.Add(pnlFilter);
            Controls.Add(pnlHeader);
            Name = "DashboardView";
            Padding = new Padding(15);
            Size = new Size(1348, 785);
            
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            tlpKPI.ResumeLayout(false);
            pnlKpi1.ResumeLayout(false); pnlKpi1.PerformLayout();
            pnlKpi2.ResumeLayout(false); pnlKpi2.PerformLayout();
            pnlKpi3.ResumeLayout(false); pnlKpi3.PerformLayout();
            pnlKpi4.ResumeLayout(false); pnlKpi4.PerformLayout();
            tlpCharts.ResumeLayout(false);
            pnlDistribute.ResumeLayout(false); pnlDistribute.PerformLayout();
            pnlTrend.ResumeLayout(false); pnlTrend.PerformLayout();
            tlpBottom.ResumeLayout(false);
            pnlConfidence.ResumeLayout(false); pnlConfidence.PerformLayout();
            pnlConfBase1.ResumeLayout(false); pnlConfBase2.ResumeLayout(false); pnlConfBase3.ResumeLayout(false); pnlConfBase4.ResumeLayout(false); pnlConfBase5.ResumeLayout(false);
            pnlRecent.ResumeLayout(false); pnlRecent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecent).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitleView;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.TableLayoutPanel tlpKPI;
        private System.Windows.Forms.TableLayoutPanel tlpCharts;
        private System.Windows.Forms.Panel pnlDistribute;
        private System.Windows.Forms.Label lblDistTitle;
        private System.Windows.Forms.Label lblDistStrokePercent;
        private System.Windows.Forms.Label lblDistNormalPercent;
        private System.Windows.Forms.Label lblLegendStroke;
        private System.Windows.Forms.Label lblLegendNormal;
        private System.Windows.Forms.Panel pnlTrend;
        private System.Windows.Forms.Label lblTrendTitle;
        private System.Windows.Forms.TableLayoutPanel tlpBottom;
        private System.Windows.Forms.Panel pnlConfidence;
        private System.Windows.Forms.Label lblConfTitle;
        private System.Windows.Forms.Panel pnlRecent;
        private System.Windows.Forms.Label lblRecentTitle;
        private System.Windows.Forms.DataGridView dgvRecent;
        
        private System.Windows.Forms.Panel pnlKpi1, pnlKpi2, pnlKpi3, pnlKpi4;
        private System.Windows.Forms.Label lblKpiTotalVal, lblKpiStrokeVal, lblKpiNormalVal, lblKpiRateVal;
        private System.Windows.Forms.Label lblKpiTitle1, lblKpiTitle2, lblKpiTitle3, lblKpiTitle4;
        private System.Windows.Forms.Label lblKpiIcon1, lblKpiIcon2, lblKpiIcon3, lblKpiIcon4;
        private System.Windows.Forms.Panel pnlAccent1, pnlAccent2, pnlAccent3, pnlAccent4;
        
        private System.Windows.Forms.Label lblConf1, lblConf2, lblConf3, lblConf4, lblConf5;
        private System.Windows.Forms.Label lblConfVal1, lblConfVal2, lblConfVal3, lblConfVal4, lblConfVal5;
        private System.Windows.Forms.Panel pnlConfBase1, pnlConfBase2, pnlConfBase3, pnlConfBase4, pnlConfBase5;
        private System.Windows.Forms.Panel pnlConfFill1, pnlConfFill2, pnlConfFill3, pnlConfFill4, pnlConfFill5;
    }
}
