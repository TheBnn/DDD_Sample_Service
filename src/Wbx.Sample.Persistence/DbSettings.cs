namespace Wbx.Sample.Persistence;

public class DbSettings
{
    public string Server { get; set; }
    public string Database { get; set; }
    public string User { get; set; }
    public string Port { get; set; }
    public string Password { get; set; }

    private string connectionString;
    public string ConnectionString
    {
        get
        {
            if (connectionString != null)
            {
                return connectionString;
            }
            return connectionString =
                $"Server={Server}; Database={Database}; Port={Port}; User Id={User}; Password={Password}; CommandTimeout=120";
        }
    }
}
