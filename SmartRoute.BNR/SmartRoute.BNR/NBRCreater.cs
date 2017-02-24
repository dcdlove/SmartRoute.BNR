using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.BNR
{
	public class NBRCreater
	{
		public NBRCreater(INode node = null)
		{
			if (node == null)
				node = NodeFactory.Default;
			Node = node;
			string id = "NBR_CREATER_" + Guid.NewGuid().ToString("N");
			mEventSubscriber = Node.Register<EventSubscriber>(id);
		}

		private EventSubscriber mEventSubscriber;

		public INode Node { get; private set; }

		public string Create(string expression)
		{
			Request request = new BNR.Request();
			request.Expression = expression;

			Response response = mEventSubscriber.Publish<Response>(NBRServer.NBR_SERVER_TAG, request, 5000);
			if (!string.IsNullOrEmpty(response.Error))
				throw new Exception(response.Error);
			return response.Value;
		}

	}
}
