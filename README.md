# SmartRoute.BNR
SmartRoute分布式业务号生成服务，服务通过规则的方式描述序业务号的生成；为了方便地描述业务号，提供的基础描述规则如下：
##{N:key/format}
    数值自增长描述，key是相应数值增长标训，可以描述一个字符也可以是其他基础表达式的组合;format是生成的格式
    {N:Order/00000}
    {N:{CN:深圳}/00000}
    {N:{CN:深圳}{D:yyyyMM}/00000000}
##{S:value}
    描述一个字符，value是指具体的字符
    {S:OD}
##{D:format}
    描述当前日期，format是指日期输出的格式
##{CN:value}
    描述中文对应的拼音，value是指相应的中文字
##业务号规则定义
    序号技术规则可以是以上任意描述的组合
    {N:{D:yyyyMMdd}/000000}
    {S:OD}{CN:深圳}{D:yyyyMM}{N:{CN:深圳}{D:yyyyMM}/00000000}
    实际上也可以根据需要扩展出新的基础规则描述
##业务号生成服务部署
``` c#
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
```
##业务号生成
``` c#
			INode node = NodeFactory.Default;
			node.Loger.Type = LogType.ALL;
			node.AddLogHandler(new ConsoleLogHandler(LogType.ALL));
			node.Open();
			mCreater = new NBRCreater();
      
      mCreater.Create("{N:{D:yyyyMMdd}/000000}")
```
