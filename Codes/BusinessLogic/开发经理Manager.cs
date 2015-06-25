using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spheniscidae.BusinessLogic
{
    public class 开发经理Manager
    {
        public bool 是否同意请假()
        {
            Console.WriteLine("***********开发经理**************");
            Console.WriteLine("同意吗？Y/N");

            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.Y)
                return true;

            return false;
        }
    }
}
