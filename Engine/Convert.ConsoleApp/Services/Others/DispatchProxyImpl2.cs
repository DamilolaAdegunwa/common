using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConvertApp.ConsoleApp.Services.Others
{
    //public class Program_DispatchProxyImpl2
    //{

    //}
    public class GenericDecorator : DispatchProxy
    {
        public object Wrapped { get; set; }
        public Action<MethodInfo, object[]> Start { get; set; }
        public Action<MethodInfo, object[], object> End { get; set; }
        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            Start?.Invoke(targetMethod, args);
            object result = targetMethod.Invoke(Wrapped, args);
            End?.Invoke(targetMethod, args, result);
            return result;
        }
    }
    public class Program_DispatchProxyImpl2
    {
        static void Main_DispatchProxyImpl2(string[] args)
        {
            IEcho toWrap = new EchoImpl();
            IEcho decorator = DispatchProxy.Create<IEcho, GenericDecorator>();
            ((GenericDecorator)decorator).Wrapped = toWrap;
            ((GenericDecorator)decorator).Start = (tm, a) => Console.WriteLine($"{tm.Name}({string.Join(',', a)}) is started");
            ((GenericDecorator)decorator).End = (tm, a, r) => Console.WriteLine($"{tm.Name}({string.Join(',', a)}) is ended with result {r}");
            string result = decorator.Echo("Hello");
        }

        class EchoImpl : IEcho
        {
            public string Echo(string message) => message;
        }

        interface IEcho
        {
            string Echo(string message);
        }
    }
}
