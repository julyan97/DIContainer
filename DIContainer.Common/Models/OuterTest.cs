using DIContainer.Common.Models.Interfaces;
using DIContainer.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIContainer.Common.Models
{
    public class OuterTest
    {
        private readonly ITest test;

        public OuterTest(ITest test)
        {
            this.test = test;
            test.AfterCreation();
        }
    }
}
