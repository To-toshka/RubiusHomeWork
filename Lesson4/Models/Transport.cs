using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4.Models
{
    public abstract class Transport
    {
        public abstract string TransportType { get; set; }
        public abstract string TransportName { get; set; }
        public abstract void TransportStringOutput();
    }
}
