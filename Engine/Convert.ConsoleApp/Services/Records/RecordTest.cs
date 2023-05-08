using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertApp.ConsoleApp.Services.Records
{
	public interface ITest
	{
		Task<int> Count();
	}
	public record RecordTest1 : RecordTest3
	{
	}

	public class RecordTest2
	{
	}

	public record RecordTest3 : ITest
	{
		Task<int> ITest.Count()
		{
			throw new NotImplementedException();
		}
	}
	//no record<=>class inheritance


}
