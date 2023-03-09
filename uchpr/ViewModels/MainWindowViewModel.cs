using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uchpr.Utilities.Commands;
using uchpr.Utilities;
using uchpr.ViewModels.Base;

namespace uchpr.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            MySqlConnection connection = DBUtilities.GetDBConnection();
            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                connection.Close();
            }
        }
    }
}
