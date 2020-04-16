using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;

namespace FlightSimulatorApp.Model.TCP
{
   public interface IClientHandler
    {
        void HandleClient(TcpClient client);
    }
}
