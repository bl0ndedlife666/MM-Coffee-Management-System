namespace CoffeeManagementSystem
{
    partial class SupplierForm
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
            dgvSuppliers = new DataGridView();
            txtName = new TextBox();
            txtContact = new TextBox();
            txtAddress = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnNew = new Button();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).BeginInit();
            SuspendLayout();
            // 
            // dgvSuppliers
            // 
            dgvSuppliers.AllowUserToAddRows = false;
            dgvSuppliers.BackgroundColor = Color.White;
            dgvSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSuppliers.Location = new Point(1, 0);
            dgvSuppliers.Name = "dgvSuppliers";
            dgvSuppliers.Size = new Size(455, 175);
            dgvSuppliers.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(101, 181);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 1;
            // 
            // txtContact
            // 
            txtContact.Location = new Point(101, 222);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(100, 23);
            txtContact.TabIndex = 2;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(101, 267);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(100, 23);
            txtAddress.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 275);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 4;
            label1.Text = "Address";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1, 230);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 5;
            label2.Text = "Contact number";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 189);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 6;
            label3.Text = "Supplier name";
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(217, 179, 130);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNew.ForeColor = Color.FromArgb(48, 35, 31);
            btnNew.Location = new Point(237, 181);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(95, 42);
            btnNew.TabIndex = 7;
            btnNew.Text = "New supplier";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(217, 179, 130);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.FromArgb(48, 35, 31);
            btnSave.Location = new Point(358, 181);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(98, 42);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save supplier";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // SupplierForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 240, 231);
            ClientSize = new Size(738, 450);
            Controls.Add(btnSave);
            Controls.Add(btnNew);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtAddress);
            Controls.Add(txtContact);
            Controls.Add(txtName);
            Controls.Add(dgvSuppliers);
            Name = "SupplierForm";
            Text = "SupplierForm";
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSuppliers;
        private TextBox txtName;
        private TextBox txtContact;
        private TextBox txtAddress;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnNew;
        private Button btnSave;
    }
}