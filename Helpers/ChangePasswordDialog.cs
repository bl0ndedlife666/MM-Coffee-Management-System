using static CoffeeManagementSystem.DatabaseHelper;

namespace CoffeeManagementSystem;

public static class ChangePasswordDialog
{
    public static void Show()
    {
        using var f = new Form
        {
            Text = "Change Password",
            StartPosition = FormStartPosition.CenterScreen,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false,
            ClientSize = new Size(330, 190)
        };

        var txtOld = new TextBox { UseSystemPasswordChar = true, Left = 120, Top = 15, Width = 190 };
        var txtNew = new TextBox { UseSystemPasswordChar = true, Left = 120, Top = 55, Width = 190 };
        var txtConfirm = new TextBox { UseSystemPasswordChar = true, Left = 120, Top = 95, Width = 190 };
        var btnSave = new Button { Text = "Save", Left = 120, Top = 140, Width = 90 };
        var btnCancel = new Button { Text = "Cancel", Left = 220, Top = 140, Width = 90, DialogResult = DialogResult.Cancel };

        f.Controls.AddRange(new Control[]
        {
            new Label { Text = "Current", Left = 15, Top = 18, Width = 100 }, txtOld,
            new Label { Text = "New", Left = 15, Top = 58, Width = 100 }, txtNew,
            new Label { Text = "Confirm new", Left = 15, Top = 98, Width = 100 }, txtConfirm,
            btnSave, btnCancel
        });
        f.AcceptButton = btnSave;
        f.CancelButton = btnCancel;

        btnSave.Click += (s, e) =>
        {
            string? stored = ExecuteScalar("SELECT PasswordHash FROM Users WHERE UserID = ?", P(Session.UserId))?.ToString();
            if (stored == null || !PasswordHelper.VerifyPassword(txtOld.Text, stored))
            { MessageBox.Show("Your current password is wrong."); return; }
            if (txtNew.Text.Length < 6)
            { MessageBox.Show("The new password must be at least 6 characters."); return; }
            if (txtNew.Text != txtConfirm.Text)
            { MessageBox.Show("The new passwords do not match."); return; }

            ExecuteNonQuery("UPDATE Users SET PasswordHash = ? WHERE UserID = ?",
                P(PasswordHelper.HashPassword(txtNew.Text)), P(Session.UserId));
            MessageBox.Show("Password changed.");
            f.DialogResult = DialogResult.OK;
        };

        f.ShowDialog();
    }
}