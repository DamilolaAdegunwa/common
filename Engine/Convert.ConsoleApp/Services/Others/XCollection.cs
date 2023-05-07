using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertApp.ConsoleApp.Services.Junk
{
    public class XCollection
    {
        public IEnumerable<int> Ints1()
        {
            return default;
        }
        public IEnumerator<int> Ints2()
        {
            return default;
        }
        public static EnumerableQuery<int>? Ints3()
        {
            var emptyQueryable = new EnumerableQuery<int>(new List<int>() { 1, 2, 3, 4 });
            return emptyQueryable;
        }

        //System.Linq.Enumerable?
        //System.Linq.AsyncEnumerable? 

        public static EnumerableExecutor Ints4()
        {
            return default;
        }

        public static EnumerableExecutor<int> Ints5()
        {
            return default;
        }

        public static IGrouping<int, string> Ints6()
        {
            return default;
        }
        public static ILookup<int, string> Ints7()
        {
            return default;
        }
        public static IOrderedEnumerable<int> Ints8()
        {
            return default;
        }
        public static IOrderedQueryable<int> Ints9()
        {
            return default;
        }

        public static IQueryable<int> Ints10()
        {
            return default;
        }

        public IQueryProvider Ints11()
        {
            return default;
        }

        public static Lookup<int, string> Ints12()
        {
            return default;
        }

        //-----------

        public static OrderedParallelQuery<int> Ints13()
        {
            return default;
        }

        public static ParallelExecutionMode Ints14()
        {
            return default;
        }

        public static ParallelMergeOptions Ints15()
        {
            return default;
        }

        public static ParallelQuery Ints16()
        {
            return default;
        }

        public static Dictionary<int, string> Ints17()
        {
            return default;
        }

        public static HashSet<int> Ints18()
        {
            return default;
        }

        public async IAsyncEnumerable<int> Ints20()
        {
            yield return 1;
        }
        private static readonly ThreadLocal<Random> appRandom = new ThreadLocal<Random>(() => new Random());
    }
}
