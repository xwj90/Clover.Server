using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Concurrent;
using System.Threading;

namespace Clover.Server
{
    public class Server
    {
        private static ConcurrentDictionary<EndPoint, Socket> sockets = new ConcurrentDictionary<EndPoint, Socket>();

        public void Start(ServerConfiguration config)
        {
            Socket listenSocket = new Socket(AddressFamily.Unspecified, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(config.Server, config.Port);
            listenSocket.Bind(ep);
            listenSocket.Listen(config.BackLog);


            while (true)
            {
                // Set the event to nonsignaled state.
                allDone.Reset();

                // Start an asynchronous socket to listen for connections and receive data from the client.
                Console.WriteLine("Waiting for a connection...");

                StateObject state = new StateObject() { WorkSocket = listenSocket };
                listenSocket.BeginAccept(Command.ByteLength, NewComingConnection, listenSocket);

                // Wait until a connection is made and processed before continuing.
                allDone.WaitOne();
            }
        }
        private static AutoResetEvent allDone = new AutoResetEvent(false);

        public void Start()
        {
            Start(null);
        }

        private static void NewComingConnection(IAsyncResult result)
        {
            try
            {

                Socket s = result.AsyncState as Socket;
                StateObject state = new StateObject();
                int bytesTransferred = 0;
                byte[] data = null;
                Socket handler = s.EndAccept(out data, out bytesTransferred, result);
                //first 4 bytes data will be in data.  i don't know why bytesTransferrd is 56

                state.CommandType = (CommandType)BitConverter.ToInt32(data, 0);
                state.WorkSocket = handler;
                Console.WriteLine("New Connection commandType:" + state.CommandType);

                HandleCommandType(state);

            }
            catch (SocketException ex)
            {

            }
            finally
            {
                allDone.Set();
            }
        }
        private static void HandleCommandType(StateObject state)
        {
            CommandHandler handler = new CommandHandler();
            handler.Call(state);
        }



        private static void NewComingCommand(IAsyncResult result)
        {

            StateObject state = result.AsyncState as StateObject;
            int v = state.WorkSocket.EndReceive(result);

            Console.WriteLine("Get Input data:" + string.Join(" ", state.CommandByte));
        }

    }


    public enum ServerType
    {
        Master = 0,
        Slave = 1,
    }

}
