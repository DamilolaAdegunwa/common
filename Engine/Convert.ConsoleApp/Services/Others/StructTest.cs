using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConvertApp.ConsoleApp.Services.Junk
{
    public class StructTest
    {
        //public static SomeStaticType Name { get; set; }
        //sealed means "most derived! (can derive from some other class)" or "can not be a base class". 
        public static async Task MainStructTest()
        {
            try
            {
                Point point = new Point(10, 20);
                Dummy dummy = new()
                {
                    Name = "test",
                    School = "my school",
                    Work = "my work"
                };
                checked
                {
                    //clone
                    Dummy dummy1 = dummy with { };
                    dummy.Work = "I only changed the first 1";
                }
                //clone
                Dummy dummy2 = new Dummy().CloneThis(dummy);
                _ = dummy2;
                //dummy2.Work = "MS";

                var w = "Ghost of my past";
                Console.WriteLine(w);
                //throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _ = ex;
            }
        }

        public void SomeSpan()
        {
            byte[] data = new byte[10];
            data[0] = 0x12;
            data[1] = 0x34;
            data[2] = 0x56;

            Span<byte> dataSpan = data.AsSpan(); // create a Span<byte> from the byte array

            byte[] slice = dataSpan.Slice(1, 2).ToArray(); // take a slice of the data, starting at index 1 and with length 2

            Console.WriteLine(BitConverter.ToString(slice)); // output: "34-56"

        }
    }

    public class MyClass
    {
        public string Name { get; set; }
        public static string s_Name { get; set; }
        public MyClass()
        {
            try
            {
                checked
                {
                    var x = "";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public MyClass(string name)
        {
            Name = name;
            s_Name = name;
        }

        public void MyMethod(string name)
        {
            Name = name;
            s_Name = name;
        }

        public static void MyMethodStatic(string name)
        {
            new MyClass().MyMethod(string.Empty);
            new MyClass().Name = name;
            s_Name = name;
        }
    }
    //can you use abstract class in place of Interface 4 DI??
    public interface ITest
    {
        string DisplayName(string name);
    }

    public abstract class Test : ITest
    {
        public abstract string DisplayName(string name);
    }

    public class Point
    {
        public
        int
        X
        {
            get
            ;
        }
        public
        int
        Y
        {
            get
            ;
        }
        public
        Point
        (
        int
        x,
        int
        y
        )
        => (X, Y) = (x * x, y + 10);
    }
    public class SomeBaseType
    {
        public static string Name { get; set; }
        public virtual void M1()
        {

        }
    }

    public class SomeType : SomeBaseType
    {
        public static string Name { get; set; }

        public sealed override void M1()
        {

        }
    }

    public interface IFoo1 { }
    public interface IFoo2 { }

    public struct Sample1
    {
        public static SomeType Name { get; set; }
        public int x;
        public int y;
        public Sample1() { }
        public Sample1(int x, int y) { }

    }
    public partial struct Sample2 : IFoo1
    {
        public int a;
        public int b;
        public Sample2() { }
        public void SampleMethod() { }
        public Sample2(int a, int b) { }

    }
}
/*
 	//a class cant derive from a struct i.e: class : struct (x)
	//a struct cant derive from a class i.e: struct: class (x)
	//a struct cant derive from a struct i.e: struct: struct (x)
	//a struct can however imple an interface
	//sealed keyword is not valid on a struct
	//abstract keyword is not valid on a struct
	//static keyword is not valid on a struct
	//you can not derive from a sealed class (it can however have a base class - it can derive from other classes)
	//you can not derive from a static class (a static class cannot be used as a base class)
	//a static class can not derive from any class
	//
 */