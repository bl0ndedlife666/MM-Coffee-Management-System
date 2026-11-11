namespace CoffeeManagementSystem
{
    partial class OrderForm
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
            cboCategory = new ComboBox();
            dgvMenu = new DataGridView();
            cboSize = new ComboBox();
            nudQty = new NumericUpDown();
            btnAdd = new Button();
            dgvCart = new DataGridView();
            btnRemove = new Button();
            btnClear = new Button();
            txtDiscount = new TextBox();
            cboPayment = new ComboBox();
            txtCash = new TextBox();
            lblSubtotal = new Label();
            lblTotal = new Label();
            lblChange = new Label();
            btnCheckout = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cboOrderType = new ComboBox();
            txtCustomer = new TextBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(43, 22);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(129, 25);
            cboCategory.TabIndex = 0;
            // 
            // dgvMenu
            // 
            dgvMenu.AllowUserToAddRows = false;
            dgvMenu.BackgroundColor = Color.FromArgb(217, 179, 130);
            dgvMenu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMenu.Location = new Point(43, 53);
            dgvMenu.MultiSelect = false;
            dgvMenu.Name = "dgvMenu";
            dgvMenu.ReadOnly = true;
            dgvMenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMenu.Size = new Size(383, 244);
            dgvMenu.TabIndex = 1;
            // 
            // cboSize
            // 
            cboSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSize.FormattingEnabled = true;
            cboSize.Location = new Point(43, 303);
            cboSize.Name = "cboSize";
            cboSize.Size = new Size(129, 25);
            cboSize.TabIndex = 2;
            // 
            // nudQty
            // 
            nudQty.Location = new Point(43, 334);
            nudQty.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQty.Name = "nudQty";
            nudQty.Size = new Size(120, 25);
            nudQty.TabIndex = 3;
            nudQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(217, 179, 130);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(43, 365);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(98, 37);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add to order";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.BackgroundColor = Color.FromArgb(217, 179, 130);
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(446, 53);
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(574, 163);
            dgvCart.TabIndex = 5;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.FromArgb(217, 179, 130);
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemove.Location = new Point(510, 222);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(128, 42);
            btnRemove.TabIndex = 6;
            btnRemove.Text = "Remove selected";
            btnRemove.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(185, 74, 72);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(789, 222);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(128, 42);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear order";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // txtDiscount
            // 
            txtDiscount.Location = new Point(517, 272);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(100, 25);
            txtDiscount.TabIndex = 8;
            txtDiscount.Text = "0";
            // 
            // cboPayment
            // 
            cboPayment.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPayment.FormattingEnabled = true;
            cboPayment.Location = new Point(517, 304);
            cboPayment.Name = "cboPayment";
            cboPayment.Size = new Size(121, 25);
            cboPayment.TabIndex = 9;
            // 
            // txtCash
            // 
            txtCash.Location = new Point(518, 334);
            txtCash.Name = "txtCash";
            txtCash.Size = new Size(100, 25);
            txtCash.TabIndex = 10;
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(524, 365);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(94, 19);
            lblSubtotal.TabIndex = 11;
            lblSubtotal.Text = "Subtotal: 0.00";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(524, 385);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(81, 17);
            lblTotal.TabIndex = 12;
            lblTotal.Text = "TOTAL: 0.00";
            // 
            // lblChange
            // 
            lblChange.AutoSize = true;
            lblChange.Location = new Point(524, 402);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(90, 19);
            lblChange.TabIndex = 13;
            lblChange.Text = "Change: 0.00";
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.FromArgb(48, 35, 31);
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCheckout.ForeColor = Color.FromArgb(217, 179, 130);
            btnCheckout.Location = new Point(683, 334);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(234, 42);
            btnCheckout.TabIndex = 14;
            btnCheckout.Text = "Complete order and print receipt";
            btnCheckout.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(455, 280);
            label1.Name = "label1";
            label1.Size = new Size(63, 17);
            label1.TabIndex = 15;
            label1.Text = "Discount";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(455, 312);
            label2.Name = "label2";
            label2.Size = new Size(62, 17);
            label2.TabIndex = 16;
            label2.Text = "Payment";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(426, 342);
            label3.Name = "label3";
            label3.Size = new Size(92, 17);
            label3.TabIndex = 17;
            label3.Text = "Cash received";
            // 
            // cboOrderType
            // 
            cboOrderType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOrderType.FormattingEnabled = true;
            cboOrderType.Location = new Point(886, 451);
            cboOrderType.Name = "cboOrderType";
            cboOrderType.Size = new Size(121, 25);
            cboOrderType.TabIndex = 18;
            // 
            // txtCustomer
            // 
            txtCustomer.Location = new Point(907, 420);
            txtCustomer.Name = "txtCustomer";
            txtCustomer.Size = new Size(100, 25);
            txtCustomer.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(789, 423);
            label4.Name = "label4";
            label4.Size = new Size(112, 19);
            label4.TabIndex = 20;
            label4.Text = "Customer / Table";
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(121, 85, 72);
            ClientSize = new Size(1084, 692);
            Controls.Add(label4);
            Controls.Add(txtCustomer);
            Controls.Add(cboOrderType);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCheckout);
            Controls.Add(lblChange);
            Controls.Add(lblTotal);
            Controls.Add(lblSubtotal);
            Controls.Add(txtCash);
            Controls.Add(cboPayment);
            Controls.Add(txtDiscount);
            Controls.Add(btnClear);
            Controls.Add(btnRemove);
            Controls.Add(dgvCart);
            Controls.Add(btnAdd);
            Controls.Add(nudQty);
            Controls.Add(cboSize);
            Controls.Add(dgvMenu);
            Controls.Add(cboCategory);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(48, 35, 31);
            MinimumSize = new Size(1000, 600);
            Name = "OrderForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New Order";
            ((System.ComponentModel.ISupportInitialize)dgvMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboCategory;
        private DataGridView dgvMenu;
        private ComboBox cboSize;
        private NumericUpDown nudQty;
        private Button btnAdd;
        private DataGridView dgvCart;
        private Button btnRemove;
        private Button btnClear;
        private TextBox txtDiscount;
        private ComboBox cboPayment;
        private TextBox txtCash;
        private Label lblSubtotal;
        private Label lblTotal;
        private Label lblChange;
        private Button btnCheckout;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cboOrderType;
        private TextBox txtCustomer;
        private Label label4;
    }
}