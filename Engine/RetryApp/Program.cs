using Polly;
using Polly.Retry;
using RetryApp.Services;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Windows.Markup;

namespace RetryApp
{
	public class Program
	{
		public static string Name = "Damiilola Adegunwa";
		public string NickName = "Damiilola Adegunwa";
		public required string Status;
		[field: NonSerialized]
		public int Id { get; set; }
		[SetsRequiredMembers]
		public Program() {
			Status = string.Empty;
		}
		public static async Task Main()
		{
			//var x = Name;
			//var y = new Program().NickName;
			//Program_Animal.Main_Animal();
			//await Example.Main_Example();
			//var ts = Task.Run(() => { return "Hello"; });
			//var s = await ts;
			//Console.WriteLine($"the 's' value is: {s}");
			//ExampleAwaitClass.Main_Example();
			//ThreadStaticClass.Main_ThreadStaticClass();
			//Program_AutoResetEvent.Main_AutoResetEvent();
		}
		public void Method()
		{
			var x = Program.Name;
			var y = NickName;
		}
	}
}