namespace CoffeeManagementSystem
{
    partial class OrderHistoryForm
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
            txtOrderNo = new TextBox();
            chkByDate = new CheckBox();
            dtpDate = new DateTimePicker();
            btnSearch = new Button();
            dgvOrders = new DataGridView();
            dgvLines = new DataGridView();
            btnReprint = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLines).BeginInit();
            SuspendLayout();
            // 
            // txtOrderNo
            // 
            txtOrderNo.Location = new Point(12, 73);
            txtOrderNo.Name = "txtOrderNo";
            txtOrderNo.PlaceholderText = "Order #";
            txtOrderNo.Size = new Size(100, 23);
            txtOrderNo.TabIndex = 0;
            // 
            // chkByDate
            // 
            chkByDate.AutoSize = true;
            chkByDate.Location = new Point(12, 102);
            chkByDate.Name = "chkByDate";
            chkByDate.Size = new Size(94, 19);
            chkByDate.TabIndex = 1;
            chkByDate.Text = "Filter by date";
            chkByDate.UseVisualStyleBackColor = true;
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(12, 127);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(78, 23);
            dtpDate.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(12, 156);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(12, 185);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(511, 150);
            dgvOrders.TabIndex = 4;
            // 
            // dgvLines
            // 
            dgvLines.AllowUserToAddRows = false;
            dgvLines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLines.Location = new Point(12, 341);
            dgvLines.Name = "dgvLines";
            dgvLines.ReadOnly = true;
            dgvLines.RowHeadersVisible = false;
            dgvLines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLines.Size = new Size(511, 150);
            dgvLines.TabIndex = 5;
            // 
            // btnReprint
            // 
            btnReprint.FlatStyle = FlatStyle.Flat;
            btnReprint.Location = new Point(47, 518);
            btnReprint.Name = "btnReprint";
            btnReprint.Size = new Size(147, 49);
            btnReprint.TabIndex = 6;
            btnReprint.Text = "Reprint receipt";
            btnReprint.UseVisualStyleBackColor = true;
            // 
            // OrderHistoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 611);
            Controls.Add(btnReprint);
            Controls.Add(dgvLines);
            Controls.Add(dgvOrders);
            Controls.Add(btnSearch);
            Controls.Add(dtpDate);
            Controls.Add(chkByDate);
            Controls.Add(txtOrderNo);
            Name = "OrderHistoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Order History";
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLines).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtOrderNo;
        private CheckBox chkByDate;
        private DateTimePicker dtpDate;
        private Button btnSearch;
        private DataGridView dgvOrders;
        private DataGridView dgvLines;
        private Button btnReprint;
    }
}