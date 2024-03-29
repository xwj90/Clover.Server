﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clover.Server;
using System.Net;
using System.Threading;
using System.Net.Sockets;

namespace ServerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(ClientTestData);

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

        public static void ClientTestData(object state)
        {
            for (int i = 0; i < 1; i++)
            {
                Thread.Sleep(200);
                SocketHelper.Send("127.0.0.1", 10086, new byte[] { 0x1, 0x1, 0x1, 0x1, 0x2, 0x2, 0x2, 0x2, 3, 3, 3, 3, 4, 4, 4, 4 });

                Thread.Sleep(200);
                SocketHelper.Send("127.0.0.1", 10086, new byte[] { 0x1, 0x1, 0x1, 0x1, 0x2, 0x2, 0x2, 0x2, 3, 3, 3, 3, 4, 4, 4, 4 });

            }
        }

    }

    public class SocketHelper
    {
        public static Socket Send(string ipAddress, int port, byte[] data)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            //  IPEndPoint ep = new IPEndPoint((Dns.Resolve(IPAddress.Any.ToString())).AddressList[0], port);

            s.Connect(ep);
            s.Send(BitConverter.GetBytes(Convert.ToInt32(CommandType.SendHashData)));

            string hashtable = "HashtableName";
            string key = "HashtableName";
            object value = new object();
            s.Send(data);


            s.Disconnect(true);
            return s;
        }
    }
}
