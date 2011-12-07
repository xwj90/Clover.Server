using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Clover.ClientLibrary
{
    public  static class Serializer
    {
        public static byte[] SerializeHashtable(string hashtableName, string key, object value)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (StreamReader sr = new StreamReader(ms))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(ms, value);
                   // ProtoBuf.Serializer.Serialize<object>(ms, value);
                    return null;
                }
            }
        }
    }
}
