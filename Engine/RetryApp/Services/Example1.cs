using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetryApp.Services
{
	public class Example1
	{
		public static void Main_Example1()
		{
			var result = QueryCityData("New York City");
			var city = result.Item1;
			var pop = result.Item2;
			var size = result.Item3;
			// Do something with the data.
		}

		private static (string, int, double) QueryCityData(string name)
		{
			if (name == "New York City")
				return (name, 8175133, 468.48);

			return ("", 0, 0);
		}
	}

	public class ExampleDiscard
	{
		public static void Main_ExampleDiscard()
		{
			var (_, _, _, pop1, _, pop2) = QueryCityDataForYears("New York City", 1960, 2010);
			Console.WriteLine($"Population change, 1960 to 2010: {pop2 - pop1:N0}");
		}

		private static (string, double, int, int, int, int) QueryCityDataForYears(string name, int year1, int year2)
		{
			int population1 = 0, population2 = 0;
			double area = 0;

			if (name == "New York City")
			{
				area = 468.48;

				if (year1 == 1960)
				{
					population1 = 7781984;
				}

				if (year2 == 2010)
				{
					population2 = 8175133;
				}

				return (name, area, year1, population1, year2, population2);
			}

			return ("", 0, 0, 0, 0, 0);
		}
	}

	public class Person
	{
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string City { get; set; }
		public string State { get; set; }

		public Person(string fname, string mname, string lname, string cityName, string stateName)
		{
			FirstName = fname;
			MiddleName = mname;
			LastName = lname;
			City = cityName;
			State = stateName;
		}

		public void Deconstruct(out string fname, out string lname)
		{
			fname = FirstName;
			lname = LastName;
		}

		public void Deconstruct(out string fname, out string mname, out string lname)
		{
			fname = FirstName;
			mname = MiddleName;
			lname = LastName;
		}

		public void Deconstruct(out string fname, out string lname, out string city, out string state)
		{
			fname = FirstName;
			lname = LastName;
			city = City;
			state = State;
		}
	}

	public class ExampleClassDeconstruction
	{
		public static void Main_ExampleClassDeconstruction()
		{
			var p = new Person("John", "Quincy", "Adams", "Boston", "MA");

			var (fName, lName, city, state) = p;
			Console.WriteLine($"Hello {fName} {lName} of {city}, {state}!");
		}
	}

}
