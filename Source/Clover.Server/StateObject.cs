using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Clover.Server
{
    public class StateObject
    {
        public StateObject()
        {
            CommandByte = new byte[16];
        }
        public CommandType CommandType;
        public byte[] CommandByte;

        public Socket WorkSocket { get; set; }
    }



}
