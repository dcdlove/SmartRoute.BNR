using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRoute.BNR
{
    [ParameterType("S")]
    public class ConstantParameterHandler : IParameterHandler
    {
        public void Execute(StringBuilder sb, string value)
        {
            sb.Append(value);
        }
        public BNRFactory Factory
        {
            get;
            set;
        }
    }
}
