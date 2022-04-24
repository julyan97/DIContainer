using DIContainer.Common.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIContainer.Common.Models
{
    public class Test : ITest
    {
        public int count = 0;
        public Test()
        {
            Console.WriteLine("hi there");
        }

        public void AfterCreation()
        {
            Console.WriteLine($"Used: {count++}");
        }
    }
}
