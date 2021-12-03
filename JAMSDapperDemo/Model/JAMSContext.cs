using System.Data;
using Microsoft.Data.SqlClient;

namespace JAMSDapperDemo.Model
{
    /// <summary>
    /// Dapper context
    /// </summary>
    public class JAMSDapperContext
    {
        /// <summary>
        /// JAMS db connection string
        /// </summary>
        private readonly string _connectionString = "Server=HSATP-JH1CGG3;Database=JAMS;Trusted_Connection=True;";

        /// <summary>
        /// Creates new instance of JAMS connection
        /// </summary>
        /// <returns></returns>
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
