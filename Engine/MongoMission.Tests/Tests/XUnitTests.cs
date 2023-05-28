using MongoMission.Tests.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace MongoMission.Tests.Tests
{
    public class XUnitTests
    {
        [Fact]
        public async Task MethodAssertTrue()
        {
            Assert.True(true);
        }
        [Fact]
        public async Task MethodAssertFail()
        {
            Assert.Fail("this is just to test for failure! no further action is required");
        }
        [Fact]
        public async Task MethodAssertEqual()
        {
            Assert.Equal(1, 1);
        }
        [Fact]
        public async Task MethodAssertFalse()
        {
            Assert.False(false);
        }
        [Fact]
        public async Task MethodAssertSingle()
        {
            Assert.Single(new int[] { 10 });
        }
        [Fact]
        public async Task MethodAssertEmpty()
        {
            Assert.Empty(new int[] { });
        }
        [Fact]
        public async Task MethodAssertAll()
        {
            Assert.All(new int[] { 10, 20, 30, 40, 50, 60, 70 }, i => Assert.Equal(i, i));
        }
        [Fact]
        public async Task MethodAssertCollection()
        {
            Assert.Collection(new int[] { 10, 20, 30, 40, 50, 60, 70 }, i => Console.WriteLine(""));
        }
		[Fact]
		public async Task MethodAssertContains()
		{
            Assert.Contains("Java", "JavaScript");
		}
		[Fact]
		public async Task MethodAssertContainsInt()
		{
            Assert.Contains<int>(5, new int[] {1,2,3,4,5,6,7,8,9,10});
		}
		[Fact]
		public async Task MethodAssertDistinctInt()
		{
            Assert.Distinct<int>(new int[] {1,2,3,4,5});
		}
		[Fact]
		public async Task MethodAssertDoesNotContainInt()
		{
            Assert.DoesNotContain<int>(5, new int[] { });
		}
		[Fact]
		public async Task MethodAssertDoesNotContain()
		{
			Assert.DoesNotContain(5, new int[] {1, 2, 3, 4, 5});
			Assert.DoesNotContain("1", "1234567890");
		}
		[Fact]
		public async Task MethodAssertDoesNotMatch()
		{
            Assert.DoesNotMatch(@"0-9a-zA-Z\-_+()", "+ (234) - 813- 136 - 3116");
		}
		[Fact]
		public async Task MethodAssertEndsWith()
		{
            Assert.EndsWith("pet","carpet");
		}
		[Fact]
		public async Task MethodAssertInRange()
		{
			int number = 10;

			Assert.InRange(number, 1, 20);
			// This assertion passes since 10 is between 1 and 20 (inclusive).

			Assert.InRange(number, 1, 5);
			// This assertion fails since 10 is not between 1 and 5 (inclusive).

		}
		[Fact]
		public async Task MethodAssertIsAssignableFrom()
		{
            Assert.IsAssignableFrom(typeof(XUnitTests), this);
		}
		[Fact]
		public async Task MethodAssertIsAssignableFromXUnitTests()
		{
			Assert.IsAssignableFrom<XUnitTests>(this);
		}
		[Fact]
		public async Task MethodAssertIsNotType()
		{
			Assert.IsNotType(typeof(XUnitTests), this);	
		}
		[Fact] public async Task MethodAssertIsType(){ Assert.IsType<XUnitTests>(this); }
		[Fact] public async Task MethodAssertMatches(){ Assert.Matches("0-9", "093425"); }
		[Fact] public async Task MethodAssertMultiple(){ Assert.Multiple(() => Assert.Equal(1, 1), () => Assert.Contains("car", "carpet")); } 
		[Fact] public async Task MethodAssertNotEmpty(){ Assert.NotEmpty(new int[] {1,2,3,4}); } 
		[Fact] public async Task MethodAssertNotEqual(){ Assert.NotEqual(1,2); } 
		[Fact] public async Task MethodAssertNotInRange(){ Assert.NotInRange(0,1,2); } 
		[Fact] public async Task MethodAssertNotNull(){ Assert.NotNull(0); } 
		[Fact] public async Task MethodAssertNotSame(){ Assert.NotSame(this, new int[] {}); } 
		[Fact] public async Task MethodAssertNotStrictEqual(){ Assert.NotStrictEqual(new XUnitTests(), new XUnitTests()); } 
		[Fact] public async Task MethodAssertNull(){ Assert.Null(new XUnitTests()); } 
		[Fact] public async Task MethodAssertProperSubset()
		{
			var setA = new HashSet<int> { 1, 2, 3, 4, 5 };
			var setB = new HashSet<int> { 2, 3, 4 };

			Assert.ProperSubset(setA, setB);
		} 
		[Fact] public async Task MethodAssertProperSuperset()
		{
			var setA = new HashSet<int> { 2, 3, 4 };
			var setB = new HashSet<int> { 1, 2, 3, 4, 5 };
			
			Assert.ProperSuperset(setA, setB); 
		}
		[Fact] public void TestPropertyChangedEvent()
		{
			var viewModel = new ExampleViewModel();
			Action action = () => {
				viewModel.Name = "New Name";
			};
			Assert.PropertyChanged(viewModel, nameof(ExampleViewModel.Name), action);
			// This assertion passes since the PropertyChanged event is raised when Name is changed.
		}
		[Fact]
		public async Task TestPropertyChangedAsyncEvent()
		{
			var viewModel = new ExampleViewModel();
			Task task = Task.Run(() => viewModel.Name = "New Name");
			await Assert.PropertyChangedAsync(viewModel, nameof(ExampleViewModel.Name), () => task);
			// This assertion passes since the PropertyChanged event is raised when Name is changed.
		}
		[Fact]
		public void TestEventRaised()
		{
			var exampleClass = new ExampleClass();

			Assert.Raises<ExampleEventArgs>(
				handler => exampleClass.CustomEvent += handler,
				handler => exampleClass.CustomEvent -= handler,
				() => exampleClass.DoSomething()
			);
		}
		[Fact]
		public void TestEventRaiseAny()
		{
			var exampleClass = new ExampleClass();

			Assert.RaisesAny<ExampleEventArgs>(
				handler => exampleClass.CustomEvent += handler,
				handler => exampleClass.CustomEvent -= handler,
				() => exampleClass.DoSomething()
			);
		}
		[Fact]
		public async Task TestEventRaisedAsync()
		{
			var exampleClass = new ExampleClass();

			var eventArgs = await Assert.RaisesAnyAsync<ExampleEventArgs>(
				handler => exampleClass.CustomEvent += handler,
				handler => exampleClass.CustomEvent -= handler,
				async () => await exampleClass.DoSomethingAsync()
			);

			// Additional assertions on the event arguments can be performed here
			Assert.NotNull(eventArgs);
			Assert.Equal("Event raised!", eventArgs.Arguments.Message);
		}

		[Fact]
		public void TestReferenceEquals()
		{
			var obj1 = new object();
			var obj2 = obj1;
			var obj3 = new object();

			Assert.Same(obj1, obj2); // Asserts that obj1 and obj2 reference the same object
			Assert.Same(obj1, obj3); // Asserts that obj1 and obj3 do not reference the same object
		}
		[Fact] public async Task MethodAssertSubset()
		{
			var setA = new HashSet<int> { 1, 2, 3, 4, 5 };
			var setB = new HashSet<int> { 2, 3, 4 };

			Assert.Subset(setA, setB);
		}
		[Fact]
		public async Task MethodAssertSuperset()
		{
			var setA = new HashSet<int> { 2, 3, 4 };
			var setB = new HashSet<int> { 1, 2, 3, 4, 5 };

			Assert.Superset(setA, setB);
		}
		[Fact]
		public void TestExceptionThrown()
		{
			var exampleInstance = new ExampleClass();

			Assert.Throws<InvalidOperationException>(() => exampleInstance.DoSomething());
		}
		//[Fact] public async Task MethodAssert(){ Assert.Null(new XUnitTests()); } 
	}
}
