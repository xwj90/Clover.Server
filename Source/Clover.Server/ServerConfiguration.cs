using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Clover.Server
{
    public class ServerConfiguration
    {
        public ServerType ServerType { get; set; }
        public IPAddress Server { get; set; }
        public int Port { get; set; }
        public int BackLog { get; set; }
    }
}
