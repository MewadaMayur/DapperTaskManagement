using Microsoft.Data.SqlClient;

namespace SilveOakDemo.Models
{
    public static class Connection
    {

        public static string ConnectionString { get; private set; }

        public static void Initialize(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
