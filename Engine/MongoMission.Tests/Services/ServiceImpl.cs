using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMission.Tests.Services
{
	internal class ServiceImpl
	{
	}
	public class ExampleViewModel : INotifyPropertyChanged
	{
		private string name;

		public event PropertyChangedEventHandler PropertyChanged;

		public string Name
		{
			get { return name; }
			set
			{
				if (name != value)
				{
					name = value;
					OnPropertyChanged(nameof(Name));
				}
			}
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
