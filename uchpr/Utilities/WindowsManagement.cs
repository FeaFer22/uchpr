using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace uchpr.Utilities
{
    internal class WindowsManagement
    {
        public void SwitchWindow(Window windowToSwitch)
        {
            try
            {
                Application.Current.MainWindow.Close();
                Application.Current.MainWindow = windowToSwitch;
                windowToSwitch.Show();

            }
            catch (ArgumentException)
            {
                Console.WriteLine("XYI");
            }
        }
    }
}
