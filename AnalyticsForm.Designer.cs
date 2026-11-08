namespace CoffeeManagementSystem
{
    partial class AnalyticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cboPeriod = new ComboBox();
            lblRevenue = new Label();
            lblOrders = new Label();
            lblAvg = new Label();
            lblPeak = new Label();
            tlpCharts = new TableLayoutPanel();
            SuspendLayout();
            // 
            // cboPeriod
            // 
            cboPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPeriod.FormattingEnabled = true;
            cboPeriod.Location = new Point(12, 12);
            cboPeriod.Name = "cboPeriod";
            cboPeriod.Size = new Size(122, 23);
            cboPeriod.TabIndex = 0;
            // 
            // lblRevenue
            // 
            lblRevenue.AutoSize = true;
            lblRevenue.Location = new Point(12, 54);
            lblRevenue.Name = "lblRevenue";
            lblRevenue.Size = new Size(38, 15);
            lblRevenue.TabIndex = 1;
            lblRevenue.Text = "label1";
            // 
            // lblOrders
            // 
            lblOrders.AutoSize = true;
            lblOrders.Location = new Point(12, 86);
            lblOrders.Name = "lblOrders";
            lblOrders.Size = new Size(38, 15);
            lblOrders.TabIndex = 2;
            lblOrders.Text = "label1";
            // 
            // lblAvg
            // 
            lblAvg.AutoSize = true;
            lblAvg.Location = new Point(12, 116);
            lblAvg.Name = "lblAvg";
            lblAvg.Size = new Size(38, 15);
            lblAvg.TabIndex = 3;
            lblAvg.Text = "label1";
            // 
            // lblPeak
            // 
            lblPeak.AutoSize = true;
            lblPeak.Location = new Point(12, 147);
            lblPeak.Name = "lblPeak";
            lblPeak.Size = new Size(38, 15);
            lblPeak.TabIndex = 4;
            lblPeak.Text = "label1";
            // 
            // tlpCharts
            // 
            tlpCharts.BackColor = Color.White;
            tlpCharts.ColumnCount = 2;
            tlpCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpCharts.Dock = DockStyle.Fill;
            tlpCharts.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tlpCharts.Location = new Point(0, 0);
            tlpCharts.Name = "tlpCharts";
            tlpCharts.RowCount = 2;
            tlpCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpCharts.Size = new Size(800, 450);
            tlpCharts.TabIndex = 5;
            // 
            // AnalyticsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tlpCharts);
            Controls.Add(lblPeak);
            Controls.Add(lblAvg);
            Controls.Add(lblOrders);
            Controls.Add(lblRevenue);
            Controls.Add(cboPeriod);
            Name = "AnalyticsForm";
            Text = "AnalyticsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboPeriod;
        private Label lblRevenue;
        private Label lblOrders;
        private Label lblAvg;
        private Label lblPeak;
        private TableLayoutPanel tlpCharts;
    }
}