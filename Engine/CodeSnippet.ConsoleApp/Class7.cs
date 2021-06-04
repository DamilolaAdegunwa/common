using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippet.ConsoleApp
{
    public class Class7
    {
        public static void Main()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };
            var thirdItem = array[2];    // array[2]
            var lastItem = array[^1];    // array[new Index(1, fromEnd: true)]
            var lastItem2 = array[..^1];    // array[new Index(1, fromEnd: true)]
            var vss = array[0^4];
            //System.Range;
            int[] vs = new int[] { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            var v = vs[..^0];
            var v2 = vs[0..6].Concat(vs[4..6]).Concat(vs[4..6]).Concat(vs[4..6]).Concat(vs[4..6]).Concat(vs[4..6]).Concat(vs[4..6]);
            var v3 = vs[0..5];
            var v4 = vs[..5];
        }
    }
}
