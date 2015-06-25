using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Spheniscidae.Framework
{
    [Serializable]
    public delegate void BookmarkLocation(Bookmark bookmark);

    [Serializable]
    public class Bookmark
    {
        public string BookmarkName{get;set;}

        public object Payload { get; set; }

        //[XmlIgnore]
        public BookmarkLocation Resumed { get; set; }
    }
}
