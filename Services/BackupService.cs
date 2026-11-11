namespace CoffeeManagementSystem;

public static class BackupService
{
    // Copies the database into a Backups folder and keeps only the newest copies.
    // Returns the new file path, or null if the backup failed.
    public static string? Run(int keep = 14)
    {
        try
        {
            string source = DatabaseHelper.DbPath;
            string folder = Path.Combine(Path.GetDirectoryName(source)!, "Backups");
            Directory.CreateDirectory(folder);

            string target = Path.Combine(folder, $"CoffeeDB_{DateTime.Now:yyyyMMdd_HHmmss}.accdb");
            File.Copy(source, target, true);

            foreach (var old in new DirectoryInfo(folder).GetFiles("CoffeeDB_*.accdb")
                         .OrderByDescending(f => f.CreationTime).Skip(keep))
                old.Delete();

            return target;
        }
        catch
        {
            return null;
        }
    }
}