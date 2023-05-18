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
	public class TemperatureChangedEventArgs : EventArgs
	{
		public double NewTemperature { get; }

		public TemperatureChangedEventArgs(double newTemperature)
		{
			NewTemperature = newTemperature;
		}
	}

	public class Thermostat
	{
		private double currentTemperature;

		public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;

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

		protected virtual void OnTemperatureChanged(double oldTemperature, double newTemperature)
		{
			TemperatureChanged?.Invoke(this, new TemperatureChangedEventArgs(newTemperature));
		}
	}

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
			Heater heater = new Heater();
			AirConditioner airConditioner = new AirConditioner();

			heater.Subscribe(thermostat);
			airConditioner.Subscribe(thermostat);

			thermostat.CurrentTemperature = 18; // Heater will respond
			thermostat.CurrentTemperature = 30; // Air Conditioner will respond

			heater.Unsubscribe(thermostat);
			thermostat.CurrentTemperature = 15; // Heater will not respond anymore

			Console.ReadLine();
		}
	}

}
