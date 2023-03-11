using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using uchpr.Utilities;

namespace uchpr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SQLUtilities sqlUtilities;

        public MainWindow()
        {
            InitializeComponent();
            sqlUtilities = new SQLUtilities();
            DataGridFill();
        }

        public void DataGridFill()
        {
            string queryString = "select * from orders";

            MySqlCommand sqlCommand = sqlUtilities.PullData(queryString);
            DataTable dataTable = new();
            MySqlDataAdapter dataAdapter = new();
            dataAdapter.SelectCommand = sqlCommand;
            dataAdapter.Fill(dataTable);

            ordersDataGrid.ItemsSource = dataTable.DefaultView;
            dataAdapter.Update(dataTable);
        }
    }
}
