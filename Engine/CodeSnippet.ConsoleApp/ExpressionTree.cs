using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;

namespace CodeSnippet.ConsoleApp
{
    public class ExpressionTree
    {
        public static void MainExpressionTree()
        {
            //Console.WriteLine(CreateBoundResource2()(2));
            int ans = Enumerable.Range(2, 3).Aggregate((product, factor) => { return product * factor; });
            Console.WriteLine(ans);
            Console.WriteLine("Done!!");
        }
        public static void f()
        {
            Expression<Func<int, int>> factorial = (n) =>
            n < 0 ? 1 : Enumerable.Range(1, n).Aggregate((product, factor) => product * factor);
        }
        public static void sample1()
        {
            Action<int, int> addx = (num,sec) => { };
            Expression<Func<int, int>> addFive = (num) => num + 5;
            if (addFive.NodeType == ExpressionType.Lambda)
            {
                var lambdaExp = (LambdaExpression)addFive;
                var len = lambdaExp.Parameters.Count();
                var parameter = lambdaExp.Parameters.First();
                Console.WriteLine(parameter.Name);
                Console.WriteLine(parameter.Type);
            }
        }
        private static Func<int, int> CreateBoundResource2()
        {
            using (var constant = new Resource()) // constant is captured by the expression tree
            {
                Expression<Func<int, int>> expression = (b) => constant.arg + b;
                var rVal = expression.Compile();
                return rVal;
            }
        }
        private static Func<int, int> CreateBoundFunc()
        {
            var constant = 5; // constant is captured by the expression tree
            Expression<Func<int, int>> expression = (b) => constant + b;
            var rVal = expression.Compile();
            return rVal;
        }
        public class Resource : IDisposable
        {
            private bool isDisposed = false;
            public int arg { get; set; } = 2;
            public int Argument
            {
                get
                {
                    if (!isDisposed)
                        return 5;
                    else throw new ObjectDisposedException("Resource");
                }
            }
            public void Dispose()
            {
                isDisposed = true;
            }
        }
    }
}
