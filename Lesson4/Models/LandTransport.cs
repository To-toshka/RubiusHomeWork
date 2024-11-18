using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4.Models
{
    internal class LandTransport : Transport
    {
        public override string TransportType { get; set; }
        public override string TransportName { get; set; }
        public override string TransportStringOutput()
        {
            return $"Поздравляю, вы выбрали {TransportName}. Удачной поездки!";
        }

        public LandTransport(string transportType, string transportName)
        {
            TransportType = transportType;
            TransportName = transportName;
        }
    }
}
