using DIContainer.Common.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIContainer.Common.Models
{
    public class Test2 : ITest2
    {
        public int count = 0;
        public Test2()
        {
            Console.WriteLine("hi there2");
        }

        public void AfterCreation()
        {
            Console.WriteLine($"Used2: {count++}");
        }
    }
}
