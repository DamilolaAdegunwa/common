using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using System;
using System.Reflection;
using Castle.Core.Interceptor;

namespace ConvertApp.ConsoleApp.Services.Others
{
    internal class CastleDynamicProxy
    {
    }
    class Program_ProxyGenerator
    {
        private static readonly ProxyGenerator Generator = new ProxyGenerator();

        static void Main_ProxyGenerator(string[] args)
        {
            var obj = new MyEntity()
            {
                Name = "My name",
                Description = "My description"
            };

            //var proxy = Generator.CreateClassProxyWithTarget(obj, new ObservableInterceptor());
            var proxy = Generator.CreateInterfaceProxyWithTarget(obj, new ObservableInterceptor());
            //var proxy = Generator.CreateClassProxy(obj, new ObservableInterceptor());

            Console.WriteLine("Object changed: " + proxy.IsChanged);

            proxy.Name = "My name 2";
            proxy.Description = "My description 2";

            Console.WriteLine("Object changed: " + proxy.IsChanged);

            Console.ReadLine();
        }
    }

    internal interface IObservable
    {
        bool IsChanged { get; }
        void SetChanged();
    }

    public abstract class BaseEntity : IObservable
    {
        public virtual bool IsChanged { get; protected set; }

        public void SetChanged()
        {
            IsChanged = true;
        }
    }

    public class MyEntity : BaseEntity
    {
        // Virtual keyword is very important
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }

    internal class ObservableInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var observable = invocation.InvocationTarget as IObservable;
            if (observable != null && !observable.IsChanged && IsSetter(invocation.Method))
            {
                observable.SetChanged();
            }
            invocation.Proceed();
        }

        private bool IsSetter(MethodInfo method)
        {
            return method.IsSpecialName && method.Name.StartsWith("set_", StringComparison.OrdinalIgnoreCase);
        }
    }
}
