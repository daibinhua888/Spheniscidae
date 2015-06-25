using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spheniscidae.BusinessLogic
{
    public class Factory
    {
        public static 开发人员Manager Get开发人员Manager()
        {
            return new 开发人员Manager();
        }
        public static 开发经理Manager Get开发经理Manager()
        {
            return new 开发经理Manager();
        }

        
    }
}
