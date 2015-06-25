using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Spheniscidae.Framework
{
    public class WorkflowContext
    {
        public static List<Bookmark> bookmarks = new List<Bookmark>();

        public static void Add(Bookmark bmk)
        {
            bookmarks.Add(bmk);
        }

        public static void Add(List<Bookmark> bmks)
        {
            if (bmks != null)
                bmks.ForEach(b=>Add(b));
        }

        public static void Remove(Bookmark bmk)
        {
            bookmarks.Remove(bmk);
        }

        public static void Execute(string name, object payload)
        {
            var location = bookmarks.Find(w=>w.BookmarkName==name);

            location.Payload = payload;

            location.Resumed(location);
        }

        public static void PersistenceXml()
        {
            Storage.Persistence(bookmarks);
        }
    }
}
