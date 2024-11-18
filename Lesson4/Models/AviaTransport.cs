using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4.Models
{
    internal class AviaTransport : Transport
    {
        public override string TransportType { get; set; }
        public override string TransportName { get; set; }
        public override string TransportStringOutput()
        {
            return $"Поздравляю, вы выбрали {TransportName}. Удачного полета!";
        }

        public AviaTransport(string transportType, string transportName)
        {
            TransportType = transportType;
            TransportName = transportName;
        }
    }
}
