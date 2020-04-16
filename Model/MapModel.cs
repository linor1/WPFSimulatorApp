using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulatorApp.Model.TCP;
using System.ComponentModel;

namespace FlightSimulatorApp.Model
{
    public class MapModel : INotifyPropertyChanged
    {
        private double lon;
        private double lat;
         public MapModel()
        {

            IClientHandler ch = new ClientHandler(this);
            InfoServer.RegisterClientHandler(ch);

            Console.WriteLine("flightboard connected as client");
        }
        //todo
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public double Lon
        {
            get { return this.lon; }
            set
            {
                this.lon = value;
                NotifyPropertyChanged("Lon");
            }
        }
        public double Lat
        {
            get { return this.lat; }
            set
            {
                this.lat = value;
                NotifyPropertyChanged("Lat");
            }
        }
    }

}
