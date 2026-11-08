using static CoffeeManagementSystem.DatabaseHelper;

namespace CoffeeManagementSystem;

public partial class StaffForm : Form
{
    public StaffForm()
    {
        InitializeComponent();
        Load += (s, e) =>
        {
            cboRole.Items.AddRange(new object[] { "Administrator", "Cashier" });
            cboRole.SelectedIndex = 1;
            LoadStaff();
        };
        btnAdd.Click += btnAdd_Click;
        btnResetPassword.Click += btnResetPassword_Click;
    }

    private void LoadStaff()
    {
        dgvStaff.DataSource = GetData(
            "SELECT UserID, FullName AS [Full name], Username, RoleName AS [Role], CreatedDate AS [Created] " +
            "FROM Users ORDER BY FullName");
        dgvStaff.Columns["UserID"].Visible = false;
    }

    private void btnAdd_Click(object? sender, EventArgs e)
    {
        string full = txtFullName.Text.Trim();
        string user = txtUsername.Text.Trim();
        string pass = txtPassword.Text;

        if (full == "" || user == "") { MessageBox.Show("Enter the full name and username."); return; }
        if (pass.Length < 6) { MessageBox.Show("The password must be at least 6 characters."); return; }

        try
        {
            if (Convert.ToInt32(ExecuteScalar("SELECT COUNT(*) FROM Users WHERE Username = ?", P(user))) > 0)
            {
                MessageBox.Show("That username is already taken.");
                return;
            }

            ExecuteNonQuery(
                "INSERT INTO Users (FullName, Username, PasswordHash, RoleName, CreatedDate) VALUES (?, ?, ?, ?, ?)",
                P(full), P(user), P(PasswordHelper.HashPassword(pass)), P(cboRole.Text), P(DateTime.Now));

            txtFullName.Clear(); txtUsername.Clear(); txtPassword.Clear();
            LoadStaff();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not add account: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Type the new password in txtPassword, select the account, then click the button
    private void btnResetPassword_Click(object? sender, EventArgs e)
    {
        if (dgvStaff.CurrentRow == null) { MessageBox.Show("Select an account first."); return; }
        if (txtPassword.Text.Length < 6)
        { MessageBox.Show("Type a new password of at least 6 characters in the password box."); return; }

        int id = Convert.ToInt32(dgvStaff.CurrentRow.Cells["UserID"].Value);
        ExecuteNonQuery("UPDATE Users SET PasswordHash = ? WHERE UserID = ?",
            P(PasswordHelper.HashPassword(txtPassword.Text)), P(id));
        txtPassword.Clear();
        MessageBox.Show("Password reset.");
    }
}