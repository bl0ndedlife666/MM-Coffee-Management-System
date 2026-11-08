namespace CoffeeManagementSystem
{
    partial class InventoryForm
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
            dgvStock = new DataGridView();
            pnlAdmin = new Panel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnStockIn = new Button();
            txtUnitCost = new TextBox();
            txtQty = new TextBox();
            cboIngredient = new ComboBox();
            btnAddIngredient = new Button();
            cboSupplier = new ComboBox();
            txtReorder = new TextBox();
            txtUnit = new TextBox();
            txtIngName = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
            pnlAdmin.SuspendLayout();
            SuspendLayout();
            // 
            // dgvStock
            // 
            dgvStock.BackgroundColor = Color.White;
            dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStock.Location = new Point(37, 2);
            dgvStock.Name = "dgvStock";
            dgvStock.Size = new Size(572, 185);
            dgvStock.TabIndex = 0;
            // 
            // pnlAdmin
            // 
            pnlAdmin.Controls.Add(label6);
            pnlAdmin.Controls.Add(label5);
            pnlAdmin.Controls.Add(label4);
            pnlAdmin.Controls.Add(label3);
            pnlAdmin.Controls.Add(label2);
            pnlAdmin.Controls.Add(label1);
            pnlAdmin.Controls.Add(btnStockIn);
            pnlAdmin.Controls.Add(txtUnitCost);
            pnlAdmin.Controls.Add(txtQty);
            pnlAdmin.Controls.Add(cboIngredient);
            pnlAdmin.Controls.Add(btnAddIngredient);
            pnlAdmin.Controls.Add(cboSupplier);
            pnlAdmin.Controls.Add(txtReorder);
            pnlAdmin.Controls.Add(txtUnit);
            pnlAdmin.Controls.Add(txtIngName);
            pnlAdmin.Location = new Point(2, 193);
            pnlAdmin.Name = "pnlAdmin";
            pnlAdmin.Size = new Size(607, 365);
            pnlAdmin.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(384, 99);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 12;
            label5.Text = "Cost per unit";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(359, 65);
            label4.Name = "label4";
            label4.Size = new Size(100, 15);
            label4.TabIndex = 11;
            label4.Text = "Quantity received";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(80, 99);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 10;
            label3.Text = "Reorder level";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 70);
            label2.Name = "label2";
            label2.Size = new Size(152, 15);
            label2.TabIndex = 9;
            label2.Text = "Unit, for example g, ml, pcs";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 41);
            label1.Name = "label1";
            label1.Size = new Size(121, 15);
            label1.TabIndex = 8;
            label1.Text = "New ingredient name";
            // 
            // btnStockIn
            // 
            btnStockIn.BackColor = Color.FromArgb(217, 179, 130);
            btnStockIn.FlatStyle = FlatStyle.Flat;
            btnStockIn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStockIn.Location = new Point(478, 120);
            btnStockIn.Name = "btnStockIn";
            btnStockIn.Size = new Size(108, 36);
            btnStockIn.TabIndex = 2;
            btnStockIn.Text = "Record delivery";
            btnStockIn.UseVisualStyleBackColor = false;
            // 
            // txtUnitCost
            // 
            txtUnitCost.Location = new Point(465, 91);
            txtUnitCost.Name = "txtUnitCost";
            txtUnitCost.Size = new Size(121, 23);
            txtUnitCost.TabIndex = 7;
            // 
            // txtQty
            // 
            txtQty.Location = new Point(465, 59);
            txtQty.Multiline = true;
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(121, 23);
            txtQty.TabIndex = 6;
            // 
            // cboIngredient
            // 
            cboIngredient.DropDownStyle = ComboBoxStyle.DropDownList;
            cboIngredient.FormattingEnabled = true;
            cboIngredient.Location = new Point(465, 33);
            cboIngredient.Name = "cboIngredient";
            cboIngredient.Size = new Size(121, 23);
            cboIngredient.TabIndex = 5;
            // 
            // btnAddIngredient
            // 
            btnAddIngredient.BackColor = Color.FromArgb(217, 179, 130);
            btnAddIngredient.FlatStyle = FlatStyle.Flat;
            btnAddIngredient.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddIngredient.Location = new Point(153, 163);
            btnAddIngredient.Name = "btnAddIngredient";
            btnAddIngredient.Size = new Size(108, 34);
            btnAddIngredient.TabIndex = 4;
            btnAddIngredient.Text = "Add ingredient";
            btnAddIngredient.UseVisualStyleBackColor = false;
            // 
            // cboSupplier
            // 
            cboSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSupplier.FormattingEnabled = true;
            cboSupplier.Location = new Point(161, 120);
            cboSupplier.Name = "cboSupplier";
            cboSupplier.Size = new Size(100, 23);
            cboSupplier.TabIndex = 3;
            // 
            // txtReorder
            // 
            txtReorder.Location = new Point(161, 91);
            txtReorder.Name = "txtReorder";
            txtReorder.Size = new Size(100, 23);
            txtReorder.TabIndex = 2;
            // 
            // txtUnit
            // 
            txtUnit.Location = new Point(161, 62);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(100, 23);
            txtUnit.TabIndex = 1;
            // 
            // txtIngName
            // 
            txtIngName.Location = new Point(161, 33);
            txtIngName.Name = "txtIngName";
            txtIngName.Size = new Size(100, 23);
            txtIngName.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(398, 41);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 13;
            label6.Text = "Ingredient";
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 240, 231);
            ClientSize = new Size(737, 561);
            Controls.Add(pnlAdmin);
            Controls.Add(dgvStock);
            Name = "InventoryForm";
            Text = "Inventory";
            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            pnlAdmin.ResumeLayout(false);
            pnlAdmin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvStock;
        private Panel pnlAdmin;
        private TextBox txtReorder;
        private TextBox txtUnit;
        private TextBox txtIngName;
        private Button btnStockIn;
        private TextBox txtUnitCost;
        private TextBox txtQty;
        private ComboBox cboIngredient;
        private Button btnAddIngredient;
        private ComboBox cboSupplier;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label6;
    }
}