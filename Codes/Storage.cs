using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Spheniscidae
{
    public class Storage
    {
        private const string filePath = "e:\\wf.txt";
        public static void Persistence(List<Bookmark> bookmarks)
        {
            var bytes = Serialize2Bytes(bookmarks);

            File.WriteAllText(filePath, BitConverter.ToString(bytes));
        }

        public static bool IsPersisted()
        {
            if (File.Exists(filePath))
                return true;

            return false;
        }

        public static List<Bookmark> Load()
        {
            List<byte> bytes = new List<byte>();

            var strs = File.ReadAllText(filePath).Split("-".ToCharArray());
            if (strs == null)
                return new List<Bookmark>();

            foreach(var s in strs)
            {
                byte b = Byte.Parse(s, System.Globalization.NumberStyles.HexNumber);
                bytes.Add(b);
            }

            List<Bookmark> bmks = (List<Bookmark>)DeserializeFromBytes(bytes.ToArray());

            return bmks;
        }

        private static byte[] Serialize2Bytes(object obj)
        {
            var memory = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(memory, obj);
            memory.Position = 0;
            var read = new byte[memory.Length];
            memory.Read(read, 0, read.Length);
            memory.Close();
            return read;
        }

        private static object DeserializeFromBytes(byte[] pBytes)
        {
            if (pBytes == null)
                return null;

            var memory = new MemoryStream(pBytes) { Position = 0 };
            var formatter = new BinaryFormatter();
            object newOjb = formatter.Deserialize(memory);
            memory.Close();
            return newOjb;
        }
    }
}
