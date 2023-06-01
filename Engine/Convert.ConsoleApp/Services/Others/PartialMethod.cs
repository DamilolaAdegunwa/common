using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseApp.ConsoleApp.Services.Others
{
	public partial class MyClass
	{
		partial void PartialMethod();

		public void PublicMethod()
		{
			Console.WriteLine("Inside PublicMethod");
			PartialMethod();
		}
	}

	public partial class MyClass
	{
		partial void PartialMethod()
		{
			Console.WriteLine("Inside PartialMethod");
		}

		//partial void PartialMethod()
		//{
		//	Console.WriteLine("Another implementation of PartialMethod");
		//}

		//partial void PartialMethod();
	}

	public partial class MyClass
	{
		//partial void PartialMethod()
		//{
		//	Console.WriteLine("PartialMethod implementation in a different partial class");
		//}

		public void AnotherPublicMethod()
		{
			Console.WriteLine("Inside AnotherPublicMethod");
		}
	}

	public class Example
	{
		public static void Main()
		{
			var myClass = new MyClass();

			myClass.PublicMethod();
			myClass.AnotherPublicMethod();
		}
	}

}
