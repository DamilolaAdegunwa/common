using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using AngleSharp.Dom;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Extensions;
using Microsoft.FSharp.Core;
using static OpenAiProvider.OpenAiProvider;

namespace MongoMission.Tests.Tests
{
    public class FluentAssertionTests
    {
		[Fact]
        public async Task Method1()
        {
			string actual = "ABCDEFGHI";
			actual.Should().StartWith("AB").And.EndWith("HI").And.Contain("EF").And.HaveLength(9);

			string username = "dennis";
			username.Should().Be("jonas");

			Customer myClient = new Customer();
			//myClient.Should().BeActive("because we don't work with old clients");

			using (new AssertionScope())
			{
				5.Should().Be(10);
				"Actual".Should().Be("Expected");
			}

			object theObject = null;
			object obj1 = null;
			object obj2 = null;
			object obj3 = null;
			theObject.Should().BeNull("because the value is null");
			theObject.Should().NotBeNull();

			theObject = "whatever";
			theObject.Should().BeOfType<string>("because a {0} is set", typeof(string));
			theObject.Should().BeOfType(typeof(string), "because a {0} is set", typeof(string));

			object someObject = new Customer();
			someObject.Should().BeOfType<Exception>().Which.Message.Should().Be("Other Message");

			string otherObject = "whatever";
			theObject.Should().Be(otherObject, "because they have the same values");
			theObject.Should().NotBe(otherObject);

			theObject.Should().BeOneOf(obj1, obj2, obj3);

			theObject = otherObject;
			theObject.Should().BeSameAs(otherObject);
			theObject.Should().NotBeSameAs(otherObject);

			var ex = new ArgumentException();
			ex.Should().BeAssignableTo<Exception>("because it is an exception");
			ex.Should().NotBeAssignableTo<DateTime>("because it is an exception");

			var dummy = new Object();
			dummy.Should().Match(d => (d.ToString() == "System.Object"));
			dummy.Should().Match<string>(d => (d == "System.Object"));
			dummy.Should().Match((string d) => (d == "System.Object"));

			theObject.Should().BeXmlSerializable();
			theObject.Should().BeBinarySerializable();
			theObject.Should().BeDataContractSerializable();

			theObject.Should().BeBinarySerializable<Customer>(options => options.Excluding(s => s.SomeNonSerializableProperty));

			short? theShort = null;
			theShort.Should().NotHaveValue();
			theShort.Should().BeNull();
			theShort.Should().Match(x => !x.HasValue || x > 0);

			int? theInt = 3;
			theInt.Should().HaveValue();
			theInt.Should().NotBeNull();

			DateTime? theDate = null;
			theDate.Should().NotHaveValue();
			theDate.Should().BeNull();

			bool theBoolean = false;
			theBoolean.Should().BeFalse("it's set to false");

			var otherBoolean = false;
			theBoolean = true;
			theBoolean.Should().BeTrue();
			theBoolean.Should().Be(otherBoolean);
			theBoolean.Should().NotBe(false);

			theBoolean.Should().NotBe(false);
			theBoolean.Should().NotBe(true);

			bool anotherBoolean = true;
			theBoolean.Should().Imply(anotherBoolean);
			//--28/05/2023--
			string theString = "";
			theString.Should().NotBeNull();
			theString.Should().BeNull();
			theString.Should().BeEmpty();
			theString.Should().NotBeEmpty("because the string is not empty");
			theString.Should().HaveLength(0);
			theString.Should().BeNullOrWhiteSpace(); // either null, empty or whitespace only
			theString.Should().NotBeNullOrWhiteSpace();

			theString.Should().BeUpperCased();
			theString.Should().NotBeUpperCased();
			theString.Should().BeLowerCased();
			theString.Should().NotBeLowerCased();

			theString = "This is a String";
			theString.Should().Be("This is a String");
			theString.Should().NotBe("This is another String");
			theString.Should().BeEquivalentTo("THIS IS A STRING");
			theString.Should().NotBeEquivalentTo("THIS IS ANOTHER STRING");

			theString.Should().BeOneOf(
				"That is a String",
				"This is a String"
			);

			theString.Should().Contain("is a");
			theString.Should().Contain("is a", Exactly.Once());
			theString.Should().Contain("is a", AtLeast.Twice());
			theString.Should().Contain("is a", MoreThan.Thrice());
			theString.Should().Contain("is a", AtMost.Times(5));
			theString.Should().Contain("is a", LessThan.Twice());
			theString.Should().ContainAll("should", "contain", "all", "of", "these");
			theString.Should().ContainAny("any", "of", "these", "will", "do");
			theString.Should().NotContain("is a");
			theString.Should().NotContainAll("can", "contain", "some", "but", "not", "all");
			theString.Should().NotContainAny("can't", "contain", "any", "of", "these");
			theString.Should().ContainEquivalentOf("WE DONT CARE ABOUT THE CASING");
			theString.Should().ContainEquivalentOf("WE DONT CARE ABOUT THE CASING", Exactly.Once());
			theString.Should().ContainEquivalentOf("WE DONT CARE ABOUT THE CASING", AtLeast.Twice());
			theString.Should().ContainEquivalentOf("WE DONT CARE ABOUT THE CASING", MoreThan.Thrice());
			theString.Should().ContainEquivalentOf("WE DONT CARE ABOUT THE CASING", AtMost.Times(5));
			theString.Should().ContainEquivalentOf("WE DONT CARE ABOUT THE CASING", LessThan.Twice());
			theString.Should().NotContainEquivalentOf("HeRe ThE CaSiNg Is IgNoReD As WeLl");

			theString.Should().StartWith("This");
			theString.Should().NotStartWith("This");
			theString.Should().StartWithEquivalentOf("this");
			theString.Should().NotStartWithEquivalentOf("this");

			theString.Should().EndWith("a String");
			theString.Should().NotEndWith("a String");
			theString.Should().EndWithEquivalentOf("a string");
			theString.Should().NotEndWithEquivalentOf("a string");

			string emailAddress = "";
			string homeAddress = "";
			emailAddress.Should().Match("*@*.com");
			homeAddress.Should().NotMatch("*@*.com");

			emailAddress.Should().MatchEquivalentOf("*@*.COM");
			emailAddress.Should().NotMatchEquivalentOf("*@*.COM");

			var someString = "";
			var subject = "";
			someString.Should().MatchRegex("h.*\\sworld.$");
			someString.Should().MatchRegex(new Regex("h.*\\sworld.$"));
			subject.Should().NotMatchRegex(new Regex(".*earth.*"));
			subject.Should().NotMatchRegex(".*earth.*");

			someString.Should().MatchRegex("h.*\\sworld.$", Exactly.Once());
			someString.Should().MatchRegex(new Regex("h.*\\sworld.$"), AtLeast.Twice());

			theString.Should().Contain("is a", 4.TimesExactly()); // equivalent to Exactly.Times(4)
			theString.Should().Contain("is a", 4.TimesOrMore());  // equivalent to AtLeast.Times(4)
			theString.Should().Contain("is a", 4.TimesOrLess());  // equivalent to AtMost.Times(4)
																  //-1
			//int theInt = 5;
			theInt.Should().BeGreaterThanOrEqualTo(5);
			theInt.Should().BeGreaterThanOrEqualTo(3);
			theInt.Should().BeGreaterThan(4);
			theInt.Should().BeLessThanOrEqualTo(5);
			theInt.Should().BeLessThan(6);
			theInt.Should().BePositive();
			theInt.Should().Be(5);
			theInt.Should().NotBe(10);
			theInt.Should().BeInRange(1, 10);
			theInt.Should().NotBeInRange(6, 10);
			theInt.Should().Match(x => x % 2 == 1);

			theInt = 0;
			//theInt.Should().BePositive(); => Expected positive value, but found 0
			//theInt.Should().BeNegative(); => Expected negative value, but found 0

			theInt = -8;
			theInt.Should().BeNegative();
			int? nullableInt = 3;
			nullableInt.Should().Be(3);

			double theDouble = 5.1;
			theDouble.Should().BeGreaterThan(5);
			byte theByte = 2;
			theByte.Should().Be(2);
			//-2
			float value = 3.1415927F;
			value.Should().BeApproximately(3.14F, 0.01F);
			//float value = 3.5F;
			value.Should().NotBeApproximately(2.5F, 0.5F);
			value.Should().BeOneOf(3, 6 );
			//3
			var theDatetime = 1.March(2010).At(22, 15).AsLocal();

			theDatetime.Should().Be(1.March(2010).At(22, 15));
			theDatetime.Should().BeAfter(1.February(2010));
			theDatetime.Should().BeBefore(2.March(2010));
			theDatetime.Should().BeOnOrAfter(1.March(2010));
			theDatetime.Should().BeOnOrBefore(1.March(2010));
			theDatetime.Should().BeSameDateAs(1.March(2010).At(22, 16));
			theDatetime.Should().BeIn(DateTimeKind.Local);

			theDatetime.Should().NotBe(1.March(2010).At(22, 16));
			theDatetime.Should().NotBeAfter(2.March(2010));
			theDatetime.Should().NotBeBefore(1.February(2010));
			theDatetime.Should().NotBeOnOrAfter(2.March(2010));
			theDatetime.Should().NotBeOnOrBefore(1.February(2010));
			theDatetime.Should().NotBeSameDateAs(2.March(2010));

			theDatetime.Should().BeOneOf(
				1.March(2010).At(21, 15),
				1.March(2010).At(22, 15),
				1.March(2010).At(23, 15)
			);

			var theDatetimeOffset = 1.March(2010).At(22, 15).WithOffset(2.Hours());

			// Asserts the point in time. 
			theDatetimeOffset.Should().Be(1.March(2010).At(21, 15).WithOffset(1.Hours()));
			theDatetimeOffset.Should().NotBe(1.March(2010).At(21, 15).WithOffset(1.Hours()));

			//Asserts the calendar date/time and the offset
			theDatetimeOffset.Should().BeExactly(1.March(2010).At(21, 15).WithOffset(1.Hours()));
			theDatetimeOffset.Should().NotBeExactly(1.March(2010).At(21, 15).WithOffset(1.Hours()));
			theDatetime.Should().HaveDay(1);
			theDatetime.Should().HaveMonth(3);
			theDatetime.Should().HaveYear(2010);
			theDatetime.Should().HaveHour(22);
			theDatetime.Should().HaveMinute(15);
			theDatetime.Should().HaveSecond(0);

			theDatetime.Should().NotHaveDay(2);
			theDatetime.Should().NotHaveMonth(4);
			theDatetime.Should().NotHaveYear(2011);
			theDatetime.Should().NotHaveHour(23);
			theDatetime.Should().NotHaveMinute(16);
			theDatetime.Should().NotHaveSecond(1);

			//var theDatetimeOffset = 1.March(2010).AsUtc().WithOffset(2.Hours());

			theDatetimeOffset.Should().HaveOffset(TimeSpan.FromMinutes(2));
			theDatetimeOffset.Should().NotHaveOffset(TimeSpan.FromMinutes(3));
			//-3
			var otherDatetime = DateTime.Now;
			var deadline = DateTime.Now;
			var deliveryDate = DateTime.Now;
			var appointment = DateTime.Now;
			var someOtherTimeSpan = TimeSpan.Zero;
			theDatetime.Should().BeLessThan(10.Minutes()).Before(otherDatetime); // Equivalent to <
			theDatetime.Should().BeWithin(2.Hours()).After(otherDatetime);       // Equivalent to <=
			theDatetime.Should().BeMoreThan(1.Days()).Before(deadline);          // Equivalent to >
			theDatetime.Should().BeAtLeast(2.Days()).Before(deliveryDate);       // Equivalent to >=
			theDatetime.Should().BeExactly(24.Hours()).Before(appointment);      // Equivalent to ==
			//4																 //4
			theDatetime.Should().BeCloseTo(1.March(2010).At(22, 15), 2.Seconds());
			theDatetime.Should().NotBeCloseTo(2.March(2010), 1.Hours());
			//5
			var timeSpan = new TimeSpan(12, 59, 59);
			timeSpan.Should().BePositive();
			timeSpan.Should().BeNegative();
			timeSpan.Should().Be(12.Hours());
			timeSpan.Should().NotBe(1.Days());
			timeSpan.Should().BeLessThan(someOtherTimeSpan);
			timeSpan.Should().BeLessThanOrEqualTo(someOtherTimeSpan);
			timeSpan.Should().BeGreaterThan(someOtherTimeSpan);
			timeSpan.Should().BeGreaterThanOrEqualTo(someOtherTimeSpan);
			timeSpan.Should().BeCloseTo(new TimeSpan(13, 0, 0), 10.Ticks());
			timeSpan.Should().NotBeCloseTo(new TimeSpan(14, 0, 0), 10.Ticks());
			//6 - collection
			IEnumerable<int> collection = new[] { 1, 2, 5, 8 };

			collection.Should().NotBeEmpty()
				.And.HaveCount(4)
				.And.ContainInOrder(new[] { 2, 5 })
				.And.ContainItemsAssignableTo<int>();

			collection.Should().Equal(new List<int> { 1, 2, 5, 8 });
			collection.Should().Equal(1, 2, 5, 8);
			//collection.Should().NotEqual(8, 2, 3, 5);
			collection.Should().NotEqual(new int[] { 8, 2, 3, 5 });
			collection.Should().BeEquivalentTo(new[] { 8, 2, 1, 5 });
			collection.Should().NotBeEquivalentTo(new[] { 8, 2, 3, 5 });

			collection.Should().HaveCount(c => c > 3)
			  .And.OnlyHaveUniqueItems();

			collection.Should().HaveCountGreaterThan(3);
			collection.Should().HaveCountGreaterThanOrEqualTo(4);
			collection.Should().HaveCountLessThanOrEqualTo(4);
			collection.Should().HaveCountLessThan(5);
			collection.Should().NotHaveCount(3);
			collection.Should().HaveSameCount(new[] { 6, 2, 0, 5 });
			collection.Should().NotHaveSameCount(new[] { 6, 2, 0 });

			collection.Should().StartWith(1);
			collection.Should().StartWith(new[] { 1, 2 });
			collection.Should().EndWith(8);
			collection.Should().EndWith(new[] { 5, 8 });

			collection.Should().BeSubsetOf(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, });

			collection.Should().ContainSingle();
			collection.Should().ContainSingle(x => x > 3);
			collection.Should().Contain(8)
			  .And.HaveElementAt(2, 5)
			  .And.NotBeSubsetOf(new[] { 11, 56 });

			collection.Should().Contain(x => x > 3);
			collection.Should().Contain(collection, "", 5, 6); // It should contain the original items, plus 5 and 6.

			collection.Should().OnlyContain(x => x < 10);
			collection.Should().ContainItemsAssignableTo<int>();

			collection.Should().ContainInOrder(new[] { 1, 5, 8 });
			collection.Should().NotContainInOrder(new[] { 5, 1, 2 });

			collection.Should().ContainInConsecutiveOrder(new[] { 2, 5, 8 });
			collection.Should().NotContainInConsecutiveOrder(new[] { 1, 5, 8 });

			collection.Should().NotContain(82);
			collection.Should().NotContain(new[] { 82, 83 });
			collection.Should().NotContainNulls();
			collection.Should().NotContain(x => x > 10);

			object boxedValue = 2;
			collection.Should().ContainEquivalentOf(boxedValue); // Compared by object equivalence
			object unexpectedBoxedValue = 82;
			collection.Should().NotContainEquivalentOf(unexpectedBoxedValue); // Compared by object equivalence

			const int successor = 5;
			const int predecessor = 5;
			const int element = 5;
			collection.Should().HaveElementPreceding(successor, element);
			collection.Should().HaveElementSucceeding(predecessor, element);

			collection.Should().BeEmpty();
			collection.Should().BeNullOrEmpty();
			collection.Should().NotBeNullOrEmpty();

			IEnumerable<int> otherCollection = new[] { 1, 2, 5, 8, 1 };
			IEnumerable<int> anotherCollection = new[] { 10, 20, 50, 80, 10 };
			collection.Should().IntersectWith(otherCollection);
			collection.Should().NotIntersectWith(anotherCollection);

			var singleEquivalent = new[] { new { Size = 42 } };
			singleEquivalent.Should().ContainSingle()
				.Which.Should().BeEquivalentTo(new { Size = 42 });
		}
		public async Task Method2()
		{
			IEnumerable<int> numbers = new[] { 1, 2, 3 };
			numbers.Should().OnlyContain(n => n > 0);
			numbers.Should().HaveCount(4, "because we thought we put four items in the collection");
		}
		public async Task Method3()
		{
			//var recipe = new RecipeBuilder()
			//		.With(new IngredientBuilder().For("Milk").WithQuantity(200, Unit.Milliliters))
			//		.Build();
			//Action action = () => recipe.AddIngredient("Milk", 100, Unit.Spoon);
			//action
			//					.Should().Throw<RuleViolationException>()
			//					.WithMessage("*change the unit of an existing ingredient*")
			//					.And.Violations.Should().Contain(BusinessRule.CannotChangeIngredientQuantity);

			//dictionary.Should().ContainValue(myClass).Which.SomeProperty.Should().BeGreaterThan(0);
			//someObject.Should().BeOfType<Exception>().Which.Message.Should().Be("Other Message");
			//xDocument.Should().HaveElement("child").Which.Should().BeOfType<XElement>().And.HaveAttribute("attr", "1");
		}
	}
	public class ExampleTests
	{
		[Fact]
		public void TestEquality()
		{
			var value1 = 10;
			var value2 = 10;

			value1.Should().Be(value2); // Asserts that value1 is equal to value2
		}

		[Fact]
		public void TestInequality()
		{
			var value1 = 10;
			var value2 = 20;

			value1.Should().NotBe(value2); // Asserts that value1 is not equal to value2
		}

		[Fact]
		public void TestNull()
		{
			string str = null;

			str.Should().BeNull(); // Asserts that str is null
		}

		[Fact]
		public void TestNotNull()
		{
			var obj = new object();

			obj.Should().NotBeNull(); // Asserts that obj is not null
		}

		[Fact]
		public void TestStringContain()
		{
			string text = "Hello, World!";

			text.Should().Contain("Hello"); // Asserts that text contains the substring "Hello"
		}

		[Fact]
		public void TestStringStartWith()
		{
			string text = "Hello, World!";

			text.Should().StartWith("Hello"); // Asserts that text starts with the string "Hello"
		}

		[Fact]
		public void TestStringEndWith()
		{
			string text = "Hello, World!";

			text.Should().EndWith("World!"); // Asserts that text ends with the string "World!"
		}

		[Fact]
		public void TestCollectionContain()
		{
			var numbers = new[] { 1, 2, 3, 4, 5 };

			numbers.Should().Contain(3); // Asserts that numbers contains the value 3
		}

		[Fact]
		public void TestCollectionCount()
		{
			var numbers = new[] { 1, 2, 3, 4, 5 };

			numbers.Should().HaveCount(5); // Asserts that numbers has a count of 5
		}

		[Fact]
		public void TestCollectionOrder()
		{
			var numbers = new[] { 1, 2, 3, 4, 5 };

			numbers.Should().BeInAscendingOrder(); // Asserts that numbers is in ascending order
		}

		[Fact]
		public void TestException()
		{
			var calculator = new Calculator();

			Action action = () => calculator.Divide(10, 0);

			action.Should().Throw<DivideByZeroException>(); // Asserts that an exception of type DivideByZeroException is thrown
		}
	}

	public class Calculator
	{
		public int Divide(int dividend, int divisor)
		{
			return dividend / divisor;
		}
	}
	public class CustomerAssertions
	{
		private readonly Customer customer;

		public CustomerAssertions(Customer customer)
		{
			this.customer = customer;
		}

		[CustomAssertion]
		public void BeActive(string because = "", params object[] becauseArgs)
		{
			customer.Active.Should().BeTrue(because, becauseArgs);
		}
	}
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string SomeNonSerializableProperty { get; set; }
		public bool Active { get; set; }
	}
	internal class IngredientBuilder
	{
		public IngredientBuilder()
		{
		}
	}

	internal class RecipeBuilder
	{
		public RecipeBuilder()
		{
		}
	}
}
