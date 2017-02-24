using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.BNR.ClientConsole
{
	class Program
	{
		private static NBRCreater mCreater;
		public static void Main(string[] args)
		{
			INode node = NodeFactory.Default;
			node.Loger.Type = LogType.ALL;
			node.AddLogHandler(new ConsoleLogHandler(LogType.ALL));
			node.Open();
			mCreater = new NBRCreater();
			System.Threading.Thread.Sleep(10000);
			System.Threading.ThreadPool.QueueUserWorkItem(OnTest);
			System.Threading.ThreadPool.QueueUserWorkItem(OnTest1);
			System.Threading.Thread.Sleep(-1);

		}

		private static void OnTest(Object state)
		{
			while (true)
			{
				Console.WriteLine(mCreater.Create("{N:{D:yyyyMMdd}/000000}"));
				System.Threading.Thread.Sleep(200);
			}
		}

		private static void OnTest1(Object state)
		{
			while (true)
			{
				Console.WriteLine(mCreater.Create("{S:OD}{CN:深圳}{D:yyyyMM}{N:{CN:深圳}{D:yyyyMM}/00000000}"));
				System.Threading.Thread.Sleep(200);
			}
		}
	}
}
