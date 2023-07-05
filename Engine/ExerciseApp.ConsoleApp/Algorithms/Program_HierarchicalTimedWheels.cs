using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseApp.ConsoleApp.Algorithms
{

	public class HierarchicalTimer
	{
		private const int WheelSize = 60;
		private const int NumWheels = 4;
		private const int MaxTimeout = WheelSize * WheelSize * NumWheels;

		private List<LinkedList<TimerTask>> wheels;
		private LinkedList<TimerTask> overflowWheel;
		private int currentTime;

		public HierarchicalTimer()
		{
			wheels = new List<LinkedList<TimerTask>>();
			for (int i = 0; i < NumWheels; i++)
			{
				wheels.Add(new LinkedList<TimerTask>());
			}
			overflowWheel = new LinkedList<TimerTask>();
			currentTime = 0;
		}

		public void Schedule(Action action, int timeout)
		{
			if (timeout > MaxTimeout || timeout < 0)
			{
				throw new ArgumentException("Invalid timeout value");
			}

			int expirationTime = (currentTime + timeout) % MaxTimeout;

			TimerTask task = new TimerTask(action, expirationTime);

			// Determine the target wheel based on the expiration time
			int targetWheelIndex = (currentTime / WheelSize) % NumWheels;
			LinkedList<TimerTask> targetWheel = wheels[targetWheelIndex];

			if (expirationTime >= currentTime && expirationTime < currentTime + WheelSize)
			{
				// If the expiration time is within the current wheel, add the task directly
				targetWheel.AddLast(task);
			}
			else
			{
				// Otherwise, add the task to the overflow wheel
				overflowWheel.AddLast(task);
			}
		}

		public void Tick()
		{
			currentTime = (currentTime + 1) % MaxTimeout;

			// Process tasks in the current wheel
			int currentWheelIndex = currentTime % WheelSize;
			LinkedList<TimerTask> currentWheel = wheels[currentWheelIndex];
			ProcessTasks(currentWheel);
			currentWheel.Clear();

			// Check if the current wheel completed a full revolution
			if (currentWheelIndex == 0)
			{
				// Move tasks from the overflow wheel to the appropriate wheel
				ProcessTasks(overflowWheel);
			}
		}

		private void ProcessTasks(LinkedList<TimerTask> taskList)
		{
			LinkedListNode<TimerTask> node = taskList.First;
			while (node != null)
			{
				TimerTask task = node.Value;
				if (task.ExpirationTime <= currentTime)
				{
					// Execute the task if its expiration time has passed
					task.Action.Invoke();
					LinkedListNode<TimerTask> nextNode = node.Next;
					taskList.Remove(node);
					node = nextNode;
				}
				else
				{
					// Move the task to the next wheel
					int targetWheelIndex = (task.ExpirationTime / WheelSize) % NumWheels;
					LinkedList<TimerTask> targetWheel = wheels[targetWheelIndex];
					LinkedListNode<TimerTask> nextNode = node.Next;
					taskList.Remove(node);
					targetWheel.AddLast(task);
					node = nextNode;
				}
			}
		}
	}

	public class TimerTask
	{
		public Action Action { get; }
		public int ExpirationTime { get; }

		public TimerTask(Action action, int expirationTime)
		{
			Action = action;
			ExpirationTime = expirationTime;
		}
	}

	public class Program_HierarchicalTimedWheels
	{
		public static void Main_Program_HierarchicalTimedWheels(string[] args)
		{
			HierarchicalTimer timer = new HierarchicalTimer();

			// Schedule tasks with different timeouts
			timer.Schedule(() => Console.WriteLine("Task 1 executed"), 10);
			timer.Schedule(() => Console.WriteLine("Task 2 executed"), 30);
			timer.Schedule(() => Console.WriteLine("Task 3 executed"), 80);

			// Simulate the passage of time
			for (int i = 0; i < 100; i++)
			{
				timer.Tick();
			}
		}
	}

}
