using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace timer_mvvm_test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = new MainWindow();
            mainWindow.Closed += (sender, args) => { Shutdown(); };
            mainWindow.Visibility = Visibility.Hidden;

            mainWindow.taskbarIcon.Visibility = Visibility.Visible;
            mainWindow.taskbarIcon.DataContext = mainWindow;
        }
    }
}
