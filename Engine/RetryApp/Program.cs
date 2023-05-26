using Polly;
using Polly.Retry;
using RetryApp.Services;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
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
		public static void Main()
		{
			var x = Name;
			var y = new Program().NickName;
			Program_Animal.Main_Animal();
		}
		public void Method()
		{
			var x = Program.Name;
			var y = NickName;
		}
	}
}