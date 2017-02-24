using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
namespace SmartRoute.BNR
{
	[ProtoContract]
	public class Response
	{
		[ProtoMember(1)]
		public string Value { get; set; }

		[ProtoMember(2)]
		public string Error { get; set; }
	}
}
