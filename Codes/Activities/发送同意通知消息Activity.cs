using Spheniscidae.Framework;
using Spheniscidae.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spheniscidae.Activities
{
    [Serializable]
    public class 发送同意通知消息Activity : IActivity
    {
        public void Execute(Bookmark bookmark)
        {
            MessageBus.Send("已同意请假");

            WorkflowContext.Execute("[Done]", null);
        }
    }
}
