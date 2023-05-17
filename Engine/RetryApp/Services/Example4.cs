using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Org.BouncyCastle.Math.EC;

namespace RetryApp.Services
{
	public class SimpleClass
	{
		public SimpleClass() { }
	}
	public class SimpleClassExample
	{
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
			var a = new Animal();
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

		public static void FeedMammals(Animal a)
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
	public class Animal
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

	public class Mammal : Animal
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
		//virtual void Name4();
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
}