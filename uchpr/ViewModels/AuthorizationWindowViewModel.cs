using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uchpr.Utilities;
using uchpr.ViewModels.Base;

namespace uchpr.ViewModels
{
    public class AuthorizationWindowViewModel : ViewModel
    {
        #region Статус Подключения
        private string _connectionStatus = "...";
        public string ConnectionStatus
        {
            get => _connectionStatus;
            set
            {
                Set(ref _connectionStatus, value);
            }
        }
        #endregion

        #region Логин
        private string _login = "";
        public string Login
        {
            get => _login;
            set
            {
                Set(ref _login, value);
            }
        }
        #endregion

        #region Пароль
        private string _password = "";
        public string Password
        {
            get => _password;
            set
            {
                Set(ref _password, value);
            }
        }
        #endregion

        public AuthorizationWindowViewModel()
        {
            UserAuthentification();
        }

        //public string SqlCommand(string query, MySqlConnection connection)
        //{
        //    MySqlCommand command = new MySqlCommand(query, connection);

        //    MySqlDataReader reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        reader[0].ToString();
        //    }
        //    reader.Close();

        //    return reader[0].ToString();
        //}

        public void UserAuthentification()
        {
            MySqlConnection connection = DBUtilities.GetDBConnection();
            try
            {
                _connectionStatus = "Openning connection";
                connection.Open();
                _connectionStatus = "Connection successeful!";
            }
            catch (Exception ex)
            {
                _connectionStatus = "Connection error!";
            }
        }
    }
}