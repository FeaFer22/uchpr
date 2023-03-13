using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                if(Application.Current.Windows.Count == 0)
                {
                    Application.Current.Shutdown();
                }
                else
                {
                    Application.Current.MainWindow.Hide();
                    for (int i = 0; i <= Application.Current.Windows.Count; i++)
                    {
                        Application.Current.Windows[i].Close();
                        Application.Current.MainWindow = windowToSwitch;
                        Application.Current.MainWindow.Show();
                    }
                }
            }
            catch (ArgumentException) { }
        }
    }
}
