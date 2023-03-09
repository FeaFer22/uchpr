using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uchpr.Utilities
{
    class DBUtilities
    {
        public static MySqlConnection GetDBConnection()
        {
            string connectionString = "Server=localhost;Database=uchpr;port=3306;User id=sa;password=root";

            return DBConnection.GetDBConnection(connectionString);
        }
    }
}