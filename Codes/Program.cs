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

            string[] steps = { "step1", "step2", "step3" };

            while(true)
            {
                Random r = new Random();
                string step = steps[r.Next(0, 2)];

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
                BookmarkName = "step1",
                Resumed = Step1
            };

            Bookmark mk2 = new Bookmark()
            {
                BookmarkName = "step2",
                Resumed = Step2
            };

            Bookmark mk3 = new Bookmark()
            {
                BookmarkName = "step3",
                Resumed = Step3
            };

            WorkflowContext.Add(mk1);
            WorkflowContext.Add(mk2);
            WorkflowContext.Add(mk3);
        }

        static void Step1(Bookmark bookmark)
        {
            Console.WriteLine("*************Step1***********");
            Console.WriteLine(string.Format("类型：{0}     值：{1}", bookmark.Payload.GetType().FullName, bookmark.Payload.ToString()));

            WorkflowContext.Execute("step2", "this is a test[step2]");
        }

        static void Step2(Bookmark bookmark)
        {
            Console.WriteLine("*************Step2***********");
            Console.WriteLine(string.Format("类型：{0}     值：{1}", bookmark.Payload.GetType().FullName, bookmark.Payload.ToString()));

            Console.WriteLine("单击，进入步骤3");
            Console.ReadKey();

            WorkflowContext.Execute("step3", "this is a test[step3]");
        }

        static void Step3(Bookmark bookmark)
        {
            Console.WriteLine("*************Step3***********");
            Console.WriteLine(string.Format("类型：{0}     值：{1}", bookmark.Payload.GetType().FullName, bookmark.Payload.ToString()));
        }
    }
}
