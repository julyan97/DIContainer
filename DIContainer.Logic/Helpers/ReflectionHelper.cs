using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DIContainer.Logic.Helpers
{
    public static class ReflectionHelper
    {
        public static ConstructorInfo GetConstructorWithTheMostAguments(this Type type)
            => type.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length)
                .FirstOrDefault();

        public static object[] GetConstructorArgumetsOfType(this Type type)
            => type.GetConstructorWithTheMostAguments()
            .GetParameters()
            .Select(p =>
            {
                return Container._containers[p.ParameterType];
            })
            .ToArray();

        public static void GetConstructorsRecurion(this ConstructorInfo constructor)
        {
            List<Type> parameters = new();
            var doesConstructorContainParametersFromDIContainer = constructor
                .GetParameters()
                .Any(p =>
                {
                    if (Container._containers.ContainsKey(p.ParameterType))
                    {
                        parameters.Add(Container._containers[p.ParameterType].GetType());
                        return true;
                    }
                    return false;
                });

            if (!doesConstructorContainParametersFromDIContainer)
            {
                return;
            }

            foreach (var parameter in parameters)
            {
                var ctorOfCrrentParameter = parameter.GetConstructorWithTheMostAguments();
                GetConstructorsRecurion(ctorOfCrrentParameter);

                object[] arguments = ctorOfCrrentParameter
                    .GetParameters()
                    .Select(p => Container.Get(p.ParameterType))
                    .ToArray();
                var instance = ctorOfCrrentParameter.Invoke(arguments);
                Console.WriteLine(instance);

            }
            Console.WriteLine(constructor);
        }

    }
}
