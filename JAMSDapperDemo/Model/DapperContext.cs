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
        private readonly string _connectionString = "";

        /// <summary>
        /// Creates new instance of JAMS connection
        /// </summary>
        /// <returns></returns>
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
