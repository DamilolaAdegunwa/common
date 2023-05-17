using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Reflection;
namespace RetryApp.Services
{
	//internal class Example2_ReflectionExtensions
	//{
	//}

	public static class ReflectionExtensions
	{
		public static void Deconstruct(this PropertyInfo p, out bool isStatic, out bool isReadOnly, out bool isIndexed, out Type propertyType)
		{
			var getter = p.GetMethod;
			isReadOnly = !p.CanWrite;
			isStatic = getter?.IsStatic??false;
			isIndexed = p.GetIndexParameters().Length > 0;
			propertyType = p.PropertyType;
		}

		public static void Deconstruct(this PropertyInfo p, out bool hasGetAndSet, out bool sameAccess, out string access, out string getAccess, out string setAccess)
		{
			hasGetAndSet = sameAccess = false;
			string getAccessTemp = null;
			string setAccessTemp = null;
			MethodInfo getter = null;

			if (p.CanRead)
				getter = p.GetMethod;

			MethodInfo setter = null;
			if (p.CanWrite)
				setter = p.SetMethod;

			if (setter != null && getter != null)
				hasGetAndSet = true;

			if (getter != null)
			{
				if (getter.IsPublic)
					getAccessTemp = "public";
				else if (getter.IsPrivate)
					getAccessTemp = "private";
				else if (getter.IsAssembly)
					getAccessTemp = "internal";
				else if (getter.IsFamily)
					getAccessTemp = "protected";
				else if (getter.IsFamilyOrAssembly)
					getAccessTemp = "protected internal";
			}

			if (setter != null)
			{
				if (setter.IsPublic)
					setAccessTemp = "public";
				else if (setter.IsPrivate)
					setAccessTemp = "private";
				else if (setter.IsAssembly)
					setAccessTemp = "internal";
				else if (setter.IsFamily)
					setAccessTemp = "protected";
				else if (setter.IsFamilyOrAssembly)
					setAccessTemp = "protected internal";
			}

			if (setAccessTemp == getAccessTemp)
			{
				sameAccess = true;
				access = getAccessTemp;
				getAccess = setAccess = String.Empty;
			}
			else
			{
				access = null;
				getAccess = getAccessTemp;
				setAccess = setAccessTemp;
			}
		}
	}

	public class ExampleExtension
	{
		public static void Main_ExampleExtension()
		{
			Type dateType = typeof(DateTime);
			PropertyInfo prop = dateType.GetProperty("Now");
			var (isStatic, isRO, isIndexed, propType) = prop;

			Console.WriteLine($"\nThe {dateType.FullName}.{prop.Name} property:");
			Console.WriteLine($" PropertyType: {propType.Name}");
			Console.WriteLine($" Static: {isStatic}");
			Console.WriteLine($" Read-only: {isRO}");
			Console.WriteLine($" Indexed: {isIndexed}");

			Type listType = typeof(List<>);
			prop = listType.GetProperty("Item", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
			var (hasGetAndSet, sameAccess, accessibility, getAccessibility, setAccessibility) = prop;

			Console.Write($"\nAccessibility of the {listType.FullName}.{prop.Name} property: ");

			if (!hasGetAndSet || sameAccess)
			{
				Console.WriteLine(accessibility);
			}
			else
			{
				Console.WriteLine($"\n The get accessor: {getAccessibility}");
				Console.WriteLine($" The set accessor: {setAccessibility}");
			}

			Dictionary<string, int> snapshotCommitMap = new(StringComparer.OrdinalIgnoreCase)
			{
				["https://github.com/dotnet/docs"] = 16_465,
				["https://github.com/dotnet/runtime"] = 114_223,
				["https://github.com/dotnet/installer"] = 22_436,
				["https://github.com/dotnet/roslyn"] = 79_484,
				["https://github.com/dotnet/aspnetcore"] = 48_386
			};

			foreach (var (repo, commitCount) in snapshotCommitMap)
			{
				Console.WriteLine($"The {repo} repository had {commitCount:N0} commits as of November 10th, 2021.");
			}

			int? nullableValue = 42;
			var (hasValue, value) = nullableValue;

			if (hasValue)
			{
				Console.WriteLine($"Nullable value has value: {value}");
			}
			else
			{
				Console.WriteLine("Nullable value is null.");
			}

			DateTime? questionableDateTime = default;
			var (hasValue2, value2) = questionableDateTime;
			Console.WriteLine($"{{ HasValue = {hasValue2}, Value = {value2} }}");

			questionableDateTime = DateTime.Now;
			(hasValue2, value2) = questionableDateTime;
			Console.WriteLine($"{{ HasValue = {hasValue2}, Value = {value2} }}");

			// Example outputs:
			// { HasValue = False, Value = 1/1/0001 12:00:00 AM }
			// { HasValue = True, Value = 11/10/2021 6:11:45 PM }
			
		}
		public static void TestThrow()
		{
			throw new CustomException("Custom exception in TestThrow()");
		}
	}
	// The example displays the following output:
	// The System.DateTime.Now property:
	// PropertyType: DateTime
	// Static: True
	// Read-only: True
	// Indexed: False
	//
	// Accessibility of the System.Collections.Generic.List`1.Item property: public
	public static class NullableExtensions
	{
		public static void Deconstruct<T>(this T? nullable, out bool hasValue, out T value)
			where T : struct
		{
			hasValue = nullable.HasValue;
			value = nullable.GetValueOrDefault();
		}
	}
	class CustomException : Exception
	{
		public CustomException(string message)
		{
		}
	}
	public class CatchOrder
	{
		public static void Main_CatchOrder()
		{
			try
			{
				using (var sw = new StreamWriter("./test.txt"))
				{
					sw.WriteLine("Hello");
				}
			}
			// Put the more specific exceptions first.
			catch (DirectoryNotFoundException ex)
			{
				Console.WriteLine(ex);
			}
			catch (FileNotFoundException ex)
			{
				Console.WriteLine(ex);
			}
			// Put the least specific exception last.
			catch (IOException ex)
			{
				Console.WriteLine(ex);
			}

			Console.WriteLine("Done");
		}
		int GetInt(int[] array, int index)
		{
			try
			{
				return array[index];
			}
			catch (IndexOutOfRangeException e) when (index < 0)
			{
				throw new ArgumentOutOfRangeException("Parameter index cannot be negative.", e);
			}
			catch (IndexOutOfRangeException e)
			{
				throw new ArgumentOutOfRangeException("Parameter index cannot be greater than the array size.", e);
			}
		}
		public static void Main_Exception()
		{
			try
			{
				string? s = null;
				Console.WriteLine(s.Length);
			}
			catch (Exception e) when (LogException(e))
			{
			}
			Console.WriteLine("Exception must have been handled");
		}

		private static bool LogException(Exception e)
		{
			Console.WriteLine($"\tIn the log routine. Caught {e.GetType()}");
			Console.WriteLine($"\tMessage: {e.Message}");
			return false;
		}
		public static void ExceptionTest()
		{
			FileStream? file = null;
			FileInfo fileInfo = new System.IO.FileInfo("./file.txt");
			try
			{
				file = fileInfo.OpenWrite();
				file.WriteByte(0xF);
			}
			finally
			{
				// Check for null because OpenWrite might have failed.
				file?.Close();
			}

		}
	}
	public interface IWorkerQueue
	{
	}
	public class ExampleEvents
	{
		// A public field, these should be used sparingly
		public bool IsValid;
		// An init-only property
		public IWorkerQueue WorkerQueue { get; init; }
		// An event
		public event Action EventProcessing;

		// Method
		public void StartEventProcessing()
		{
			// Local function
			//static int CountQueueItems() => WorkerQueue.Count;

			// ...
		}
	}
	public record PhysicalAddress(string Street, string City, string StateOrProvince, string ZipCode);
}
