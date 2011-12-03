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
        #region Default and Test  0x00 - 0x0f
        Unknown = 0x00,
        Test = 0x01,
        #endregion

        #region System  0x10 - 0x1f
        ReStart = 0x10,
        ShutDown = 0x11,
        #endregion

        #region System Data 0x20 - 0x2f
        ReInitialHashtable = 0x20,
        #endregion

        #region Hashtable Command 0x0100 - 0x010f
        SendHashData = 0x0100,
        RemoveHashData = 0x0101
        #endregion
    }
}
