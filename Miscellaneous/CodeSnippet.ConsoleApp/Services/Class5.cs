using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace CodeSnippet.ConsoleApp.Services
{
    public class Class5
    {
        public void Reflective()
        {
            MethodBuilder method = default;
            MethodInfo methodInfo = default;

            var gen = method.GetILGenerator();
            gen.Emit(OpCodes.Ldarg_0);
            var bd = BindingFlags.Default;
        }
    }
}
