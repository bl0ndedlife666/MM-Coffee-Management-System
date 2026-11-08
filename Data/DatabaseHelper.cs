namespace CoffeeManagementSystem;

public static class DatabaseHelper
{
    private static string? _dbPath;

    // The live database lives outside the build folder so rebuilds never erase it.
    // The CoffeeDB.accdb in the project is only the starting template.
    public static string DbPath
    {
        get
        {
            if (_dbPath != null) return _dbPath;

            string folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "CoffeeManagementSystem");
            Directory.CreateDirectory(folder);

            string target = Path.Combine(folder, "CoffeeDB.accdb");
            string template = Path.Combine(AppContext.BaseDirectory, "CoffeeDB.accdb");

            if (!File.Exists(target))
            {
                if (!File.Exists(template))
                    throw new FileNotFoundException("CoffeeDB.accdb template was not found next to the program.");
                File.Copy(template, target);
            }

            _dbPath = target;
            return target;
        }
    }

    public static string ConnectionString =>
        $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={DbPath};Persist Security Info=False;";

    // Positional parameter helper. OleDb uses ? placeholders,
    // so parameters must be supplied in the same order as the ?s.
    public static OleDbParameter P(object? value)
    {
        return value switch
        {
            null => new OleDbParameter("?", DBNull.Value),
            DateTime d => new OleDbParameter("?", OleDbType.Date) { Value = d },
            decimal m => new OleDbParameter("?", OleDbType.Currency) { Value = m },
            _ => new OleDbParameter("?", value)
        };
    }

    public static DataTable GetData(string sql, params OleDbParameter[] parameters)
    {
        using var conn = new OleDbConnection(ConnectionString);
        using var cmd = new OleDbCommand(sql, conn);
        cmd.Parameters.AddRange(parameters);
        using var adapter = new OleDbDataAdapter(cmd);
        var table = new DataTable();
        adapter.Fill(table);
        return table;
    }

    public static int ExecuteNonQuery(string sql, params OleDbParameter[] parameters)
    {
        using var conn = new OleDbConnection(ConnectionString);
        using var cmd = new OleDbCommand(sql, conn);
        cmd.Parameters.AddRange(parameters);
        conn.Open();
        return cmd.ExecuteNonQuery();
    }

    public static object? ExecuteScalar(string sql, params OleDbParameter[] parameters)
    {
        using var conn = new OleDbConnection(ConnectionString);
        using var cmd = new OleDbCommand(sql, conn);
        cmd.Parameters.AddRange(parameters);
        conn.Open();
        var result = cmd.ExecuteScalar();
        return result == DBNull.Value ? null : result;
    }
}