using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
namespace RetryApp.Services
{
	public class MyAsyncClass
	{
		public static MyAsyncClass Create()
		{
			return new MyAsyncClass();
		}

		public MyAsyncMethodBuilder GetAsyncMethodBuilder()
		{
			return MyAsyncMethodBuilder.Create();
		}

		public async Task<int> MyAsyncMethod()
		{
			await Task.Delay(1000);
			return 42;
		}
	}

	public class MyAsyncMethodBuilder
	{
		private int result;

		public static MyAsyncMethodBuilder Create()
		{
			return new MyAsyncMethodBuilder();
		}

		public void Start<TStateMachine>(ref TStateMachine stateMachine)
			where TStateMachine : IAsyncStateMachine
		{
			stateMachine.MoveNext();
		}

		public void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		public void SetResult(int result)
		{
			this.result = result;
		}

		public void SetException(Exception exception)
		{
		}

		public Task<int> MyTask
		{
			get { return Task.FromResult(result); }
		}
	}

	public class MyAsyncProgram
	{
		public static void Main_MyAsyncProgram()
		{
			MyAsyncClass myAsyncObject = MyAsyncClass.Create();
			MyAsyncMethodBuilder builder = myAsyncObject.GetAsyncMethodBuilder();

			var stateMachine = new MyAsyncStateMachine();
			stateMachine.builder = builder;

			builder.Start(ref stateMachine);

			var result = stateMachine.builder.MyTask.GetAwaiter().GetResult();
			Console.WriteLine("Result: " + result);
		}
	}

	public class MyAsyncStateMachine : IAsyncStateMachine
	{
		public MyAsyncMethodBuilder builder;

		public void MoveNext()
		{
			builder.SetResult(42);
		}

		public void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}
	}

	//internal class MyAsyncClass
	//{
	//}
	/*
	 In this example, we have a custom MyAsyncClass that represents an asynchronous class. It has a method MyAsyncMethod that simulates an asynchronous operation by awaiting Task.Delay and returning the value 42.

The key part is the usage of MyAsyncMethodBuilder. We define a custom MyAsyncMethodBuilder class that implements the necessary methods required by AsyncMethodBuilder. In the MyAsyncMethod, we retrieve an instance of MyAsyncMethodBuilder through the GetAsyncMethodBuilder method of MyAsyncClass.

We then create a custom state machine MyAsyncStateMachine that implements IAsyncStateMachine. In the MoveNext method of the state machine, we call builder.SetResult(42) to set the result of the asynchronous operation.

Finally, in the Main method, we demonstrate how to use the custom MyAsyncMethodBuilder. We create an instance of MyAsyncClass, obtain the MyAsyncMethodBuilder, create an instance of MyAsyncStateMachine, assign the builder to the state machine, and start the state machine by calling builder.Start(ref stateMachine).

Afterwards, we can retrieve the result of the asynchronous operation by accessing builder.Task.GetAwaiter().GetResult() and print it to the console.

Please note that this is a simplified example for illustrative purposes, and the usage of AsyncMethodBuilder can be more complex in real-world scenarios.
	 */
}
