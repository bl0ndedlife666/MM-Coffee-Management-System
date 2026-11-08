namespace CoffeeManagementSystem
{
    partial class ReportsForm
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
            cboType = new ComboBox();
            dtpDate = new DateTimePicker();
            btnGenerate = new Button();
            btnExport = new Button();
            lblSummary = new Label();
            dgvReport = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // cboType
            // 
            cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboType.FormattingEnabled = true;
            cboType.Location = new Point(12, 12);
            cboType.Name = "cboType";
            cboType.Size = new Size(137, 23);
            cboType.TabIndex = 0;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(169, 12);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 23);
            dtpDate.TabIndex = 1;
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.FromArgb(217, 179, 130);
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerate.ForeColor = Color.FromArgb(48, 35, 31);
            btnGenerate.Location = new Point(12, 41);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(93, 37);
            btnGenerate.TabIndex = 2;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(217, 179, 130);
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExport.Location = new Point(169, 41);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(102, 37);
            btnExport.TabIndex = 3;
            btnExport.Text = "Export to CSV";
            btnExport.UseVisualStyleBackColor = false;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Location = new Point(12, 81);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(38, 15);
            lblSummary.TabIndex = 4;
            lblSummary.Text = "label1";
            // 
            // dgvReport
            // 
            dgvReport.BackgroundColor = Color.White;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Location = new Point(12, 113);
            dgvReport.Name = "dgvReport";
            dgvReport.Size = new Size(642, 436);
            dgvReport.TabIndex = 5;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 240, 231);
            ClientSize = new Size(837, 561);
            Controls.Add(dgvReport);
            Controls.Add(lblSummary);
            Controls.Add(btnExport);
            Controls.Add(btnGenerate);
            Controls.Add(dtpDate);
            Controls.Add(cboType);
            ForeColor = Color.FromArgb(48, 35, 31);
            Name = "ReportsForm";
            Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboType;
        private DateTimePicker dtpDate;
        private Button btnGenerate;
        private Button btnExport;
        private Label lblSummary;
        private DataGridView dgvReport;
    }
}