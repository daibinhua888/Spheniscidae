using Spheniscidae.Framework;
using Spheniscidae.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spheniscidae.Activities
{
    [Serializable]
    public class DoneActivity:IActivity
    {
        public void Execute(Bookmark bookmark)
        {
            Console.WriteLine("Done");
        }
    }
}
