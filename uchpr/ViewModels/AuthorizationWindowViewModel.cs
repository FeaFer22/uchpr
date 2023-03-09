using MySql.Data.MySqlClient;
using Org.BouncyCastle.Operators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using uchpr.Utilities;
using uchpr.Utilities.Commands;
using uchpr.ViewModels.Base;
using uchpr.Views.AuthorizationWindow;

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

        #region Статус Входа
        private string _authorizationStatus = "...";
        public string AuthorizationStatus
        {
            get => _authorizationStatus;
            set
            {
                Set(ref _authorizationStatus, value);
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

        MainWindow mainWindow;
        public AuthorizationWindowViewModel()
        {
            MySqlConnection connection = DBUtilities.GetDBConnection();
            try
            {
                _connectionStatus = "Openning connection";
                connection.Open();
                _connectionStatus = "Connection successeful!";
            }
            catch (Exception)
            {
                _connectionStatus = "Connection error!";
                connection.Close();
            }
            UserAuthentificationCommand = new ActionCommand(OnUserAuthentificationCommandExecuted, CanUserAuthentificationCommandExecute);
        }

        #region Commands

        #region UserAuthentificationCommand
        public ICommand UserAuthentificationCommand { get; }

        private bool CanUserAuthentificationCommandExecute(object obj) => true;

        private void OnUserAuthentificationCommandExecuted(object obj)
        {
            UserAuthentification();
        }
        #endregion

        #endregion


        public void UserAuthentification()
        {
            string queryString = "select * from employee where login = @login and password = @password";
            DataTable dataTable = new();
            MySqlDataAdapter dataAdapter = new();

            MySqlCommand sqlCommand = new(queryString, DBUtilities.GetDBConnection());
            sqlCommand.Parameters.Add("@login", MySqlDbType.VarChar).Value = _login;
            sqlCommand.Parameters.Add("@password", MySqlDbType.VarChar).Value = _password;

            dataAdapter.SelectCommand = sqlCommand;
            dataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                AuthorizationStatus = "Авторизован";
                mainWindow = new MainWindow();
                mainWindow.Show();
                Application.Current.MainWindow.Close();
            }
            else
            {
                AuthorizationStatus = "Не удалось авторизировать";
            }

        }
    }
}