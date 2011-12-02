using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clover.Server;
using System.Net;

namespace ServerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerConfiguration config = new ServerConfiguration();
            config.ServerType = ServerType.Master;
            config.Server = (Dns.Resolve(IPAddress.Any.ToString())).AddressList[0];
            config.Port = 10086;
            config.BackLog = 1000;

            Server server = new Server();
            server.Start(config);
            Console.WriteLine("Server Start Successfully");
            Console.ReadLine();

        }
    }
}
