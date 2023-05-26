using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertApp.ConsoleApp.Services.Variance
{
    public interface IContraVarianceClass<in T>
    {
       //public Task MethodSunday(out T t);//wrong
       //public Task MethodSunday(in T t);//wrong
       //public T MethodSunday(T t);//wrong
       //public Task MethodSunday(ref T t);//wrong
       public string MethodSunday(out string str, ref int i, in bool save, T t = default);
    }
    public interface ICoVarianceClass<out T>
    {
        //public Task MethodSunday(out T t);//wrong
        //public Task MethodSunday(in T t);//wrong
        //public T MethodSunday(T t);//wrong
        //public Task MethodSunday(ref T t);//wrong
        public void MethodSunday(out string str, ref int i, in bool save);
    }
    internal class VarianceClass
    {
    }
}
