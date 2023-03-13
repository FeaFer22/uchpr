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
using System.Diagnostics;
using System.ComponentModel;
using System.Collections;
using uchpr.Interfaces;

namespace uchpr.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region INotifyProperties

        #region ClientComboBoxItemsSource
        private IList _serviceComboBoxItemsSource;
        public IList ClientComboBoxItemsSource
        {
            get => _serviceComboBoxItemsSource;
            set
            {
                Set(ref _serviceComboBoxItemsSource, value);
            }
        }
        #endregion

        #region ClientComboBoxDisplayMemberPath

        private string _clientComboBoxDisplayMemberPath;
        public string ClientComboBoxDisplayMemberPath
        {
            get => _clientComboBoxDisplayMemberPath;
            set
            {
                Set(ref _clientComboBoxDisplayMemberPath, value);
            }
        }
        #endregion

        #region ClientComboBoxSelectedValuePath
        private string _сlientComboBoxSelectedValuePath;
        public string ClientComboBoxSelectedValuePath
        {
            get => _сlientComboBoxSelectedValuePath;
            set
            {
                Set(ref _сlientComboBoxSelectedValuePath, value);
            }
        }
        #endregion

        #region ClientComboBoxSelectedValue
        private string _serviceComboBoxSelectedValue;
        public string ClientComboBoxSelectedValue
        {
            get => _serviceComboBoxSelectedValue;
            set
            {
                Set(ref _serviceComboBoxSelectedValue, value);
            }
        }
        #endregion

        #region ServiceComboBoxItemsSource
        private IList _serviceComboBoxBoxItemsSource;
        public IList ServiceComboBoxItemsSource
        {
            get => _serviceComboBoxBoxItemsSource;
            set
            {
                Set(ref _serviceComboBoxBoxItemsSource, value);
            }
        }
        #endregion

        #region ServiceComboBoxDisplayMemberPath

        private string _serviceComboBoxDisplayMemberPath;
        public string ServiceComboBoxDisplayMemberPath
        {
            get => _serviceComboBoxDisplayMemberPath;
            set
            {
                Set(ref _serviceComboBoxDisplayMemberPath, value);
            }
        }
        #endregion

        #region ServiceComboBoxSelectedValuePath
        private string _serviceComboBoxSelectedValuePath;
        public string ServiceComboBoxSelectedValuePath
        {
            get => _serviceComboBoxSelectedValuePath;
            set
            {
                Set(ref _serviceComboBoxSelectedValuePath, value);
            }
        }
        #endregion

        #region ServiceComboBoxSelectedValue
        private string _serviceBoxSelectedValue;
        public string ServiceComboBoxSelectedValue
        {
            get => _serviceComboBoxSelectedValue;
            set
            {
                Set(ref _serviceBoxSelectedValue, value);
            }
        }
        #endregion

        #region OrdersDataGridItemsSource
        private IList _ordersDataGridItemsSource;
        public IList OrdersDataGridItemsSource
        {
            get => _ordersDataGridItemsSource;
            set
            {
                Set(ref _ordersDataGridItemsSource, value);
            }
        }
        #endregion

        #region WelcomeLabel
        private string _welcomeLabel;
        public string WelcomeLabel
        {
            get => _welcomeLabel;
            set
            {
                Set(ref _welcomeLabel, value);
            }
        }
        #endregion

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

        #region Текущий пользователь
        private Employee _employee = null;
        public Employee Employee
        {
            get => _employee;
            set
            {
                Set(ref _employee, value);
            }
        }
        #endregion

        #endregion

        #region Fields
        private SQLUtilities sqlUtilities;
        private AuthorizationWindow authorizationWindow { get; set; }

        private WindowsManagement windowsManagement;

        private MySqlConnection sqlConnection;
        

        private List<Order> orders = new List<Order>();
        private List<Service> services = new List<Service>();
        private List<Client> clients = new List<Client>();
        #endregion
        public MainWindowViewModel()
        {
            sqlUtilities = new SQLUtilities();
            sqlConnection = DBUtilities.GetDBConnection();
            authorizationWindow = new AuthorizationWindow();

            FillDataGrid();
            FillClientComboBox();
            FillServiceComboBox();

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
            AddOrder();
        }
        #endregion

        #endregion

        private void FillClientComboBox()
        {
            sqlConnection.Open();
            string queryString = "select * from client";
            MySqlCommand cmd = new MySqlCommand(queryString, sqlConnection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            clients.Clear();
            while (dataReader.Read())
            {
                clients.Add(new Client
                {
                    id = dataReader.GetInt16("id"),
                    name = dataReader.GetString("name"),
                    address = dataReader.GetString("address"),
                    phone = dataReader.GetString("phone")
                });
            }
            dataReader.Close();
            sqlConnection.Close();

            ClientComboBoxItemsSource = clients;
            ClientComboBoxDisplayMemberPath = "name";
            ClientComboBoxSelectedValuePath = "id";
        }
        private void FillServiceComboBox()
        {
            sqlConnection.Open();
            string queryString = "select * from service";
            MySqlCommand cmd = new MySqlCommand(queryString, sqlConnection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            services.Clear();
            while (dataReader.Read())
            {
                services.Add(new Service
                {
                    id = dataReader.GetInt16("id"),
                    name = dataReader.GetString("name"),
                    description = dataReader.GetString("description"),
                    price = dataReader.GetString("price")
                });
            }
            dataReader.Close();
            sqlConnection.Close();

            ServiceComboBoxItemsSource = services;
            ServiceComboBoxDisplayMemberPath = "name";
            ServiceComboBoxSelectedValuePath = "id";
        }
        private void FillDataGrid()
        {
            sqlConnection.Open();
            string queryString = $"SELECT orders.id, orders.date, orders.discount, orders.state, client.name, employee.name, service.name FROM orders " +
                $"JOIN client on client_code = client.id " +
                $"JOIN employee on employee_code = employee.id " +
                $"JOIN service on service_code = service.id; "; 
            MySqlCommand cmd = new MySqlCommand(queryString, sqlConnection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            orders.Clear();
            while (dataReader.Read())
            {
                orders.Add(new Order
                {
                    Id = dataReader.GetInt16(0),
                    Date = dataReader.GetString(1),
                    Discount = dataReader.GetInt16(2),
                    State = dataReader.GetString(3),
                    ClientName = dataReader.GetString(4),
                    EmployeeName = dataReader.GetString(5),
                    ServiceName = dataReader.GetString(6),
                });
            }

            dataReader.Close();
            sqlConnection.Close();

            OrdersDataGridItemsSource = null;
            OrdersDataGridItemsSource = orders;
        }
        private void AddOrder()
        {
            //CountPrice(sender, e);

            sqlConnection.Open();
            var queryString =
                $"INSERT INTO orders(date, discount, state, service_code, employee_code, service_code) " +
                $"VALUES('{Date}', {Discount}, 'В процессе', {ClientComboBoxSelectedValue}, {string.Empty}, {ServiceComboBoxSelectedValue})";
            MySqlCommand cmd = new MySqlCommand(queryString, sqlConnection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            sqlConnection.Close();

            FillDataGrid();
        }

        private void Logout()
        {
            windowsManagement = new();
            authorizationWindow = new();
            windowsManagement.SwitchWindow(authorizationWindow);

        }
    }
}
