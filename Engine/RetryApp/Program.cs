using Polly;
using Polly.Retry;
using RetryApp.Services;
using System.Net.Http;

namespace RetryApp
{
    class BaseClass
    {
        public BaseClass() 
        {
            DoWork();
        }
        public virtual void DoWork() {
            
        }
    }
	class DerivedClass : BaseClass
	{
        private string _name = "untouched!";
		public DerivedClass()
		{
			_name = "touched!";
		}
		public override void DoWork() 
        {
            if(string.IsNullOrEmpty(_name))
            {
                _name = "empty!";
            }
            Console.WriteLine(_name);
        }
	}

	public class Program
    {
        public static string _namespace;
        public static string _name;
        public Program()
        {
            _namespace = this.GetType().Namespace;
            _name = this.GetType().Name;
        }
        public static void Main(string[] args)
        {
            DerivedClass d = (DerivedClass)new object();
            d.DoWork();
            var q = System.Runtime.Serialization.FormatterServices.GetSafeUninitializedObject(typeof(DerivedClass));
            ((DerivedClass)q).DoWork();
            var w = System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(DerivedClass));
            ((DerivedClass)w).DoWork();
            var x = new DerivedClass();
            _ = new Program();
            var fns = $"{_namespace}.{_name}";
            var str = "www";
            var byt = System.Text.Encoding.UTF8.GetBytes(str);
            var hexStr = Convert.ToHexString(byt);
            var byt2 = Convert.FromHexString(hexStr);
            var str2 = System.Text.Encoding.UTF8.GetString(byt2);

			Console.WriteLine(hexStr);
			Console.WriteLine("Hello, World!");

			//new Program().RetrySample1().Wait();
			//foreach (var (item,i) in "Damilola") { Console.WriteLine($"s/n{i}: {item}"); }
			Console.WriteLine("done!");
        }

        public async Task RetrySample1()
        {
            var client = new HttpClient(new RetryHandler());
            var response = await client.GetAsync("http://example.com");
            Console.WriteLine(response);
        }

        public async Task RetrySample2()
        {
            AsyncRetryPolicy policy = Policy
    .Handle<HttpRequestException>()
    //.OrResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
    .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
            var handler = new RetryHandler(policy);
            var client = new HttpClient(handler);
            var response = await client.GetAsync("http://example.com");

        }

        public async Task RetrySample3()
        {
            var policy = Policy
    .Handle<TimeoutException>()
    .RetryAsync(3, onRetry: (ex, count) => Console.WriteLine($"Timeout retry #{count}"));
            var handlers = new List<DelegatingHandler>()
            {
                new RetryHandler(policy),
                new AuthenticationHandler(),
                new LoggingHandler(),
                new TimeoutHandler()
            };
            var client = HttpClientFactory.Create(handlers.ToArray());
            var response = await client.GetAsync("http://example.com");

        }
    }

    public enum nameable: long
    {
        None = 0,
        a = 1 << 3000,
    }

	//public ClassName() : this(par1, par2)
	//{
	//	// do not call the constructor it is called in the this.
	//	// the base key- word is used to call a inherited constructor   
	//}
	//var h = HttpContext.Connection.RemoteIpAddress.ToString();
	[Flags]
	public enum MyEnum
	{
		None = 0,
		First = 1 << 0,
		Second = 1 << 1,
		Third = 1 << 2,
		Fourth = 1 << 3
	}
	[Flags]
	public enum MyColors
	{
		Yellow = 1,
		Green = 2,
		Red = 4,
		Blue = 8
	}
}
/*
 Microsoft (R) Visual C# Interactive Compiler version 4.4.0-6.22559.4 ()
Loading context from 'CSharpInteractive.rsp'.
Type "#help" for more information.
public enum Options
{
    None = 0,
    Option1 = 1,
    Option2 = 2,
    Option3 = 4,
    Option4 = Option1 | Option2
}

(int)Option4
(1,6): error CS0103: The name 'Option4' does not exist in the current context
(int)Option3
(1,6): error CS0103: The name 'Option3' does not exist in the current context
(int)Options.Option4
3
0 | 1
1
1|2
3
public enum Options
{
    None = 0,
    Option1 = 1,
    Option2 = 2,
    Option3 = 4,
    Option4 = 8
}

var o12 = Options.Option1 | Options.Option2;
(o12 | Options.Option2) != 0
true
o12 | Options.Option2
3
(o12 & Options.Option2) != 0
true
o12 & Options.Option2
Option2
o12 & Options.Option3
None
var o24 = Options.Option2 | Options.Option4;
o24 & Options.Option2
Option2
o24 & Options.Option3
None
o24 & Options.Option1
None
[Flags]
public enum MyEnum
{
    None = 0,
    First = 1 << 0,
    Second = 1 << 1,
    Third = 1 << 2,
    Fourth = 1 << 3
}
MyEnum.Fourth
Fourth
(int)MyEnum.Fourth
8
[Flags]
public enum MyColors
{
    Yellow = 1,
    Green = 2,
    Red = 4,
    Blue = 8
}
var yg = MyColors.Yellow | MyColors.Green;
#reset 64
Resetting execution engine.
Loading context from 'CSharpInteractive.rsp'.
[Flags]
public enum MyColors
{
    Yellow = 1,
    Green = 2,
    Red = 4,
    Blue = 8
}
var yg = MyColors.Yellow | MyColors.Green;
yg & MyColors.Blue
0
public enum MyColours
{
    Yellow = 1,
    Green = 2,
    Red = 4,
    Blue = 8
}

var yg2 = MyColours.Yellow | MyColours.Green;
yg2 & MyColours.Blue
0
var a = MyColours.Green;
var b = MyColours.Blue;

var chooosen = MyColours.Yellow | MyColours.Green | MyColours.Red;

((chooosen) & (a | b)) == (a | b)
false
b = MyColours.Yellow
Yellow
((chooosen) & (a | b)) == (a | b)
true

 */