using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertApp.ConsoleApp.Services.Junk
{
    public class SOTest
    {
        public void SomeMethod(in int i, in int j, in int k, out int a, out int b, out int c)
        {
            a = i;
            b = j;
            c = k;
        }
    }
}
