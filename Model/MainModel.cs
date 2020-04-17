using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using FlightSimulatorApp.Model.TCP;
using System.Threading;
using System.ComponentModel;
using System.IO;

namespace FlightSimulatorApp.Model
{
    class MainModel:INotifyPropertyChanged
    {
       
        public static  bool isConnect;
        public static TcpClient tcpClient;
        public static NetworkStream networkStream;
        public static Mutex mut = new Mutex();
        private double _throttle;
        private double _rudder;
        private double _aileron;
        private double _elevator;
        private Dictionary<string, string> mapper = new Dictionary<string, string>
            {
                {"rudder", "/controls/flight/rudder" },
                {"throttle", "/controls/engines/current-engine/throttle" },
                {"aileron" ,"/controls/flight/aileron" },
                {"elevator", "/controls/flight/elevator" }
            };
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private double SendMessage(string message)
        {
            double d = 0.0;
            byte[] data = Encoding.ASCII.GetBytes(message);
            try
            {
                MainModel.mut.WaitOne();
                MainModel.networkStream.Write(data, 0, data.Length);
                byte[] buff = new byte[256];
                MainModel.networkStream.Read(buff, 0, buff.Length);
                string value = Encoding.ASCII.GetString(buff);
                MainModel.mut.ReleaseMutex();
                d = double.Parse(value);
            }
            catch (Exception ex)
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
        private double degree;
        public double Degree
        {
            get { return this.degree; }
            set
            {
                if (this.degree != value)
                {
                    this.degree = value;
                    this.NotifyPropertyChanged("Degree");
                    
                }
            }
        }

        private double verticalSpeed;
        public double VerticalSpeed
        {
            get { return this.verticalSpeed; }
            set
            {
                if (this.verticalSpeed != value)
                {
                    this.verticalSpeed = value;
                    this.NotifyPropertyChanged("VerticalSpeed");
                }

            }
        }

        private double groundSpeed;
        public double GroundSpeed
        {
            get { return this.groundSpeed; }
            set
            {
                if (this.groundSpeed != value)
                {
                    this.groundSpeed = value;
                    this.NotifyPropertyChanged("GroundSpeed");
                }

            }
        }

        private double airSpeed;
        public double AirSpeed
        {
            get { return this.airSpeed; }
            set
            {
                if (this.airSpeed != value)
                {
                    this.airSpeed = value;
                    this.NotifyPropertyChanged("AirSpeed");
                }

            }
        }

        private double gpsAltitude;
        public double GpsAltitude
        {
            get { return this.gpsAltitude; }
            set
            {
                if (this.gpsAltitude != value)
                {
                    this.gpsAltitude = value;
                    this.NotifyPropertyChanged("GpsAltitude");
                }

            }
        }

        private double rollDegree;
        public double RollDegree
        {
            get { return this.rollDegree; }
            set
            {
                if (this.rollDegree != value)
                {
                    this.rollDegree = value;
                    this.NotifyPropertyChanged("RollDegree");
                }

            }
        }

        private double pitchDegree;
        public double PitchDegree
        {
            get { return this.pitchDegree; }
            set
            {
                if (this.pitchDegree != value)
                {
                    this.pitchDegree = value;
                    this.NotifyPropertyChanged("PitchDegree");
                }

            }
        }

        private double altimeterAltitude;
        public double AltimeterAltitude
        {
            get { return this.altimeterAltitude; }
            set
            {
                if (this.altimeterAltitude != value)
                {
                    this.altimeterAltitude = value;
                    this.NotifyPropertyChanged("AltimeterAltitude");
                }

            }
        }
        //Coordinates with getters and setters
        private double longitude;
        public double Longitude
        {
            get { return this.longitude; }
            set
            {
                if (this.longitude != value)
                {
                    this.longitude = value;
                    this.NotifyPropertyChanged("Longitude");
                    this.NotifyPropertyChanged("Location");
                }

            }
        }
        private double latitude;
        public double Latitude
        {
            get { return this.latitude; }
            set
            {
                if (this.latitude != value)
                {
                    this.latitude = value;
                    this.NotifyPropertyChanged("Latitude");
                    this.NotifyPropertyChanged("Location");
                }

            }
        }

        private string location;
        public string Location
        {
            get { return this.location; }
            set
            {
                if (this.location != value)
                {
                    this.location = value;
                    this.NotifyPropertyChanged("Location");
                }
            }
            
        }

        public void OnPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }


    
    
        public MainModel()
        {
            Location = "32.002644,34.8887";
            

        }
        public void connect(string ip, int port)
        {
            try
            {
                tcpClient = new TcpClient(ip, port);
                networkStream = tcpClient.GetStream();
                isConnect = true;
                this.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public double getParameterValue(string command) {

            double val = 0;
            byte[] commandByte = Encoding.ASCII.GetBytes(command);
            Console.WriteLine("entered new thread");
            try
            {
                networkStream.Write(commandByte, 0, commandByte.Length);
            }
            catch (IOException ex)
            {

            }
            try
            {
                byte[] buff = new byte[256];
                networkStream.Read(buff, 0, buff.Length);
                string output = Encoding.ASCII.GetString(buff);
                //if (output.Contains("ERR")) {
                //    return 0.5;
                //}
                val = Math.Round(double.Parse(Encoding.ASCII.GetString(buff)), 4);
             //  Console.WriteLine(output);
            }
            catch (IOException EX)
            {

            }
            return val;
        }
        public void Start()
        {
            //getting the dashboard information
            new Thread(delegate ()
            {
                if (Thread.CurrentThread.Name == null)
                {
                    Thread.CurrentThread.Name = "RequestPropsThread";
                }
               
                // System.Net.IPAddress ipaddress = System.Net.IPAddress.Parse("127.0.0.1");
                //  IPEndPoint ep = new IPEndPoint(ipaddress, 5402);
            //    string send = "set/controls/flight/rudder -20";

                while (isConnect)
                {
                    Console.WriteLine("entered new thread");
                    mut.WaitOne();
                        this.Degree = getParameterValue("get /instrumentation/heading-indicator/indicated-heading-deg\n");
                        this.VerticalSpeed = getParameterValue("get /instrumentation/gps/indicated-vertical-speed\n");
                        this.GroundSpeed = getParameterValue("get /instrumentation/gps/indicated-ground-speed-kt\n");
                        this.AirSpeed = getParameterValue("get /instrumentation/airspeed-indicator/indicated-speed-kt\n");
                        this.GpsAltitude = getParameterValue("get /instrumentation/gps/indicated-altitude-ft\n");
                        this.RollDegree = getParameterValue("get /instrumentation/attitude-indicator/internal-roll-deg\n");
                        this.PitchDegree = getParameterValue("get /instrumentation/attitude-indicator/internal-pitch-deg\n");
                        this.AltimeterAltitude = getParameterValue("get /instrumentation/gps/indicated-altitude-ft\n");
                  //  for (int i = 0; i < 5; i++)
                  //  {
                        this.Longitude = getParameterValue("get /position/longitude-deg\n");
                     //    OnPropertyChanged("X");
                        this.Latitude = getParameterValue("get /position/latitude-deg\n");
                    //   OnPropertyChanged("Y");
                    //   Thread.Sleep(50);
                    // }
                    this.Location = this.Longitude.ToString() + "," + this.Latitude.ToString();
                    Console.WriteLine(Longitude.ToString());
                    Console.WriteLine(Latitude.ToString());
                    Console.WriteLine(Degree.ToString());
                   
                    mut.ReleaseMutex();
                     Thread.Sleep(1000);

                }
            }).Start();

        }

            public void disconnect()
        {
            tcpClient.Close();
            isConnect = false;
        }
        public string read()
        {
            byte[] readerBuffer = new byte[256];
            try
            {
                networkStream.Read(readerBuffer, 0, readerBuffer.Length);
            }
            catch (Exception ex)
            {
            }
            return Encoding.ASCII.GetString(readerBuffer);
        }
        public void write(string command)
        {
            byte[] commandAsBytes = Encoding.ASCII.GetBytes(command);
            try
            {
                networkStream.Write(commandAsBytes, 0, commandAsBytes.Length);
            }
            catch (Exception ex)
            {
            }
        }
        public void Connect()
        {

            // Set the server
            Task taskSever = new Task(() =>
            {
                InfoServer.SetServer();
                InfoServer.Start();
            });

            Task taskClient = new Task(() =>
            {
                CommandChannel.AssignSocket();
            });


            Task connectionFlow = new Task(() =>
            {
                taskSever.Start();
                taskSever.Wait();

                Console.WriteLine("Finished waiting as server");

                taskClient.Start();
                taskClient.Wait();
            });


            connectionFlow.Start();

        }
    }

}
