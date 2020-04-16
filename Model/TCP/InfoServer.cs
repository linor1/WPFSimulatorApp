using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace FlightSimulatorApp.Model.TCP
{
    public static class InfoServer
    {
        private static Mutex mut = new Mutex();
        private static int port;
        private static IClientHandler ch;
        private static string ipAddr;

        static InfoServer()
        {

        }
        public static void SetServer()
        {
            //try to call getter of FlightInfoPort
            port = Properties.Settings.Default.FlightInfoPort;
            ipAddr = Properties.Settings.Default.FlightServerIP;
        }
        //todo
        //check if can to put this line in the constructor.
        //chech if it can be public
        public static void RegisterClientHandler(IClientHandler cHandler)
        {
            ch = cHandler;
        }

        public static void Start()
        {
            //getting the dashboard information
            new Thread(delegate ()
            {
                if (Thread.CurrentThread.Name == null)
                {
                    Thread.CurrentThread.Name = "RequestPropsThread";
                }
                bool stop = false;
                NetworkStream stream;
               // System.Net.IPAddress ipaddress = System.Net.IPAddress.Parse("127.0.0.1");
              //  IPEndPoint ep = new IPEndPoint(ipaddress, 5402);
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(Properties.Settings.Default.FlightServerIP, Properties.Settings.Default.FlightInfoPort);
                // tcpClient.Connect("127.0.0.1", 5402);
                stream = tcpClient.GetStream();
                while (true)
                {
                    Console.WriteLine("entered new thread");
                    mut.WaitOne();
                    //todo
                    string send = "hi";
                    byte[] commandByte = Encoding.ASCII.GetBytes(send);
                    Console.WriteLine("entered new thread");
                    try
                    {
                        stream.Write(commandByte, 0, commandByte.Length);
                    } 
                    catch (IOException ex) { 

                    }
                    try
                    {
                        byte[] buff = new byte[256];
                        stream.Read(buff, 0, buff.Length);
                        string input = Encoding.ASCII.GetString(buff);
                        //  double d = Math.Round(double.Parse(input), 4);
                      //  Console.WriteLine(input);
                    }
                    catch (IOException EX) { 
                    
                    }
                    mut.ReleaseMutex();
                }
                    
                    /* mut.WaitOne();
                     telnetClient.write("get /instrumentation/heading-indicator/indicated-heading-deg\n");
                     Degree = Math.Round(double.Parse(telnetClient.read()), 4);

                     telnetClient.write("get /instrumentation/gps/indicated-vertical-speed\n");
                     VerticalSpeed = Math.Round(double.Parse(telnetClient.read()), 4);

                     telnetClient.write("get /instrumentation/gps/indicated-ground-speed-kt\n");
                     GroundSpeed = Math.Round(double.Parse(telnetClient.read()), 4);

                     telnetClient.write("get /instrumentation/airspeed-indicator/indicated-speed-kt\n");
                     AirSpeed = Math.Round(double.Parse(telnetClient.read()), 4);

                     telnetClient.write("get /instrumentation/gps/indicated-altitude-ft\n");
                     GpsAltitude = Math.Round(double.Parse(telnetClient.read()), 4);

                     telnetClient.write("get /instrumentation/attitude-indicator/internal-roll-deg\n");
                     RollDegree = Math.Round(double.Parse(telnetClient.read()), 4);

                     telnetClient.write("get /instrumentation/attitude-indicator/internal-pitch-deg\n");
                     PitchDegree = Math.Round(double.Parse(telnetClient.read()), 4);

                     telnetClient.write("get /instrumentation/altimeter/indicated-altitude-ft\n");
                     AltimeterAltitude = Math.Round(double.Parse(telnetClient.read()), 4);

                     for (int i = 0; i < 5; i++)
                     {
                         telnetClient.write("get /position/longitude-deg\n");
                         Longitude = Math.Round(double.Parse(telnetClient.read()), 4);
                         // NotifyPropertyChanged("X");

                         telnetClient.write("get /position/latitude-deg\n");
                         Latitude = Math.Round(double.Parse(telnetClient.read()), 4);
                         NotifyPropertyChanged("Y");
                         Thread.Sleep(50);
                     }
                     mut.ReleaseMutex();
                     */

              //  }
            }).Start();
        
        }
    }
}