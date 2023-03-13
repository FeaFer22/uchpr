using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using uchpr.Models;
using uchpr.Utilities;
using uchpr.Utilities.Commands;
using uchpr.ViewModels.Base;

namespace uchpr.ViewModels
{
    public class AuthorizationWindowViewModel : ViewModel
    {
        #region Статус Входа
        private string _authorizationStatus = "";
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
        private string _login;
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

        MySqlConnection connection;
        WindowsManagement windowsManagement;
        Task task;
        public AuthorizationWindowViewModel()
        {
            connection = DBUtilities.GetDBConnection();
            windowsManagement = new();
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
            try
            {
                connection.Open();
                var query =
                    $"SELECT * FROM employee " +
                    $"WHERE login = {_login} " +
                    $"AND password = {_password}";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                Employee result = null;
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    result = new Employee
                    {
                        id = dataReader.GetInt16("id"),
                        name = dataReader.GetString("name")
                    };
                }

                dataReader.Close();

                if (result != null)
                {
                    MainWindow mainWindow;
                    AuthorizationStatus = "Успешная авторизация";
                    windowsManagement.SwitchWindow(mainWindow = new());
                }
                else
                {
                    AuthorizationStatus = "Логин или пароль неверны";
                }

                connection.Close();
            }
            catch
            {
            }
        }
    }
}