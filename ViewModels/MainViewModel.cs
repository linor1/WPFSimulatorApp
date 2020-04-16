using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulatorApp.Model;
using System.Windows.Input;
using FlightSimulatorApp.Model.TCP;
using System.Windows;
using FlightSimulatorApp.Views.Windows;

namespace FlightSimulatorApp.ViewModels
{
    class MainViewModel
    {
        MainModel model;
        private ICommand _connectCommand;
            public MainViewModel(MainModel Model)
        {
            this.model = Model;
        }
        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand =
                new CommandHandler(() => OnClick()));
            }
        }
        private void OnClick()
        {
         //   this.model.Connect();
            this.model.connect(Properties.Settings.Default.FlightServerIP , Properties.Settings.Default.FlightInfoPort);
             
            //IsDisconnected = false; // Setting that the server is connected
        }

        private ICommand _settingsCommand;
        public ICommand SettingsCommand
        {
            get
            {
                return _settingsCommand ?? (_settingsCommand =
                new CommandHandler(() => OnClickSettings()));
            }
        }
        private void OnClickSettings()
        {
            Window settingsWin = new SettingsWindow();
            settingsWin.Show();
        }
    }
}
