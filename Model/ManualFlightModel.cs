using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Model
{
    class ManualFlightModel
    {
        private double _throttle;
        private double _rudder;
        private double _aileron;
        private double _elevator;
      private Dictionary<string,string>  mapper = new Dictionary<string, string>
            {
                {"rudder", "/controls/flight/rudder" },
                {"throttle", "/controls/engines/current-engine/throttle" },
                {"aileron" ,"/controls/flight/aileron" },
                {"elevator", "/controls/flight/elevator" }
            };
    public ManualFlightModel()
        {

        }

        public double Throttle
        {
            get { return _throttle; }
            set
            {
                _throttle = value;
                if (MainModel.isConnect)
                {
                    string message = BuildMessage("throttle", value);
                    SendMessage(message);
                }
            }
        }

        private double SendMessage(string message)
        {
            double d = 0.0;
            byte[] data = Encoding.ASCII.GetBytes(message );
            try
            {
                MainModel.mut.WaitOne();
                MainModel.networkStream.Write(data, 0, data.Length);
                byte[] buff = new byte[256];
                MainModel.networkStream.Read(buff, 0, buff.Length);
                string value= Encoding.ASCII.GetString(buff);
                MainModel.mut.ReleaseMutex();
                d = double.Parse(value);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Problem with sending: " + message);
            }
            return d;
        }

        private string BuildMessage(string propertyName, double value)
        {
            string message = "";
         //   message = "set /controls/flight/rudder -0.5\n";

            message = "set " + this.mapper[propertyName] + " " + value + "\n";

            //Console.WriteLine(message);
            return message;
        }

        public double Rudder
        {
            get { return _rudder; }
            set
            {
                _rudder = value;
                if (MainModel.isConnect)
                {
                    string message = BuildMessage("rudder", value);

                    SendMessage(message);
                }

            }
        }

        public double Aileron
        {
            get { return _aileron; }
            set
            {
                _aileron = value;
                if (MainModel.isConnect)
                {
                    string message = BuildMessage("aileron", value);
                    SendMessage(message);
                }
            }
        }

        public double Elevator
        {
            get { return _elevator; }
            set
            {
                _elevator = value;
                if (MainModel.isConnect)
                {
                    string message = BuildMessage("elevator", value);
                    SendMessage(message);
                }

            }
        }
    }
}
