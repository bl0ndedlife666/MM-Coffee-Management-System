namespace CoffeeManagementSystem
{
    partial class MainDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDashboard));
            lblWelcome = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            lblTodaySales = new Label();
            btnNewOrder = new Button();
            pictureBox3 = new PictureBox();
            btnMenu = new Button();
            pictureBox4 = new PictureBox();
            btnInventory = new Button();
            btnSuppliers = new Button();
            btnStaff = new Button();
            btnReports = new Button();
            btnAnalytics = new Button();
            btnLogout = new Button();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox8 = new PictureBox();
            pictureBox9 = new PictureBox();
            pictureBox10 = new PictureBox();
            label2 = new Label();
            dgvLowStock = new DataGridView();
            label3 = new Label();
            dgvToday = new DataGridView();
            btnVoid = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLowStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvToday).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.Transparent;
            lblWelcome.Location = new Point(53, 18);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(0, 30);
            lblWelcome.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(217, 179, 130);
            label1.Location = new Point(64, 49);
            label1.Name = "label1";
            label1.Size = new Size(259, 25);
            label1.TabIndex = 1;
            label1.Text = "BEANS Coffee Management";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 43);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // lblTodaySales
            // 
            lblTodaySales.AutoSize = true;
            lblTodaySales.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTodaySales.ForeColor = Color.Transparent;
            lblTodaySales.Location = new Point(555, 43);
            lblTodaySales.Name = "lblTodaySales";
            lblTodaySales.Size = new Size(0, 21);
            lblTodaySales.TabIndex = 4;
            // 
            // btnNewOrder
            // 
            btnNewOrder.FlatAppearance.BorderSize = 0;
            btnNewOrder.FlatStyle = FlatStyle.Flat;
            btnNewOrder.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewOrder.ForeColor = Color.FromArgb(217, 179, 130);
            btnNewOrder.Location = new Point(81, 102);
            btnNewOrder.Name = "btnNewOrder";
            btnNewOrder.Size = new Size(176, 62);
            btnNewOrder.TabIndex = 5;
            btnNewOrder.Text = "New Order";
            btnNewOrder.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(53, 102);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(48, 47);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // btnMenu
            // 
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu.ForeColor = Color.WhiteSmoke;
            btnMenu.Location = new Point(81, 170);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(124, 33);
            btnMenu.TabIndex = 7;
            btnMenu.Text = "Menu";
            btnMenu.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(64, 170);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(48, 33);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 8;
            pictureBox4.TabStop = false;
            // 
            // btnInventory
            // 
            btnInventory.FlatAppearance.BorderSize = 0;
            btnInventory.FlatStyle = FlatStyle.Flat;
            btnInventory.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInventory.ForeColor = Color.WhiteSmoke;
            btnInventory.Location = new Point(107, 209);
            btnInventory.Name = "btnInventory";
            btnInventory.Size = new Size(98, 33);
            btnInventory.TabIndex = 9;
            btnInventory.Text = "Inventory";
            btnInventory.UseVisualStyleBackColor = true;
            // 
            // btnSuppliers
            // 
            btnSuppliers.FlatAppearance.BorderSize = 0;
            btnSuppliers.FlatStyle = FlatStyle.Flat;
            btnSuppliers.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSuppliers.ForeColor = Color.WhiteSmoke;
            btnSuppliers.Location = new Point(99, 248);
            btnSuppliers.Name = "btnSuppliers";
            btnSuppliers.Size = new Size(106, 33);
            btnSuppliers.TabIndex = 10;
            btnSuppliers.Text = "Suppliers";
            btnSuppliers.UseVisualStyleBackColor = true;
            // 
            // btnStaff
            // 
            btnStaff.FlatAppearance.BorderSize = 0;
            btnStaff.FlatStyle = FlatStyle.Flat;
            btnStaff.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStaff.ForeColor = Color.WhiteSmoke;
            btnStaff.Location = new Point(81, 287);
            btnStaff.Name = "btnStaff";
            btnStaff.Size = new Size(109, 33);
            btnStaff.TabIndex = 11;
            btnStaff.Text = "Staff";
            btnStaff.UseVisualStyleBackColor = true;
            // 
            // btnReports
            // 
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReports.ForeColor = Color.WhiteSmoke;
            btnReports.Location = new Point(81, 326);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(124, 33);
            btnReports.TabIndex = 12;
            btnReports.Text = "Reports";
            btnReports.UseVisualStyleBackColor = true;
            // 
            // btnAnalytics
            // 
            btnAnalytics.FlatAppearance.BorderSize = 0;
            btnAnalytics.FlatStyle = FlatStyle.Flat;
            btnAnalytics.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAnalytics.ForeColor = Color.WhiteSmoke;
            btnAnalytics.Location = new Point(96, 365);
            btnAnalytics.Name = "btnAnalytics";
            btnAnalytics.Size = new Size(109, 33);
            btnAnalytics.TabIndex = 13;
            btnAnalytics.Text = "Analytics";
            btnAnalytics.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.WhiteSmoke;
            btnLogout.Location = new Point(81, 426);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(124, 33);
            btnLogout.TabIndex = 14;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(64, 287);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(48, 33);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 15;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(64, 248);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(48, 33);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 16;
            pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.Transparent;
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(64, 209);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(48, 33);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 17;
            pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = Color.Transparent;
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(64, 326);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(48, 33);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 18;
            pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            pictureBox9.BackColor = Color.Transparent;
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(64, 365);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(48, 33);
            pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox9.TabIndex = 19;
            pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            pictureBox10.BackColor = Color.Transparent;
            pictureBox10.Image = (Image)resources.GetObject("pictureBox10.Image");
            pictureBox10.Location = new Point(64, 426);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(48, 33);
            pictureBox10.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox10.TabIndex = 20;
            pictureBox10.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(64, 494);
            label2.Name = "label2";
            label2.Size = new Size(158, 25);
            label2.TabIndex = 21;
            label2.Text = "Low-stock alerts";
            // 
            // dgvLowStock
            // 
            dgvLowStock.AllowUserToAddRows = false;
            dgvLowStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLowStock.BackgroundColor = Color.FromArgb(245, 240, 231);
            dgvLowStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLowStock.Location = new Point(64, 522);
            dgvLowStock.Name = "dgvLowStock";
            dgvLowStock.ReadOnly = true;
            dgvLowStock.Size = new Size(416, 133);
            dgvLowStock.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(64, 667);
            label3.Name = "label3";
            label3.Size = new Size(240, 25);
            label3.TabIndex = 23;
            label3.Text = "Today's completed orders";
            // 
            // dgvToday
            // 
            dgvToday.AllowUserToAddRows = false;
            dgvToday.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvToday.BackgroundColor = Color.FromArgb(245, 240, 231);
            dgvToday.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvToday.Location = new Point(64, 695);
            dgvToday.Name = "dgvToday";
            dgvToday.ReadOnly = true;
            dgvToday.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvToday.Size = new Size(416, 133);
            dgvToday.TabIndex = 24;
            // 
            // btnVoid
            // 
            btnVoid.FlatAppearance.BorderSize = 0;
            btnVoid.FlatStyle = FlatStyle.Flat;
            btnVoid.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVoid.ForeColor = Color.FromArgb(217, 179, 130);
            btnVoid.Location = new Point(507, 795);
            btnVoid.Name = "btnVoid";
            btnVoid.Size = new Size(201, 33);
            btnVoid.TabIndex = 25;
            btnVoid.Text = "Void selected order";
            btnVoid.UseVisualStyleBackColor = true;
            // 
            // MainDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(48, 35, 31);
            ClientSize = new Size(846, 857);
            Controls.Add(btnVoid);
            Controls.Add(dgvToday);
            Controls.Add(label3);
            Controls.Add(dgvLowStock);
            Controls.Add(label2);
            Controls.Add(pictureBox10);
            Controls.Add(pictureBox9);
            Controls.Add(pictureBox8);
            Controls.Add(pictureBox7);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(btnLogout);
            Controls.Add(btnAnalytics);
            Controls.Add(btnReports);
            Controls.Add(btnStaff);
            Controls.Add(btnSuppliers);
            Controls.Add(btnInventory);
            Controls.Add(pictureBox4);
            Controls.Add(btnMenu);
            Controls.Add(pictureBox3);
            Controls.Add(btnNewOrder);
            Controls.Add(lblTodaySales);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(lblWelcome);
            Name = "MainDashboard";
            Text = "MainDashboard";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLowStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvToday).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Label label1;
        private PictureBox pictureBox1;
        private Label lblTodaySales;
        private Button btnNewOrder;
        private PictureBox pictureBox3;
        private Button btnMenu;
        private PictureBox pictureBox4;
        private Button btnInventory;
        private Button btnSuppliers;
        private Button btnStaff;
        private Button btnReports;
        private Button btnAnalytics;
        private Button btnLogout;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
        private PictureBox pictureBox10;
        private Label label2;
        private DataGridView dgvLowStock;
        private Label label3;
        private DataGridView dgvToday;
        private Button btnVoid;
    }
}