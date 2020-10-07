using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippet.ConsoleApp
{
    public class TestingIterators
    {
        IEnumerable<int> CountTo100Twice()
        {
            int i;
            for (i = 1; i <= 100; i++)
            {
                yield return i;
            }
            for (i = 1; i <= 100; i++)
            {
                yield return i;
            }
        }
        IEnumerable<int> CountTo100Twice2()
        {
            List<int> result = new List<int>();
            var r1 = CountTo100();
            var r2 = CountTo100();
            result.AddRange(r1);
            result.AddRange(r2);

            return result;
        }

        IEnumerable<int> CountTo100Twice3()
        {
            foreach (int i in CountTo100()) yield return i;
            foreach (int i in CountTo100()) yield return i;
        }

        public IEnumerable<int> CountTo100()
        {
            int i;
            for (i = 1; i <= 100; i++)
            {
                yield return i;
            }
        }
    }
}
