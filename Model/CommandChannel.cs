using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace FlightSimulatorApp.Model
{
    static class CommandChannel
    {
        public static TcpClient Client;
        public static void SendCommands(string command)
        {
            byte[] data = Encoding.ASCII.GetBytes(command + "\r\n");
            NetworkStream stream = Client?.GetStream();
            try
            {
                stream?.Write(data, 0, data.Length);
            }
            catch
            {
                Console.WriteLine("Problem with sending: " + command);
            }

        }
        public static void AssignSocket()
        {
         
        }

        public static void Close()
        {
            Client.Close();
        }


    }
}
