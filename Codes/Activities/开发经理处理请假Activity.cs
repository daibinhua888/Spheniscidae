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
    public class 开发经理处理请假Activity : IActivity
    {
        public void Execute(Bookmark bookmark)
        {
            bool agree = Factory.Get开发经理Manager().是否同意请假();

            if (agree)
                WorkflowContext.Execute("同意", null);
            else
                WorkflowContext.Execute("不同意", null);
        }
    }
}
