using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uchpr.Utilities.Commands;
using uchpr.Utilities;
using uchpr.ViewModels.Base;
using uchpr.Models;
using System.Data;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows.Input;
using uchpr.Views.AuthorizationWindow;
using System.Windows;
using Mysqlx.Crud;

namespace uchpr.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        SQLUtilities sqlUtilities;
        AuthorizationWindow authorizationWindow { get; set; }
        WindowsManagement windowsManagement;
        string queryString;


        #region Id
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                Set(ref _id, value);
            }
        }
        #endregion
        #region Date
        private string _date;
        public string Date
        {
            get => _date;
            set
            {
                Set(ref _date, value);
            }
        }
        #endregion
        #region ClientCode
        private int _clientCode;
        public int ClientCode
        {
            get => _clientCode;
            set
            {
                Set(ref _clientCode, value);
            }
        }
        #endregion
        #region ServiceCode
        private int _serviceCode;
        public int ServiceCode
        {
            get => _serviceCode;
            set
            {
                Set(ref _serviceCode, value);
            }
        }
        #endregion
        #region EmployeeCode
        private int _employeeCode;
        public int EmployeeCode
        {
            get => _employeeCode;
            set
            {
                Set(ref _employeeCode, value);
            }
        }
        #endregion
        #region Discount
        private int _discount;
        public int Discount
        {
            get => _discount;
            set
            {
                Set(ref _discount, value);
            }
        }
        #endregion
        #region State
        private string _state;
        public string State
        {
            get => _state;
            set
            {
                Set(ref _state, value);
            }
        }
        #endregion

        MySqlConnection sqlConnection;

        public MainWindowViewModel()
        {
            sqlUtilities = new SQLUtilities();
            sqlConnection = DBUtilities.GetDBConnection();
            authorizationWindow = new AuthorizationWindow();
            LogoutCommand = new ActionCommand(OnLogoutCommandExecuted, CanLogoutCommandExecute);
            SaveOrderCommand = new ActionCommand(OnSaveOrderCommandExecuted, CanSaveOrderCommandExecute);
        }

        #region Commands

        #region LogoutCommand
        public ICommand LogoutCommand { get; set; }

        private bool CanLogoutCommandExecute(object obj) => true;

        private void OnLogoutCommandExecuted(object obj)
        {
            Logout();
        }
        #endregion

        #region SaveOrderCommand
        public ICommand SaveOrderCommand { get; set; }

        private bool CanSaveOrderCommandExecute(object obj) => true;

        private void OnSaveOrderCommandExecuted(object obj)
        {
            SaveOrder();
        }
        #endregion

        #endregion

        public void SaveOrder()
        {
            queryString = "insert into orders values(@Id, @Date, @ClientCode, @ServiceCode, @EmployeeCode, @Discount, @State);";

            sqlConnection.Open();

            MySqlCommand sqlCommand = sqlUtilities.PullData(queryString);

            sqlUtilities.AddTypeValue(sqlCommand, "@Id", MySqlDbType.Int32, Id.ToString());
            sqlUtilities.AddTypeValue(sqlCommand, "@Date", MySqlDbType.VarChar, Date);
            sqlUtilities.AddTypeValue(sqlCommand, "@ClientCode", MySqlDbType.Int32, ClientCode.ToString());
            sqlUtilities.AddTypeValue(sqlCommand, "@ServiceCode", MySqlDbType.Int32, ServiceCode.ToString());
            sqlUtilities.AddTypeValue(sqlCommand, "@EmployeeCode", MySqlDbType.Int32, EmployeeCode.ToString());
            sqlUtilities.AddTypeValue(sqlCommand, "@Discount", MySqlDbType.Int32, Discount.ToString());
            sqlUtilities.AddTypeValue(sqlCommand, "@State", MySqlDbType.VarChar, State);

            sqlCommand.ExecuteReader();
            sqlConnection.Close();
        }

        public void ShowClients()
        {
            queryString = "select * from clients";
            MySqlCommand sqlCommand = sqlUtilities.PullData(queryString);
            DataTable dataTable = new();

            dataTable = sqlUtilities.FillDataTable(sqlCommand, dataTable);


        }

        public void ShowServices()
        {
            queryString = "select * from service";
            MySqlCommand sqlCommand = sqlUtilities.PullData(queryString);
            DataTable dataTable = new();

            dataTable = sqlUtilities.FillDataTable(sqlCommand, dataTable);
        }


        public void Logout()
        {
            windowsManagement = new();
            authorizationWindow = new();
            windowsManagement.SwitchWindow(authorizationWindow);
        }
    }
}
