using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Models
{
    public class Human
    {
        public string Gender { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public int Age { get; set; }

        public void HappyBirthday ()
        {
            Console.WriteLine("Happy Birthday!");
            this.Age ++;
        }
    }
}
