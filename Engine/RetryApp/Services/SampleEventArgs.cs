using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetryApp.Services
{
	//internal class SampleEventArgs
	//{
	//}
	/// <summary>
	/// First, the event specified by deriving EventArgs
	/// </summary>
	public class TemperatureChangedEventArgs : EventArgs
	{
		public double NewTemperature { get; }

		public TemperatureChangedEventArgs(double newTemperature)
		{
			NewTemperature = newTemperature;
		}
	}

	/// <summary>
	/// a service that includes an event handler
	/// </summary>
	public class Thermostat
	{
		private double currentTemperature;

        //a (am not sure whether it is a better pattern to have an EventHandlerService or to have them in related services)
        public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;

		//b (this could be any property from any class)
		public double CurrentTemperature
		{
			get { return currentTemperature; }
			set
			{
				if (value != currentTemperature)
				{
					double oldTemperature = currentTemperature;
					currentTemperature = value;
					OnTemperatureChanged(oldTemperature, currentTemperature);
				}
			}
		}

		//c (EventInvokerService, EventRaiserService)
		protected virtual void OnTemperatureChanged(double oldTemperature, double newTemperature)
		{
			TemperatureChanged?.Invoke(this, new TemperatureChangedEventArgs(newTemperature));
		}

		//a, b and c dont have to be in the same place (class) 
	}


	/// <summary>
	/// services that depends the event handler (or depends on a service that has the event handler)
	/// </summary>
	public class Heater
	{
		public void Subscribe(Thermostat thermostat)
		{
			thermostat.TemperatureChanged += Thermostat_TemperatureChanged;
		}

		public void Unsubscribe(Thermostat thermostat)
		{
			thermostat.TemperatureChanged -= Thermostat_TemperatureChanged;
		}

		private void Thermostat_TemperatureChanged(object sender, TemperatureChangedEventArgs e)
		{
			double newTemperature = e.NewTemperature;
			if (newTemperature < 20)
			{
				Console.WriteLine($"Heater: Heating the room to {newTemperature} degrees.");
			}
		}
	}

    /// <summary>
    /// services that depends the event handler (or depends on a service that has the event handler)
    /// </summary>
    public class AirConditioner
	{
		public void Subscribe(Thermostat thermostat)
		{
			thermostat.TemperatureChanged += Thermostat_TemperatureChanged;
		}

		public void Unsubscribe(Thermostat thermostat)
		{
			thermostat.TemperatureChanged -= Thermostat_TemperatureChanged;
		}

		private void Thermostat_TemperatureChanged(object sender, TemperatureChangedEventArgs e)
		{
			double newTemperature = e.NewTemperature;
			if (newTemperature > 25)
			{
				Console.WriteLine($"Air Conditioner: Cooling the room to {newTemperature} degrees.");
			}
		}
	}

	public class Program_SampleEventArgs
	{
		public static void Main_SampleEventArgs()
		{
			Thermostat thermostat = new Thermostat();

			//dependencies
			Heater heater = new Heater();
			AirConditioner airConditioner = new AirConditioner();

			//subscribe preferably in the constructor
			heater.Subscribe(thermostat);
			airConditioner.Subscribe(thermostat);

			//within methods
			thermostat.CurrentTemperature = 18; // Heater will respond
			thermostat.CurrentTemperature = 30; // Air Conditioner will respond

			//dispose ()
			heater.Unsubscribe(thermostat);

			//test (control)
			thermostat.CurrentTemperature = 15; // Heater will not respond anymore

			Console.ReadLine();
		}
	}

}
