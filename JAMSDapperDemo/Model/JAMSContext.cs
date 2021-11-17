using System.Data;
using Microsoft.Data.SqlClient;

namespace JAMSDapperDemo.Model
{
    public class JAMSDapperContext
    {
        private readonly string _connectionString = "Server=HSATP-JH1CGG3;Database=JAMS;Trusted_Connection=True;";

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
