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
            MySqlConnection connection = DBUtilities.GetDBConnection();
            return new(query, connection);

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
            try
            {
                dataAdapter.Fill(dataTable);
            }
            catch (MySqlException) { }

            return dataTable;
        }
        public DataSet FillDataSet(MySqlCommand sqlCommand, DataSet dataSet)
        {
            MySqlDataAdapter dataAdapter = new();
            dataAdapter.SelectCommand = sqlCommand;
            try
            {
                dataAdapter.Fill(dataSet);
            }
            catch (MySqlException) { }

            return dataSet;
        }
    }
}
