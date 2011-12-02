using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Concurrent;

namespace Clover.Server
{
    public class Server
    {
        private static ConcurrentDictionary<EndPoint, Socket> sockets = new ConcurrentDictionary<EndPoint, Socket>();

        public void Start(ServerConfiguration config)
        {
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(config.Server, config.Port);
            listenSocket.Bind(ep);
            listenSocket.Listen(config.BackLog);
            listenSocket.BeginAccept(NewComingConnection, listenSocket);
        }
        public void Start()
        {
            Start(null);
        }

        private static void NewComingConnection(IAsyncResult result)
        {
            Socket s = result.AsyncState as Socket;
            sockets.AddOrUpdate(s.RemoteEndPoint, s, (p, q) => { return s; });

            byte[] data = new byte[4];
            s.BeginReceive(data, 0, 4, SocketFlags.None, NewComingCommand, data);
        }


        private static void NewComingCommand(IAsyncResult result)
        {
            Socket s = result.AsyncState as Socket;
        }
        
    }


    public enum ServerType
    {
        Master = 0,
        Slave = 1,
    }

}
