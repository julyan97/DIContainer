using DIContainer.Common.Models;
using DIContainer.Common.Models.Interfaces;
using DIContainer.Logic;
using DIContainer.Logic.Helpers;
using System;
using System.Linq;

namespace DIContainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Container.AddSingleton<ITest, Test>();
            Container.AddTrancient<ITest2, Test2>();
            Container.AddTrancient<OuterTest>();


            var instance = Container.Get<ITest>();
            instance.AfterCreation();
            var instance1 = Container.Get<ITest>();
            instance1.AfterCreation();
            var instance2 = Container.Get<ITest>();
            instance2.AfterCreation();

            Console.WriteLine();

            var instancet = Container.Get<ITest2>();
            instancet.AfterCreation();
            var instancet1 = Container.Get<ITest2>();
            instancet1.AfterCreation();
            var instancet2 = Container.Get<ITest2>();
            instancet2.AfterCreation();

            Console.WriteLine();

            var outer = Container.Get<OuterTest>();


            Console.WriteLine();
            Console.WriteLine("Here: ");



        }
    }
}
