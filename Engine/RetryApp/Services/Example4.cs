using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Org.BouncyCastle.Math.EC;
using Polly.Retry;
using Polly;
using System.Xml.Linq;
using System.Runtime.CompilerServices;

namespace RetryApp.Services
{

	class BaseClass
	{
		public BaseClass()
		{
			DoWork();
		}
		public virtual void DoWork()
		{

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
			if (string.IsNullOrEmpty(_name))
			{
				_name = "empty!";
			}
			Console.WriteLine(_name);
		}
	}

	public class SimpleClass
	{
		public SimpleClass() { }
	}
	public class SimpleClassExample
	{
		public static string _namespace;
		public static string _name;
		public SimpleClassExample()
		{
			_namespace = this.GetType().Namespace;
			_name = this.GetType().Name;
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
		public static void Main_SAC(string[] args)
		{
			var myc = MyC.Create();
			//SAC aSAC = new SAC();
			SAC.Name();
			new EmailSender().SendEMail("damee1993@gmail.com", "shout out", "shout!!");
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
		public static void Main_SimpleClassExample()
		{
			Type t = typeof(SimpleClass);
			BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
				BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
			MemberInfo[] members = t.GetMembers(flags);
			Console.WriteLine($"Type {t.Name} has {members.Length} members: ");

			foreach (MemberInfo member in members)
			{
				string access = "";
				string stat = "";
				var method = member as MethodBase;

				if (method != null)
				{
					if (method.IsPublic)
						access = " Public";
					else if (method.IsPrivate)
						access = " Private";
					else if (method.IsFamily)
						access = " Protected";
					else if (method.IsAssembly)
						access = " Internal";
					else if (method.IsFamilyOrAssembly)
						access = " Protected Internal ";

					if (method.IsStatic)
						stat = " Static";
				}

				string output = $"{member.Name} ({member.MemberType}):{access}{stat}, Declared by {member.DeclaringType}";
				Console.WriteLine(output);
			}
		}
	}
	// The example displays the following output:
	// Type SimpleClass has 9 members:
	// ToString (Method): Public, Declared by System.Object
	// Equals (Method): Public, Declared by System.Object
	// Equals (Method): Public Static, Declared by System.Object
	// ReferenceEquals (Method): Public Static, Declared by System.Object
	// GetHashCode (Method): Public, Declared by System.Object
	// GetType (Method): Public, Declared by System.Object
	// Finalize (Method): Internal, Declared by System.Object
	// MemberwiseClone (Method): Internal, Declared by System.Object
	// .ctor (Constructor): Public, Declared by SimpleClass
	public enum PublicationType { Misc, Book, Magazine, Article };

	public abstract class Publication
	{
		private bool _published = false;
		private DateTime _datePublished;
		private int _totalPages;

		public Publication(string title, string publisher, PublicationType type)
		{
			if (string.IsNullOrWhiteSpace(publisher))
				throw new ArgumentException("The publisher is required.");
			Publisher = publisher;

			if (string.IsNullOrWhiteSpace(title))
				throw new ArgumentException("The title is required.");
			Title = title;

			Type = type;
		}

		public string Publisher { get; }
		public string Title { get; }
		public PublicationType Type { get; }
		public string? CopyrightName { get; private set; }
		public int CopyrightDate { get; private set; }

		public int Pages
		{
			get { return _totalPages; }
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException(nameof(value), "The number of pages cannot be zero or negative.");
				_totalPages = value;
			}
		}

		public string GetPublicationDate()
		{
			if (!_published)
				return "NYP";
			else
				return _datePublished.ToString("d");
		}

		public void Publish(DateTime datePublished)
		{
			_published = true;
			_datePublished = datePublished;
		}

		public void Copyright(string copyrightName, int copyrightDate)
		{
			if (string.IsNullOrWhiteSpace(copyrightName))
				throw new ArgumentException("The name of the copyright holder is required.");
			CopyrightName = copyrightName;

			int currentYear = DateTime.Now.Year;
			if (copyrightDate < currentYear - 10 || copyrightDate > currentYear + 2)
				throw new ArgumentOutOfRangeException($"The copyright year must be between {currentYear - 10} and {currentYear + 1}");
			CopyrightDate = copyrightDate;
		}

		public override string ToString() => Title;
	}
	public sealed class Book : Publication
	{
		public Book(string title, string author, string publisher) : this(title, string.Empty, author, publisher)
		{ }

		public Book(string title, string isbn, string author, string publisher) : base(title, publisher, PublicationType.Book)
		{
			if (!string.IsNullOrEmpty(isbn))
			{
				if (!(isbn.Length == 10 || isbn.Length == 13))
					throw new ArgumentException("The ISBN must be a 10- or 13-character numeric string.");

				if (!ulong.TryParse(isbn, out _))
					throw new ArgumentException("The ISBN can consist of numeric characters only.");
			}

			ISBN = isbn;
			Author = author;
		}

		public string ISBN { get; }
		public string Author { get; }
		public decimal Price { get; private set; }
		public string? Currency { get; private set; }

		public decimal SetPrice(decimal price, string currency)
		{
			if (price < 0)
				throw new ArgumentOutOfRangeException(nameof(price), "The price cannot be negative.");

			decimal oldValue = Price;
			Price = price;

			if (currency.Length != 3)
				throw new ArgumentException("The ISO currency symbol is a 3-character string.");

			Currency = currency;

			return oldValue;
		}

		public override bool Equals(object? obj)
		{
			if (obj is not Book book)
				return false;
			else
				return ISBN == book.ISBN;
		}

		public override int GetHashCode() => ISBN.GetHashCode();

		public override string ToString() => $"{(string.IsNullOrEmpty(Author) ? "" : Author + ", ")}{Title}";
	}
	public class ClassExample
	{
		public static void Main_ClassExample()
		{
			var book = new Book("The Tempest", "0971655819", "Shakespeare, William", "Public Domain Press");
			ShowPublicationInfo(book);

			book.Publish(new DateTime(2016, 8, 18));
			ShowPublicationInfo(book);

			var book2 = new Book("The Tempest", "Classic Works Press", "Shakespeare, William");

			Console.Write($"{book.Title} and {book2.Title} are the same publication: {((Publication)book).Equals(book2)}");
		}

		public static void ShowPublicationInfo(Publication pub)
		{
			string pubDate = pub.GetPublicationDate();
			Console.WriteLine($"{pub.Title}, {(pubDate == "NYP" ? "Not Yet Published" : "published on " + pubDate):d} by {pub.Publisher}");
		}
	}
	public abstract class Shape
	{
		public abstract double Area { get; }
		public abstract double Perimeter { get; }

		public override string ToString() => GetType().Name;

		public static double GetArea(Shape shape) => shape.Area;

		public static double GetPerimeter(Shape shape) => shape.Perimeter;
	}
	public class Square : Shape
	{
		public Square(double length)
		{
			Side = length;
		}

		public double Side { get; }

		public override double Area => Math.Pow(Side, 2);

		public override double Perimeter => Side * 4;

		public double Diagonal => Math.Round(Math.Sqrt(2) * Side, 2);
	}

	public class Rectangle : Shape
	{
		public Rectangle(double length, double width)
		{
			Length = length;
			Width = width;
		}

		public double Length { get; }

		public double Width { get; }

		public override double Area => Length * Width;

		public override double Perimeter => 2 * Length + 2 * Width;

		public bool IsSquare() => Length == Width;

		public double Diagonal => Math.Round(Math.Sqrt(Math.Pow(Length, 2) + Math.Pow(Width, 2)), 2);
	}

	public class Circle : Shape
	{
		public Circle(double radius)
		{
			Radius = radius;
		}

		public override double Area => Math.Round(Math.PI * Math.Pow(Radius, 2), 2);

		public override double Perimeter => Math.Round(Math.PI * 2 * Radius, 2);

		public double Circumference => Perimeter;

		public double Radius { get; }

		public double Diameter => Radius * 2;
	}

	public class Example
	{
		public static void Main_Example()
		{
			Shape[] shapes = {
				new Rectangle(10, 12),
				new Square(5),
				new Circle(3)
			};

			foreach (Shape shape in shapes)
			{
				Console.WriteLine($"{shape}: area, {Shape.GetArea(shape)}; perimeter, {Shape.GetPerimeter(shape)}");

				if (shape is Rectangle rect)
				{
					Console.WriteLine($" Is Square: {rect.IsSquare()}, Diagonal: {rect.Diagonal}");
					continue;
				}

				if (shape is Square sq)
				{
					Console.WriteLine($" Diagonal: {sq.Diagonal}");
					continue;
				}
			}
			var g = new Giraffe();
			var a = new MyAnimal();
			FeedMammals(g);
			FeedMammals(a);

			// Output:
			// Eating.
			// Animal is not a Mammal

			SuperNova sn = new SuperNova();
			TestForMammals(g);
			TestForMammals(sn);
			int i = 5;
			PatternMatchingNullable(i);

			int? j = null;
			PatternMatchingNullable(j);

			double d = 9.78654;
			PatternMatchingNullable(d);

			PatternMatchingSwitch(i);
			PatternMatchingSwitch(j);
			PatternMatchingSwitch(d);
		}

		public static void PatternMatchingNullable(ValueType? val)
		{
			if (val is int j) // Nullable types are not allowed in patterns
			{
				Console.WriteLine(j);
			}
			else if (val is null) // If val is a nullable type with no value, this expression is true
			{
				Console.WriteLine("val is a nullable type with the null value");
			}
			else
			{
				Console.WriteLine("Could not convert " + val.ToString());
			}
		}

		public static void PatternMatchingSwitch(ValueType? val)
		{
			switch (val)
			{
				case int number:
					Console.WriteLine(number);
					break;
				case long number:
					Console.WriteLine(number);
					break;
				case decimal number:
					Console.WriteLine(number);
					break;
				case float number:
					Console.WriteLine(number);
					break;
				case double number:
					Console.WriteLine(number);
					break;
				case null:
					Console.WriteLine("val is a nullable type with the null value");
					break;
				default:
					Console.WriteLine("Could not convert " + val.ToString());
					break;
			}
		}

		public static void FeedMammals(MyAnimal a)
		{
			if (a is Mammal m)
			{
				m.Eat();
			}
			else
			{
				Console.WriteLine($"{a.GetType().Name} is not a Mammal");
			}
		}

		public static void TestForMammals(object o)
		{
			var m = o as Mammal;
			if (m != null)
			{
				Console.WriteLine(m.ToString());
			}
			else
			{
				Console.WriteLine($"{o.GetType().Name} is not a Mammal");
			}
		}
	}
	// Output:
	// I am an animal.
	// SuperNova is not a Mammal
	public class MyAnimal
	{
		public void Eat()
		{
			Console.WriteLine("Eating.");
		}

		public override string ToString()
		{
			return "I am an animal.";
		}
	}

	public class Mammal : MyAnimal
	{
	}

	public class Giraffe : Mammal
	{
	}

	public class SuperNova
	{
	}

	public partial interface ISAC
	{
		//public static abstract string name { get; set; }
		public static abstract string Name();
		//public extern string Name2();
		static partial void Name3();
		//static virtual void Name4();
	}

	public abstract class ASAC : ISAC
	{
		public static string name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public static  string Name()
		{
			throw new NotImplementedException();
		}
	}

	public class SAC : ISAC
	{
		public static string name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public static string Name()
		{
			Console.WriteLine("see!, it works!! Name");
			return string.Empty;
			//throw new NotImplementedException();
		}
	}
	public class MyC
	{
		public string name { get; set; } = "untouched!";
		private MyC() { }
		public static MyC Create()
		{
			return new MyC();
		}
		public static void Validate(bool condition, [CallerArgumentExpression("condition")] string? message = null)
		{
			if (!condition)
			{
				throw new InvalidOperationException($"Argument failed validation: <{message}>");
			}
		}
	}
	public enum nameable : long
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

	//record: abstract, partial, sealed, unsafe
	public abstract record Person3(string FirstName, string LastName);
	public sealed record Person4(string FirstName, string LastName);
	public partial record Person5(string FirstName, string LastName);
	public unsafe record Person6(string FirstName, string LastName);

	public record Person2
	{
		public required string FirstName { get; init; }
		public required string LastName { get; init; }
	}

	//interface: partial, unsafe
	public unsafe interface ITest{ }

	//class: abstract, sealed, partial, static, unsafe
	public class TestClass{
		public string name { get; init; }
		public TestClass()
		{
			name = "test";
		}
		public void Method()
		{
			//name = "test";
		}
	}
	public class TestClass2
	{
		public TestClass2()
		{
		}
		public void Method()
		{
			var tc = new TestClass {
				name = "new"
			 };
			//tc.name = "more";
		}
	}

	public class ProgramRef
	{
		public static void Main_ProgramRef()
		{
			int[] numbers = { 1, 2, 3, 4, 5 };

			ref readonly int numberRef = ref FindNumber(numbers, 3);

			Console.WriteLine("Found number: " + numberRef);
		}

		public static ref readonly int FindNumber(int[] numbers, int target)
		{
			for (int i = 0; i < numbers.Length; i++)
			{
				if (numbers[i] == target)
				{
					return ref numbers[i];
				}
			}

			throw new InvalidOperationException("Number not found.");
		}
	}
	public unsafe struct MyStruct
	{
		public fixed int Numbers[5];
	}

	public class ProgramMyStruct
	{
		public static void Main_ProgramMyStruct()
		{
			MyStruct myStruct;
			unsafe
			{
				// Assign values to the fixed array without pinning
				for (int i = 0; i < 5; i++)
				{
					myStruct.Numbers[i] = i + 1;
				}

				// Access the fixed array without pinning
				for (int i = 0; i < 5; i++)
				{
					Console.WriteLine("Number at index " + i + ": " + myStruct.Numbers[i]);
				}
			}
		}
	}
	public unsafe class ProgramUnsafe
	{
		public static unsafe void Main_ProgramUnsafe()
		{
			int[] numbers = { 1, 2, 3, 4, 5 };

			fixed (int* ptr = numbers)
			{
				int* pinnedPtr = ptr;

				// Access the pinned memory location
				for (int i = 0; i < 5; i++)
				{
					Console.WriteLine("Number at index " + i + ": " + pinnedPtr[i]);
				}
			}
		}
	}
	public class ProgramReassign
	{
		public static void Main_ProgramReassign()
		{
			int[] numbers = { 1, 2, 3, 4, 5 };

			ref int refNumber = ref FindNumber(numbers, 3);

			Console.WriteLine("Initial number: " + refNumber);

			// Reassign the ref local variable to a different element
			refNumber = ref FindNumber(numbers, 4);
			//refNumber = 5;
			Console.WriteLine("Updated number: " + refNumber);
		}

		public static ref int FindNumber(int[] numbers, int target)
		{
			for (int i = 0; i < numbers.Length; i++)
			{
				if (numbers[i] == target)
				{
					return ref numbers[i];
				}
			}

			throw new InvalidOperationException("Number not found.");
		}
	}

	public unsafe class Programstackalloc
	{
		public static void Main_Programstackalloc()
		{
			int* numbers = stackalloc int[5] { 1, 2, 3, 4, 5 };

			Console.WriteLine("Numbers:");
			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine(numbers[i]);
			}
		}
		public static void Main_RetryApp()
		{
			var m = new MyClass();
			ProgramWhen.LogMessage("Hello, World!!");
			var my = MyC.Create();
			MyC.Validate(false);
			my.name = "test";
			var my2 = Return(my);
			Console.WriteLine(my.name);
		}
		public static MyC Return(MyC my)
		//if it change, i can use something like this to achieve encapsulation for acting on the object
		//if not, it'd be used for cloning
		{
			my.name = "changed!";
			return my;
		}
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