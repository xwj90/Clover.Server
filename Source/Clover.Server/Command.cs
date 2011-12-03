using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clover.Server
{
  
    public struct Command
    {
        public static int ByteLength = 4;

        public static Command Create(byte[] data)
        {
            return new Command();
        }



        public CommandType CommandType { get; set; }
        public int Length { get; set; }
        public byte[] Data { get; set; }
    }
    public enum CommandType
    {
    }
  

 
}
