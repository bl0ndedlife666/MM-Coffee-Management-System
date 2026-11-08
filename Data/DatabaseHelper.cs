namespace CoffeeManagementSystem;

public static class DatabaseHelper
{
    private static string DbPath =>
        Path.Combine(AppContext.BaseDirectory, "CoffeeDB.accdb");

    public static string ConnectionString =>
        $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={DbPath};Persist Security Info=False;";

    // Positional parameter helper. Access/OleDb uses ? placeholders,
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