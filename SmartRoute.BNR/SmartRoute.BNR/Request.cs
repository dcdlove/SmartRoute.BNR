using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
namespace SmartRoute.BNR
{
	[ProtoContract]
	public class Request
	{
		[ProtoMember(1)]
		public string Expression { get; set; }
	}
}
