using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.BNR
{
	public class NBRServer
	{
		internal const string NBR_SERVER_TAG = "SMARTROUTE_NBR_SERVER";

		public NBRServer(INode node = null)
		{
			if (node == null)
				node = SmartRoute.NodeFactory.Default;
			Node = node;

		}

		private EventSubscriber mEventSubscriber;

		public INode Node { get; private set; }

		public void Start()
		{
			mEventSubscriber = Node.Register<EventSubscriber>(NBR_SERVER_TAG);
			mEventSubscriber.Register<Request>(OnRequest);
		}

		private void OnRequest(Message msg, Request request)
		{
			Response response = new Response();
			try
			{
				response.Value = BNRFactory.Default.Create(request.Expression);
			}
			catch (Exception e_)
			{
				response.Error = e_.Message;
			}
			msg.Reply(response);
		}
	}
}
