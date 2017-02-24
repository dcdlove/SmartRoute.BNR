using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.BNR.ServerConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			INode node = NodeFactory.Default;
			node.Loger.Type = LogType.ALL;
			node.AddLogHandler(new ConsoleLogHandler(LogType.ALL));
			node.Open();
			NBRServer server = new NBRServer();
			server.Start();
			Console.Read();
		}
	}
}
