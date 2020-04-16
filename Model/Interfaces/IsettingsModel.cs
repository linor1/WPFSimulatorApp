using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSimulatorApp.Model.Interfaces
{
    public interface ISettingsModel : INotifyPropertyChanged
    {
      //  public event PropertyChangedEventHandler PropertyChanged;
        string FlightServerIP { get; set; }          // The IP Of the Flight Server
          int FlightInfoPort { get; set; }           // The Port of the Flight Server

        //  int FlightCommandPort { get; set; }           // The Port of the Flight Server
        void SaveSettings();
        void ReloadSettings();
    }
}
