using FlightSimulatorApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.ViewModels
{
    class JoystickViewModel : BaseNotify
    {
        private ManualFlightModel model;

        public JoystickViewModel()
        {
            this.model = new ManualFlightModel();
        }
        public int MyProperty { get; set; }


        public double Rudder
        {
            get { return Math.Round(model.Rudder, 2); }
            set
            {
                double normalized = value / 124;
                model.Rudder = normalized;
                NotifyPropertyChanged("Rudder");
            }
        }
        public double Elevator
        {
            get { return Math.Round(model.Elevator, 2); }
            set
            {
                double normalized = value / 124;
                model.Elevator = normalized;
                NotifyPropertyChanged("Elevator");
            }
        } 
        public double Throttle
        {
            get { return Math.Round(model.Throttle, 2); }
            set
            {
                model.Throttle = value;
                NotifyPropertyChanged("Throttle");
            }
        }
        public double Aileron
        {
            get { return Math.Round(model.Aileron, 2); }
            set
            {
                model.Aileron = value;
                NotifyPropertyChanged("Aileron");
            }
        }


    }
}
