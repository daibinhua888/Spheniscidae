using Spheniscidae.Activities;
using Spheniscidae.Framework;
using Spheniscidae.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spheniscidae
{
    class Program
    {
        private static 申请请假Activity 申请请假 = new 申请请假Activity();
        private static 发送拒绝通知消息Activity 发送拒绝通知消息 = new 发送拒绝通知消息Activity();
        private static 发送同意通知消息Activity 发送同意通知消息 = new 发送同意通知消息Activity();
        private static 开发经理处理请假Activity 开发经理处理请假 = new 开发经理处理请假Activity();
        private static DoneActivity Done = new DoneActivity();

        static void Main(string[] args)
        {
            if (Storage.IsPersisted())
            {
                Console.WriteLine("从磁盘读取");
                WorkflowContext.Add(Storage.Load());
            }
            else
            {
                Console.WriteLine("全新生成");
                NewBookmarkInit();
            }

            string[] steps = { "程序员提出请假申请", "开发经理处理", "同意", "不同意", "[Done]" };

            while(true)
            {
                Random r = new Random();
                string step = steps[r.Next(0, 4)];

                Console.WriteLine("当前会从{0}开始执行-{1}", step, DateTime.Now.ToString());

                WorkflowContext.Execute(step, string.Format("this is a test[{0}]", step));

                WorkflowContext.PersistenceXml();

                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        private static void NewBookmarkInit()
        {
            Bookmark mk1 = new Bookmark()
            {
                BookmarkName = "程序员提出请假申请",
                Resumed = 申请请假.Execute
            };

            Bookmark mk2 = new Bookmark()
            {
                BookmarkName = "开发经理处理",
                Resumed = 开发经理处理请假.Execute
            };

            Bookmark mk3 = new Bookmark()
            {
                BookmarkName = "同意",
                Resumed = 发送同意通知消息.Execute
            };

            Bookmark mk4 = new Bookmark()
            {
                BookmarkName = "不同意",
                Resumed = 发送拒绝通知消息.Execute
            };

            Bookmark done = new Bookmark()
            {
                BookmarkName = "[Done]",
                Resumed = Done.Execute
            };

            WorkflowContext.Add(mk1);
            WorkflowContext.Add(mk2);
            WorkflowContext.Add(mk3);
            WorkflowContext.Add(mk4);
            WorkflowContext.Add(done);
        }
    }
}
