using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System;
using AngleSharp.Dom.Events;

namespace MongoMission.Tests
{
	public class ExampleEventArgs : EventArgs
	{
		public string Message { get; set; }
	}

	public class ExampleClass
	{
		public event EventHandler<ExampleEventArgs> CustomEvent;
		public void DoSomething()
		{
			OnCustomEvent(new ExampleEventArgs { Message = "Event raised!" });
		}
		public async Task DoSomethingAsync()
		{
			OnCustomEvent(new ExampleEventArgs { Message = "Event raised!" });
		}
		protected virtual void OnCustomEvent(ExampleEventArgs e)
		{
			CustomEvent?.Invoke(this, e);
		}
	}

	public class EventTracker<TEvent> where TEvent : ExampleEventArgs//EventArgs
	{
		private readonly Action<ExampleEventArgs> eventAssertAction;
		private bool eventRaised;
		private int count = 0;
		public EventTracker(Action<ExampleEventArgs> eventAssertAction)
		{
			this.eventAssertAction = eventAssertAction;
		}

		public void StartTrackingEvent(object eventSource)
		{
			var eventInfo = eventSource.GetType().GetEvent(typeof(TEvent).Name);
			//var handler = Delegate.CreateDelegate(typeof(TEvent), this, nameof(HandleEvent));
			var handler = Delegate.CreateDelegate(typeof(Action<object, TEvent>), this, nameof(HandleEvent));
			eventInfo.AddEventHandler(eventSource, handler);
		}
		public void StartTrackingEvent(ExampleClass eventSource)
		{
			
			//var eventInfo = eventSource.GetType().GetEvent(typeof(TEvent).Name);
			var eventInfo = eventSource.GetType().GetEvent(typeof(ExampleEventArgs).Name);
			//var handler = Delegate.CreateDelegate(typeof(TEvent), this, nameof(HandleEvent));
			var handler = Delegate.CreateDelegate(typeof(ExampleEventArgs), this, nameof(HandleEvent));
			//var handler = (EventHandler<ExampleEventArgs>) Delegate.CreateDelegate(typeof(Action<object, TEvent>), this, nameof(HandleEvent));
			eventSource.CustomEvent += HandleEvent;
			//eventInfo.AddEventHandler(eventSource, handler);
		}
		private void HandleEvent(object sender, ExampleEventArgs args)
		{
			System.Diagnostics.Debug.WriteLine($"event was raised #{++count}");
			eventRaised = true;
			eventAssertAction?.Invoke(args);
		}

		public void VerifyEventRaised(string eventName)
		{
			Assert.True(eventRaised, $"Expected event '{eventName}' to be raised, but it was not.");
		}
	}

	public class ExampleTests
	{
		[Fact]
		public void TestEventRaised()
		{
			var exampleClass = new ExampleClass();
			var eventTracker = new EventTracker<ExampleEventArgs>(AssertEventMessage);

			eventTracker.StartTrackingEvent(exampleClass);//subscribe i.e added handler
			exampleClass.DoSomething();//invoke - raise event
			exampleClass.DoSomething();
			exampleClass.DoSomething();
			exampleClass.DoSomething();

			eventTracker.VerifyEventRaised(nameof(ExampleClass.CustomEvent));
		}

		private void AssertEventMessage(ExampleEventArgs args)
		{
			Assert.Equal("Event raised!", args.Message);
		}
	}
	//internal class AssertRaisedEvent
	//{
	//}
}
