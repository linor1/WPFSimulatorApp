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
using System.ComponentModel;

namespace FlightSimulatorApp.ViewModels
{
    class MainViewModel:INotifyPropertyChanged
    {
        MainModel model;
        private ICommand _connectCommand;
        public MainViewModel(MainModel Model)
        {
            this.model = Model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                OnPropertyChanged(e.PropertyName);
            };

         }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

        ///// <summary>
        /////  joystick

        ///// </summary>
        //public double Rudder
        //{
        //    get { return Math.Round(model.Rudder, 2); }
        //    set
        //    {
        //        double normalized = value / 124;
        //        model.Rudder = normalized;
        //        OnPropertyChanged("Rudder");
        //    }
        //}
        //public double Elevator
        //{
        //    get { return Math.Round(model.Elevator, 2); }
        //    set
        //    {
        //        double normalized = value / 124;
        //        model.Elevator = normalized;
        //        OnPropertyChanged("Elevator");
        //    }
        //}
        //public double Throttle
        //{
        //    get { return Math.Round(model.Throttle, 2); }
        //    set
        //    {
        //        model.Throttle = value;
        //        OnPropertyChanged("Throttle");
        //    }
        //}
        //public double Aileron
        //{
        //    get { return Math.Round(model.Aileron, 2); }
        //    set
        //    {
        //        model.Aileron = value;
        //        OnPropertyChanged("Aileron");
        //    }
        //}



        // dashboard:

        public double Degree
        {
            get
            {
                Console.WriteLine("Degree:" + Math.Round(model.Degree, 4));
                return Math.Round(model.Degree, 4);
            }
            set
            {
                model.Degree = value;
                OnPropertyChanged("Degree");
            }
        }
        public double VerticalSpeed
        {
            get { return Math.Round(model.VerticalSpeed, 4); }
            set
            {
                model.VerticalSpeed = value;
                OnPropertyChanged("VerticalSpeed");
            }
        }
        public double GroundSpeed
        {
            get { return Math.Round(model.GroundSpeed, 2); }
        }
        public double GpsAltitude
        {
            get { return Math.Round(model.GpsAltitude, 2); }
        }
        public double RollDegree
        {
            get { return Math.Round(model.RollDegree, 2); }
        }
        public double PitchDegree
        {
            get { return Math.Round(model.PitchDegree, 2); }
        }
        public double AltimeterAltitude
        {
            get { return Math.Round(model.AltimeterAltitude, 2); }
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
            this.model.connect(Properties.Settings.Default.FlightServerIP, Properties.Settings.Default.FlightInfoPort);

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
