namespace CoffeeManagementSystem;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        try
        {
            DbSetup.EnsureCreated();
            DbSetup.EnsureColumns();
            DbSetup.SeedIfEmpty();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Database error: " + ex.Message, "Coffee Management System",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        Application.Run(new LoginForm());
    }
}