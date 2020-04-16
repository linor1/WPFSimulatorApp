using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FlightSimulatorApp.Model.Interfaces;


namespace FlightSimulatorApp.Model
{
    public class AppSettingsModel: ISettingsModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
       
        private static ISettingsModel m_Instance = null;
        public static ISettingsModel Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new AppSettingsModel();
                   // m_Instance.FlightServerIP= Properties.Settings.Default.FlightServerIP;
                }
                return m_Instance;
            }
        }


        public int FlightInfoPort
        {
            get { return Properties.Settings.Default.FlightInfoPort; }
            set { Properties.Settings.Default.FlightInfoPort = value; }
        }
        public string FlightServerIP
        {
            get
            {
                return Properties.Settings.Default.FlightServerIP;
            }
            set
            {
                Properties.Settings.Default.FlightServerIP = value;
            }
        }

       

        public void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }
        
        public void ReloadSettings()
        {
            Properties.Settings.Default.Reload();
        }

    }
}























//public string flightServerIP
//{
//    get
//    {
//        return this.flightServerIP;
//    }
//    set
//    {
//        this.flightServerIP = value;
//    }
//}
//  public int FlightInfoPort
//{
//      get { return this.FlightInfoPort; }
//      set { FlightInfoPort = value; }
//  }


//private string flightServerIP = "127.0.0.1";
//private int FlightInfoPort = 5402;
//public string FlightServerIP
//{
//   get { return  flightServerIP; }
//   set { flightServerIP = value; }
//}