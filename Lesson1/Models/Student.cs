using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Models
{
    public class Student : Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Language { get; set; }
    }
}
