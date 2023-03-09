using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uchpr.Utilities
{
    class DBConnection
    {
        public static MySqlConnection GetDBConnection(string connectionString)
        {

            MySqlConnection connection = new MySqlConnection(connectionString);

            return connection;
        }
    }
}
