using System.Reflection.Metadata;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
//using web = System.Web.UI.WebControls;
//using win = System.Windows.Forms;
using System.Linq;
using System.Web.Helpers;

namespace ConvertApp.ConsoleApp.Services.Junk
{
    class Parent
    {
        public Parent()
        {
            Initialize();
        }

        public void Initialize()
        {
            DoSomething();
        }

        protected virtual void DoSomething()
        {
        }
    }

    class Child : Parent
    {
        private string foo;
        private bool isConstructorCalled;
        public string bar;
        public Child() : base()
        {
            foo = "HELLO";
            isConstructorCalled = true;
            //base.DoSomething();
        }

        protected override void DoSomething()
        {
            if (!isConstructorCalled)
            {
                base.DoSomething();
                //foo = "HELLO (From DoSomething)";
            }
            else
            {
                Console.WriteLine(foo.ToLower()); //NullReferenceException!?!
            }

        }
    }
    public enum Alpha
    {
        A = 1,
        B = 2,
        C = 3,
        D = 4,
        E = 5,
        F = 6,
        G = 7,
        H = 8,
        I = 9,
        J = 10,
        K = 11,
        L = 12,
        M = 13,
        N = 14,
        O = 15,
        P = 16,
    }
    public sealed class Program : object
    {
        public static void MainJunk()
        {
            bool iscorr = Enum.TryParse("A", out Alpha alpha);
            var s = typeof(int).IsEnum;

            var a = (System.DateTime.MaxValue - System.DateTime.MinValue).TotalNanoseconds;
            var b = new List<Child>().ToLookup(a => a.bar).Select(a => a.First()).ToList();
            var c = new Child();

            int index = 0;
            foreach (var item in "Damilola") { Console.WriteLine($"s/n{++index}: {item}"); }
            System.Collections.IEnumerable collection = Enumerable.Range(100, 10);

            foreach (var o in collection.OfType<object>().Select((x, i) => new { x, i }))
            {
                Console.WriteLine("{0} {1}", o.i, o.x);
            }
            Console.WriteLine("done!");

            //dynamic data = new System.Web.Helpers;//.Json.Decode("");
        }
		public static void Main2()
		{
			int x = 42;
			TypedReference tr = __makeref(x);
			Type type = __reftype(tr);
			Console.WriteLine(type.FullName);

			int value = __refvalue(tr, int);
			Console.WriteLine(value.ToString());

			//chnage the value of x
			x = 33;
			Console.WriteLine(value.ToString());
			string format = "000;-#;(0)";

			string pos = 1.ToString(format);     // 001
			string neg = (-1).ToString(format);  // -1
			string zer = 0.ToString(format);     // (0)
		}
	}
	#region comment
	public class Program_Readonly
	{
		public static readonly string s = "";
		public static readonly string E = null;
		public static void Main_Readonly(string[] args)
		{
			int x = 42;
			TypedReference tr = __makeref(x);
			Type type = __reftype(tr);
			int value = __refvalue(tr, int);


			//__makeref x = default;
			//web::Control aWebControl = new web::Control();
			//win::Control aFormControl = new win::Control();
			//Environment.Exit();
			Environment.FailFast("dump!!");
			Hashtable hashtable = new Hashtable();
			switch (s)
			{
				case "":Console.WriteLine("nothing"); break;
			}
			var p = new Person()
			{
				Address = "25, Coker Road",
				Age = 30,
				Name = "Oluwadamilola Adegunwa",
			};

			var n = p.Name;
			AstraBodies bodies = AstraBodies.Moon;

			var str = System.Text.Encoding.Default.GetString(default);
			Console.WriteLine(p);

			//for the fun of it!
			PrintArgs(__arglist(1, "hello", 3.14));
		}
		[DefaultValue("qq")]
		public string a() { return s; }
		public static void PrintArgs(__arglist)
		{
			ArgIterator iterator = new ArgIterator(__arglist);
			//while (iterator.GetNextArgType(out Type type))
			//{
			//	object arg = iterator.GetNextArg();
			//	Console.WriteLine(arg);
			//}
		}



	}
	public class Data
	{

	}
	[System.Diagnostics.DebuggerDisplay("Name = {Name}, Age = {Age}, Address = {Address}")]
	public class Person
	{
		[System.Diagnostics.DebuggerDisplay("My name is {Name}")]// looks like it only works fro class
		public string Name { get; set; }
		public int Age { get; set; }
		public string Address { get; set; }
	}

	[System.Diagnostics.DebuggerDisplay("None = {None}, Sun = {Sun}, Moon = {Moon}, RedDwarf = {RedDwarf}")]
	public enum AstraBodies
	{
		None = 0,
		Sun = 1 << 0,
		Moon = 1 << 1,
		RedDwarf = 1 << 2,
	}
	#endregion

}