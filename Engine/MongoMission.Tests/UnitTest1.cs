using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using Newtonsoft.Json;
using System.Collections;
using System.Configuration;
using Microsoft.Extensions.Configuration;
namespace MongoMission.Tests
{
	public class UnitTest1
	{
		public UnitTest1() {
			var configuration = new Mock<IConfiguration>();
			var configSection = new Mock<IConfigurationSection>();

			configSection.Setup(x => x.Value).Returns("fake value");
			configuration.Setup(x => x.GetSection("MySection")).Returns(configSection.Object);
			//OR
			configuration.Setup(x => x.GetSection("MySection:Value")).Returns(configSection.Object);
		}
		[Fact]
		public void Test1()
		{

		}
	}
	public class StringTests1
	{
		[Theory,
		InlineData("goodnight moon", "moon", true),
		InlineData("hello world", "hi", false)]
		public void Contains(string input, string sub, bool expected)
		{
			var actual = input.Contains(sub);
			Assert.Equal(expected, actual);
		}
	}
	public class StringTests2
	{
		//[Theory, PropertyData("SplitCountData")]
		[Theory, MemberData("SplitCountData")]
		public void SplitCount(string input, int expectedCount)
		{
			var actualCount = input.Split(' ').Count();
			Assert.Equal(expectedCount, actualCount);
		}

		public static IEnumerable<object[]> SplitCountData
		{
			get
			{
				// Or this could read from a file. :)
				return new[]
				{
				new object[] { "xUnit", 1 },
				new object[] { "is fun", 2 },
				new object[] { "to test with", 3 }
			};
			}
		}
	}
	public class StringTests3
	{
		[Theory, ClassData(typeof(IndexOfData))]
		public void IndexOf(string input, char letter, int expected)
		{
			var actual = input.IndexOf(letter);
			Assert.Equal(expected, actual);
		}
	}

	public class IndexOfData : IEnumerable<object[]>
	{
		private readonly List<object[]> _data = new List<object[]>
	{
		new object[] { "hello world", 'w', 6 },
		new object[] { "goodnight moon", 'w', -1 }
	};

		public IEnumerator<object[]> GetEnumerator()
		{ return _data.GetEnumerator(); }

		IEnumerator IEnumerable.GetEnumerator()
		{ return GetEnumerator(); }
	}
}

namespace MongoMission.Tests.Demo
{
	//http://stackoverflow.com/questions/22093843
	public interface ITheoryDatum
	{
		object[] ToParameterArray();
	}

	public abstract class TheoryDatum : ITheoryDatum
	{
		public abstract object[] ToParameterArray();

		public static ITheoryDatum Factory<TSystemUnderTest, TExpectedOutput>(TSystemUnderTest sut, TExpectedOutput expectedOutput, string description)
		{
			var datum = new TheoryDatum<TSystemUnderTest, TExpectedOutput>();
			datum.SystemUnderTest = sut;
			datum.Description = description;
			datum.ExpectedOutput = expectedOutput;
			return datum;
		}
	}

	public class TheoryDatum<TSystemUnderTest, TExpectedOutput> : TheoryDatum
	{
		public TSystemUnderTest SystemUnderTest { get; set; }

		public string Description { get; set; }

		public TExpectedOutput ExpectedOutput { get; set; }

		public override object[] ToParameterArray()
		{
			var output = new object[3];
			output[0] = SystemUnderTest;
			output[1] = ExpectedOutput;
			output[2] = Description;
			return output;
		}

	}

	public class IngredientTests //: TestCase
	{

		[Theory]
		[MemberData(nameof(IsValidData))]
		public void IsValid(Ingredient ingredient, bool expectedResult, string testDescription)
		{
			Assert.True(ingredient.IsValid == expectedResult, testDescription);
		}

		public static IEnumerable<object[]> IsValidData
		{
			get
			{
				var food = new Food();
				var quantity = new Quantity();
				var data = new List<ITheoryDatum>();

				data.Add(TheoryDatum.Factory(new Ingredient { Food = food }, false, "Quantity missing"));
				data.Add(TheoryDatum.Factory(new Ingredient { Quantity = quantity }, false, "Food missing"));
				data.Add(TheoryDatum.Factory(new Ingredient { Quantity = quantity, Food = food }, true, "Valid"));

				return data.ConvertAll(d => d.ToParameterArray());
			}
		}

		public class Ingredient
		{
			public bool IsValid { get;  set; }
			public Food Food { get;  set; }
			public Quantity Quantity { get;  set; }
		}

		public class Food
		{
			public Food()
			{
			}
		}

		public class Quantity
		{
			public Quantity()
			{
			}
		}
	}

	public class TestClass
	{
		public class DeviceTelemetryTestData : IEnumerable<object[]>
		{
			public IEnumerator<object[]> GetEnumerator()
			{
				yield return new object[] { new DeviceTelemetry { DeviceId = "asd" }, new DeviceTelemetry { DeviceId = "qwe" } };
				yield return new object[] { new DeviceTelemetry { DeviceId = "asd" }, new DeviceTelemetry { DeviceId = "qwe" } };
				yield return new object[] { new DeviceTelemetry { DeviceId = "asd" }, new DeviceTelemetry { DeviceId = "qwe" } };
				yield return new object[] { new DeviceTelemetry { DeviceId = "asd" }, new DeviceTelemetry { DeviceId = "qwe" } };
			}

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

			
		}
		private class DeviceTelemetry
		{
			public string DeviceId { get; set; }
		}

		bool isSaturday(DateTime dt)
		{
			string day = dt.DayOfWeek.ToString();
			return (day == "Saturday");
		}

		[Theory]
		[MemberData("IsSaturdayIndex", MemberType = typeof(TestCase))]
		public void test(int i)
		{
			// parse test case
			var input = TestCase.IsSaturdayTestCase[i];
			DateTime dt = (DateTime)input[0];
			bool expected = (bool)input[1];

			// test
			bool result = isSaturday(dt);
			result.Should().Be(expected);
		}
		public class TestCase
		{
			public static readonly List<object[]> IsSaturdayTestCase = new List<object[]>
		   {
			  new object[]{new DateTime(2016,1,23),true},
			  new object[]{new DateTime(2016,1,24),false}
		   };

			public static IEnumerable<object[]> IsSaturdayIndex
			{
				get
				{
					List<object[]> tmp = new List<object[]>();
					for (int i = 0; i < IsSaturdayTestCase.Count; i++)
						tmp.Add(new object[] { i });
					return tmp;
				}
			}
		}
	}


}