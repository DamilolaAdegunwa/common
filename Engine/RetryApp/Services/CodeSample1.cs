using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RetryApp.Services
{
	public class Human
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public Human(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}
	}

	public unsafe class Program
	{
		public static void Main_Human()
		{
			var person = new Human("John", "Doe");

			DisplayFullName(person);
		}

		public static void DisplayFullName(in Human person)
		{
			if (person is { FirstName: var firstName, LastName: var lastName })
			{
				fixed (char* ptrFirstName = firstName, ptrLastName = lastName)
				{
					Console.WriteLine($"Full Name: {new string(ptrFirstName)} {new string(ptrLastName)}");
				}
				fixed (char* _t1 = "test1", _t2 = "test2")
				{
					//Console.WriteLine($"Full Name: {new string(ptrFirstName)} {new string(ptrLastName)}");
				}
			}
		}
	}
	public class ProgramWhen
	{
		public static void LogMessage(string message,
		[CallerMemberName] string memberName = "",
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0)
		{
			Console.WriteLine($"Message: {message}");
			Console.WriteLine($"Caller Member Name: {memberName}");
			Console.WriteLine($"Caller File Path: {filePath}");
			Console.WriteLine($"Caller Line Number: {lineNumber}");
		}
		public static void Main_ProgramWhen()
		{
			try
			{
				int result = Divide(10, 0);
				Console.WriteLine($"Result: {result}");
			}
			catch (DivideByZeroException ex) when (LogException(ex))
			{
				Console.WriteLine("DivideByZeroException caught");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception caught: {ex.Message}");
			}
		}

		public static int Divide(int dividend, int divisor)
		{
			try
			{
				return dividend / divisor;
			}
			catch (Exception ex) when (divisor == 0)
			{
				Console.WriteLine("Divisor cannot be zero.");
				throw;
			}
		}

		public static bool LogException(Exception ex)
		{
			Console.WriteLine($"Logging exception: {ex.Message}");
			return true; // return true to indicate that the exception should be caught
		}
	}
	public class Programdynamic
	{
		public static void Main_Programdynamic()
		{
			dynamic obj = GetDynamicObject();
			obj.PrintMessage("Hello, world!");
		}

		public static dynamic GetDynamicObject()
		{
			return new DynamicClass();
		}
	}

	public class DynamicClass
	{
		public void PrintMessage(string message)
		{
			Console.WriteLine($"Dynamic message: {message}");
		}
	}
	public partial class MyClass
	{
		public void ProcessData2()
		{
			// Perform some data processing logic
			// LogMessage("Data processing completed");
			// Perform other operations
		}
	}
	public partial class MyClass
	{
		//partial (impl)
		public partial void LogMessage1(string message);
		public partial void LogMessage1(string message)
		{
			// Implementation of the partial method
			Console.WriteLine($"Log: {message}");
		}
		public partial void LogMessage2(string message)
		{
			// Implementation of the partial method
			Console.WriteLine($"Log: {message}");
		}
		//partial (declaration)
		public partial void LogMessage3(string message);
		public partial void LogMessage4(string message);
		//non-partial
		public void ProcessData1()
		{
			// Perform some data processing logic
			//LogMessage("Data processing completed");
			// Perform other operations
		}
	}
	public partial class MyClass
	{
		//partial (declaration)
		public partial void LogMessage2(string message);
		//partial (impl)
		public partial void LogMessage3(string message)
		{
			// Implementation of the partial method
			Console.WriteLine($"Log: {message}");
		}
		public partial void LogMessage4(string message)
		{
			// Implementation of the partial method
			Console.WriteLine($"Log: {message}");
		}
		//non-partial
		public void ProcessData()
		{
			// Perform some data processing logic
			// LogMessage("Data processing completed");
			// Perform other operations
		}

	}

	//internal class CodeSample1
	//{
	//	public partial void LogMessage1(string message);
	//	public partial void LogMessage1(string message)
	//	{

	//	}
	//}
}