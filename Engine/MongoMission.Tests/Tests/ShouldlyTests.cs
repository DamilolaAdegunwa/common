using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
//using RetryApp.Services;
using Shouldly;
namespace MongoMission.Tests.Tests
{
    public class ShouldlyTests
    {
		[Fact]
		public void Test1()
		{
			"".ShouldBe("Works");
			var theSimpsonsCat = new Cat { Name = "Santas little helper" };
			theSimpsonsCat.Name.ShouldBe("Snowball 2");

			const decimal pi = (decimal)Math.PI;
			pi.ShouldBe(3.24m, 0.01m);

			var date = new DateTime(2000, 6, 1);
			date.ShouldBe(new(2000, 6, 1, 1, 0, 1), TimeSpan.FromHours(1));

			var timeSpan = TimeSpan.FromHours(1);
			timeSpan.ShouldBe(timeSpan.Add(TimeSpan.FromHours(1.1d)), TimeSpan.FromHours(1));

			var apu = new Person { Name = "Apu" };
			var homer = new Person { Name = "Homer" };
			var skinner = new Person { Name = "Skinner" };
			var barney = new Person { Name = "Barney" };
			var theBeSharps = new List<Person> { homer, skinner, barney };
			theBeSharps.ShouldBe(new[] { apu, homer, skinner, barney });

			var firstSet = new[] { 1.23m, 2.34m, 3.45001m };
			var secondSet = new[] { 1.4301m, 2.34m, 3.45m };
			firstSet.ShouldBe(secondSet, 0.1m);
		}
	}

	internal class Person
	{
		public string Name { get; set; }
	}

	public class Cat
	{
		public string Name { get; set; }
	}
}
