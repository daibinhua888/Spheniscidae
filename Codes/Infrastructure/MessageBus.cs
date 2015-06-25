using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spheniscidae.Infrastructure
{
    public class MessageBus
    {
        public static void Send(string msg)
        {
            Console.WriteLine();
            Console.WriteLine("[MessageBus]->{0}", msg);
        }
    }
}
