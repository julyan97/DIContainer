using DIContainer.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIContainer.Logic
{
    public static class Container
    {
        public static Dictionary<object, object> _containers = new();
         

        public static void AddSingleton<TInterface, TInstance>()
        {
            var arguments = typeof(TInstance).GetConstructorArgumetsOfType();
            _containers[typeof(TInterface)] = Activator.CreateInstance(typeof(TInstance),arguments);
        }
        public static void AddSingleton<TInstance>()
        {
            var arguments = typeof(TInstance).GetConstructorArgumetsOfType();
            _containers[typeof(TInstance)] = Activator.CreateInstance(typeof(TInstance), arguments);
        }



        public static void AddTrancient<TInterface, TInstance>()
        {
            var arguments = typeof(TInstance).GetConstructorArgumetsOfType();
            Func<TInterface> action = () => (TInterface)Activator.CreateInstance(typeof(TInstance), arguments);
            _containers[typeof(TInterface)] = action;
        }
        public static void AddTrancient<TInstance>()
        {
            var arguments = typeof(TInstance).GetConstructorArgumetsOfType();
            Func<TInstance> action = () => (TInstance)Activator.CreateInstance(typeof(TInstance), arguments);
            _containers[typeof(TInstance)] = action;
        }

        public static TInterface Get<TInterface>()
        {
            var instance = _containers[typeof(TInterface)];
            return instance.GetType().Name == typeof(Func<>).Name ? ((Func<TInterface>)instance).Invoke() : (TInterface)instance;
        }
        public static object Get(Type type)
        {
            var instance = _containers[type];
            return instance.GetType().Name == typeof(Func<>).Name ? ((Func<object>)instance).Invoke() : (object)instance;
        }
    }
}
