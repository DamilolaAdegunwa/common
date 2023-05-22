////sadly, this was not carried to .net core

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System;
//using System.Runtime;
//using System.Runtime.Remoting;
//using System.Runtime.Remoting.Proxies;
//using System.Runtime.Remoting.Messaging;
//namespace ConvertApp.ConsoleApp.Services.Others
//{
//    //internal class DynamicProxyImpl
//    //{
//    //}
//    public interface ICalculator
//    {
//        int Add(int a, int b);
//    }

//    public class Calculator : ICalculator
//    {
//        public int Add(int a, int b)
//        {
//            return a + b;
//        }
//    }

//    public class DynamicProxy<T> : RealProxy
//    {
//        private readonly T target;

//        public DynamicProxy(T target) : base(typeof(T))
//        {
//            this.target = target;
//        }

//        public override IMessage Invoke(IMessage msg)
//        {
//            if (msg is IMethodCallMessage methodCall)
//            {
//                Console.WriteLine($"Before invoking method: {methodCall.MethodName}");

//                // Perform additional logic here before calling the actual method
//                // For example, logging, security checks, caching, etc.

//                // Call the actual method on the target object
//                var result = methodCall.MethodBase.Invoke(target, methodCall.InArgs);

//                Console.WriteLine($"After invoking method: {methodCall.MethodName}");

//                // Perform additional logic here after the method execution
//                // For example, logging, result transformation, etc.

//                return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
//            }

//            return null;
//        }
//    }

//    public class Program
//    {
//        public static void Main()
//        {
//            // Create an instance of the actual object
//            ICalculator calculator = new Calculator();

//            // Create a dynamic proxy around the calculator object
//            ICalculator proxy = new DynamicProxy<ICalculator>(calculator).GetTransparentProxy() as ICalculator;

//            // Call the methods on the proxy
//            int result = proxy.Add(3, 5);
//            Console.WriteLine($"Result: {result}");
//        }
//    }

//}
