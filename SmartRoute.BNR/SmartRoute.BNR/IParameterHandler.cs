using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRoute.BNR
{
    public interface IParameterHandler
    {
        void Execute(StringBuilder sb, string value);

        BNRFactory Factory
        {
            get;
            set;
        }
    }
}
