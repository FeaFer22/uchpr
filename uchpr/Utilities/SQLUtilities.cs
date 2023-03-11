using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uchpr.Models;

namespace uchpr.Utilities
{
    internal class SQLUtilities
    {
        public MySqlCommand PullData(string query)
        {
            return new(query, DBUtilities.GetDBConnection());

        }
        public MySqlCommand AddTypeValue(MySqlCommand sqlCommand, string plug, MySqlDbType type, string value)
        {
            sqlCommand.Parameters.Add(plug, type).Value = value;
            return sqlCommand;
        }
        public DataTable FillDataTable(MySqlCommand sqlCommand, DataTable dataTable)
        {
            MySqlDataAdapter dataAdapter = new();
            dataAdapter.SelectCommand = sqlCommand;
            dataAdapter.Fill(dataTable);
            return dataTable;
        }
    }
}
