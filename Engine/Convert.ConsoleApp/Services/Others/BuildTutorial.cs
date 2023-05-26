using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseApp.ConsoleApp.Services.Others
{
	//public class BuildTutorial
	//{
	//}
	public readonly record struct DailyTemperature
		(double HighTemp, double LowTemp)
	{
		public double Mean => (HighTemp + LowTemp) / 2.0;
		//public double HighTemp { get; }
		//public double LowTemp { get; }

		//public DailyTemperature(double highTemp, double lowTemp)
		//{
		//	HighTemp = highTemp;
		//	LowTemp = lowTemp;
		//}
	}
	public class Program_BuildTutorial
	{
		private static DailyTemperature[] data = new DailyTemperature[]
		{
			new DailyTemperature(HighTemp: 57, LowTemp: 30),
			new DailyTemperature(60, 35),
			new DailyTemperature(63, 33),
			new DailyTemperature(68, 29),
			new DailyTemperature(72, 47),
			new DailyTemperature(75, 55),
			new DailyTemperature(77, 55),
			new DailyTemperature(72, 58),
			new DailyTemperature(70, 47),
			new DailyTemperature(77, 59),
			new DailyTemperature(85, 65),
			new DailyTemperature(87, 65),
			new DailyTemperature(85, 72),
			new DailyTemperature(83, 68),
			new DailyTemperature(77, 65),
			new DailyTemperature(72, 58),
			new DailyTemperature(77, 55),
			new DailyTemperature(76, 53),
			new DailyTemperature(80, 60),
			new DailyTemperature(85, 66)
		};

		public static void Main()
		{
			foreach (var item in data)
			{
				Console.WriteLine(item);
			}

		}
	}
	public abstract record DegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords);

	public sealed record HeatingDegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords) : DegreeDays(BaseTemperature, TempRecords)
	{
		public double DegreeDays => TempRecords.Where(s => s.Mean < BaseTemperature).Sum(s => BaseTemperature - s.Mean);
	}

	public sealed record CoolingDegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords) : DegreeDays(BaseTemperature, TempRecords)
	{
		public double DegreeDays => TempRecords.Where(s => s.Mean > BaseTemperature).Sum(s => s.Mean - BaseTemperature);
	}

}
