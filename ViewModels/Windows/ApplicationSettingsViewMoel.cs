using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FlightSimulatorApp.Model.Interfaces;
using FlightSimulatorApp.Views;
using FlightSimulatorApp.Model;

namespace FlightSimulatorApp.ViewModels.Windows
{
    class ApplicationSettingsViewMoel : BaseNotify
    {
        private ISettingsModel model;
        private Window settingsWindow;
        public ApplicationSettingsViewMoel(ISettingsModel model, Window SettingsWindow)
        {
            this.model = model;
            this.settingsWindow = SettingsWindow;
            VM_FlightServerIP = model.FlightServerIP;
            VM_FlightInfoPort = model.FlightInfoPort;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public string VM_FlightServerIP
        {
            get
            {
                return this.model.FlightServerIP;
            }
            set
            {
                model.FlightServerIP = value;
                NotifyPropertyChanged("FlightServerIP");
            }
        }

        public int VM_FlightInfoPort
        {
            get
            {
                return this.model.FlightInfoPort;
            }
            set
            {
                model.FlightInfoPort = value;
                NotifyPropertyChanged("FlightInfoPort");
            }
        }
        
        private ICommand _clickOKCommand;
        public ICommand ClickOKCommand
        {
            get
            {
                return _clickOKCommand ?? (_clickOKCommand = new CommandHandler(() => OnOKClick()));
            }
        }
        private void OnOKClick()
        {
            model.SaveSettings();
            this.settingsWindow.Close();
        }

        private ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new CommandHandler(() => CancelClick()));
            }
        }
        private void CancelClick()
        {
            model.ReloadSettings();
            this.settingsWindow.Close();
        }

    }
}
