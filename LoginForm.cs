using static CoffeeManagementSystem.DatabaseHelper;

namespace CoffeeManagementSystem;

public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
        btnLogin.Click += btnLogin_Click;
        btnExit.Click += (s, e) => Application.Exit();
    }

    private void btnLogin_Click(object? sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text;

        if (username == "" || password == "")
        {
            MessageBox.Show("Enter your username and password.", "Login",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var dt = GetData(
                "SELECT UserID, FullName, PasswordHash, RoleName FROM Users WHERE Username = ?",
                P(username));

            if (dt.Rows.Count == 0 ||
                !PasswordHelper.VerifyPassword(password, dt.Rows[0]["PasswordHash"].ToString()!))
            {
                MessageBox.Show("Invalid username or password.", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            Session.UserId = Convert.ToInt32(dt.Rows[0]["UserID"]);
            Session.FullName = dt.Rows[0]["FullName"].ToString()!;
            Session.Role = dt.Rows[0]["RoleName"].ToString()!;

            txtPassword.Clear();
            var main = new MainDashboard();
            main.FormClosed += (s, a) =>
            {
                if (Session.UserId == 0) { Show(); txtUsername.Focus(); }  // logged out
                else Close();                                              // window X: exit app
            };
            Hide();
            main.Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Login failed: " + ex.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}