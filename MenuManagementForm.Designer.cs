namespace CoffeeManagementSystem
{
    partial class MenuManagementForm
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
            dgvItems = new DataGridView();
            txtName = new TextBox();
            cboCategory = new ComboBox();
            txtPrice = new TextBox();
            chkActive = new CheckBox();
            btnNew = new Button();
            btnSave = new Button();
            dgvRecipe = new DataGridView();
            cboIngredient = new ComboBox();
            txtQtyUsed = new TextBox();
            btnAddIngredient = new Button();
            btnRemoveIngredient = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRecipe).BeginInit();
            SuspendLayout();
            // 
            // dgvItems
            // 
            dgvItems.AllowUserToAddRows = false;
            dgvItems.BackgroundColor = Color.White;
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Location = new Point(3, 1);
            dgvItems.Name = "dgvItems";
            dgvItems.ReadOnly = true;
            dgvItems.Size = new Size(452, 309);
            dgvItems.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtName.Location = new Point(3, 316);
            txtName.Multiline = true;
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Item name";
            txtName.Size = new Size(116, 23);
            txtName.TabIndex = 1;
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(125, 316);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(125, 23);
            cboCategory.TabIndex = 2;
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrice.Location = new Point(339, 316);
            txtPrice.Multiline = true;
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(116, 23);
            txtPrice.TabIndex = 3;
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Checked = true;
            chkActive.CheckState = CheckState.Checked;
            chkActive.ForeColor = Color.FromArgb(48, 35, 31);
            chkActive.Location = new Point(3, 345);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(190, 19);
            chkActive.TabIndex = 4;
            chkActive.Text = "Active (shown on order screen)";
            chkActive.TextAlign = ContentAlignment.BottomCenter;
            chkActive.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(121, 85, 72);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(3, 379);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(97, 44);
            btnNew.TabIndex = 5;
            btnNew.Text = "New item";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(217, 179, 130);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.FromArgb(48, 35, 31);
            btnSave.Location = new Point(247, 379);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(97, 44);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save item";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // dgvRecipe
            // 
            dgvRecipe.BackgroundColor = Color.White;
            dgvRecipe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecipe.Location = new Point(470, 1);
            dgvRecipe.Name = "dgvRecipe";
            dgvRecipe.Size = new Size(452, 153);
            dgvRecipe.TabIndex = 7;
            // 
            // cboIngredient
            // 
            cboIngredient.DropDownStyle = ComboBoxStyle.DropDownList;
            cboIngredient.FormattingEnabled = true;
            cboIngredient.Location = new Point(470, 165);
            cboIngredient.Name = "cboIngredient";
            cboIngredient.Size = new Size(105, 23);
            cboIngredient.TabIndex = 8;
            // 
            // txtQtyUsed
            // 
            txtQtyUsed.Location = new Point(470, 196);
            txtQtyUsed.Multiline = true;
            txtQtyUsed.Name = "txtQtyUsed";
            txtQtyUsed.PlaceholderText = "Quantity per serving";
            txtQtyUsed.Size = new Size(116, 31);
            txtQtyUsed.TabIndex = 9;
            // 
            // btnAddIngredient
            // 
            btnAddIngredient.BackColor = Color.FromArgb(121, 85, 72);
            btnAddIngredient.FlatStyle = FlatStyle.Flat;
            btnAddIngredient.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddIngredient.ForeColor = Color.White;
            btnAddIngredient.Location = new Point(470, 235);
            btnAddIngredient.Name = "btnAddIngredient";
            btnAddIngredient.Size = new Size(156, 44);
            btnAddIngredient.TabIndex = 10;
            btnAddIngredient.Text = "Add / replace ingredient";
            btnAddIngredient.UseVisualStyleBackColor = false;
            // 
            // btnRemoveIngredient
            // 
            btnRemoveIngredient.BackColor = Color.FromArgb(185, 74, 72);
            btnRemoveIngredient.FlatStyle = FlatStyle.Flat;
            btnRemoveIngredient.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemoveIngredient.ForeColor = Color.White;
            btnRemoveIngredient.Location = new Point(695, 235);
            btnRemoveIngredient.Name = "btnRemoveIngredient";
            btnRemoveIngredient.Size = new Size(212, 44);
            btnRemoveIngredient.TabIndex = 11;
            btnRemoveIngredient.Text = "Remove selected ingredient";
            btnRemoveIngredient.UseVisualStyleBackColor = false;
            // 
            // MenuManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 240, 231);
            ClientSize = new Size(934, 611);
            Controls.Add(btnRemoveIngredient);
            Controls.Add(btnAddIngredient);
            Controls.Add(txtQtyUsed);
            Controls.Add(cboIngredient);
            Controls.Add(dgvRecipe);
            Controls.Add(btnSave);
            Controls.Add(btnNew);
            Controls.Add(chkActive);
            Controls.Add(txtPrice);
            Controls.Add(cboCategory);
            Controls.Add(txtName);
            Controls.Add(dgvItems);
            ForeColor = Color.FromArgb(48, 35, 31);
            Name = "MenuManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MenuManagement";
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRecipe).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvItems;
        private TextBox txtName;
        private ComboBox cboCategory;
        private TextBox txtPrice;
        private CheckBox chkActive;
        private Button btnNew;
        private Button btnSave;
        private DataGridView dgvRecipe;
        private ComboBox cboIngredient;
        private TextBox txtQtyUsed;
        private Button btnAddIngredient;
        private Button btnRemoveIngredient;
    }
}