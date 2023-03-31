using ConvertApp.ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertApp.ConsoleApp
{
	public class Run
	{
		public static async Task Main()
		{
			Dummy instance = (Dummy)Activator.CreateInstance(typeof(Dummy));
			IAsyncEnumerable<int> ae = new Yld().IntsRightShift();
			List<int> list = await ae.ToListAsync();
			Console.WriteLine("done!");
		}
	}
}
