using Polly;
using Polly.Retry;
using RetryApp.Services;
using System.Net.Http;
namespace RetryApp
{
	public class Program
	{
		public static void Main()
		{
			Program_Animal.Main_Animal();
		}
	}
}