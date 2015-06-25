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
    public class 申请请假Activity:IActivity
    {
        public void Execute(Bookmark bookmark)
        {
            Factory.Get开发人员Manager().提出请假申请();

            WorkflowContext.Execute("开发经理处理", null);
        }
    }
}
