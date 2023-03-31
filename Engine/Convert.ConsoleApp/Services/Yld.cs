using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertApp.ConsoleApp.Services
{
	public class Yld
	{
		public Yld() {

		}

		public async IAsyncEnumerable<int> Ints()
		{
			await foreach(var i in Enumerable.Range(1,5).ToAsyncEnumerable())
			{
				//case 1
				//Task.Run(() => {
				//	Thread.Sleep(10000);//long running task
				//	yield return await Task.FromResult(i);
				//});

				//case 2
				//Thread.Sleep(10000);//long running task
				yield return i;
				Console.WriteLine(i);
			}
		}

		public async IAsyncEnumerable<int> IntsX10()
		{
			await foreach (var i in Ints())
			{
				int i10 = i * 10;
				yield return i10;
				Console.WriteLine(i10);
			}
		}

		public async IAsyncEnumerable<int> IntsRightShift()
		{
			await foreach (var i in IntsX10())
			{
				int ils1 = i >> 1;
				yield return ils1;
				Console.WriteLine(ils1);
			}
		}

		public async IAsyncEnumerator<int> TestObject()
		{
			yield return default(int);
		}

		//day 2
		IEnumerable<int> CountTo100TwiceOld()
		{
			int i;
			for (i = 1; i <= 100; i++)
			{
				yield return i;
			}
			for (i = 1; i <= 100; i++)
			{
				yield return i;
			}
		}

		//IEnumerable<int> CountTo100Twice()
		//{
		//	var x = "Hello".Repeat(100);
		//	CountTo100();
		//	CountTo100();
		//}

		//void CountTo100()
		//{
		//	int i;
		//	for (i = 1; i <= 100; i++)
		//	{
		//		yield return i;
		//	}
		//}

		/*
			ObjectType instance = (ObjectType)Activator.CreateInstance(objectType);

			ObjectType instance = (ObjectType)Activator.CreateInstance("MyAssembly","MyNamespace.ObjectType");
		 */
	}
}
