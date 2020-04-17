using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;


namespace FlightSimulatorApp.Model.TCP
{
    public class ClientHandler : IClientHandler
    {
        //todo
        private MapModel model;

            //constructor recive MapModel
        public ClientHandler(MapModel mapModel)
        {
            this.model = mapModel;
        }


        //receive TcpClient
        public void HandleClient(TcpClient client)
        {
           Task t= new Task(() =>
            {
                NetworkStream netWorkStream = client.GetStream();
                StreamReader reader = new StreamReader(netWorkStream);
                StreamWriter writer = new StreamWriter(netWorkStream);
                {
                    while (client.Connected)
                    {
                        byte[] msg = new byte[500];
                        try
                        {
                            netWorkStream.Read(msg, 0, msg.Length);
                            string raw = Encoding.ASCII.GetString(msg);

                            // Parse data
                            string[] values = raw.Split(',');
                            double lon = Convert.ToDouble(values[0]);
                            double lat = Convert.ToDouble(values[1]);
                            //todo
                            //this.model.Lat = lat;
                            //this.model.Lon = lon;
                        }
                        catch
                        {
                            break;
                        }
                    }
                }
                client.Close();
            });
            t.Start();
        }
    }
}
