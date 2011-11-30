using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Clover.Server
{
    public class ServerConnection
    {
        public IPAddress Server { get; set; }
        public int Port { get; set; }
        public ServerConnectionType ConnectionType { get; set; }
    }

    public enum ServerConnectionType
    {
        KeepConnection = 0,
       // AutoRefresh = 1,
    }
     

}
