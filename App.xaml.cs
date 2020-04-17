using FlightSimulatorApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>




    public partial class App : Application
    {
       // private MapVM ViewModel { get;  set; }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //  this.ViewModel = new MapVM();
            MainWindow mw = new MainWindow();


        }
    }
}
