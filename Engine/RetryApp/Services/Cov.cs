using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RetryApp.Services
{
	public class Animal
	{
		public string Name { get; set; }

		public virtual void MakeSound()
		{
			Console.WriteLine("Animal is making a sound");
		}
	}

	public class Dog : Animal
	{
		public override void MakeSound()
		{
			Console.WriteLine("Dog is barking");
		}
	}

	public interface IAnimal<out T>
	{
		T GetAnimal();
	}

	public class AnimalContainer<T> : IAnimal<T>
	{
		private T animal;

		public AnimalContainer(T animal)
		{
			this.animal = animal;
		}

		public T GetAnimal()
		{
			return animal;
		}
	}
	public class Program_Animal
	{
		public static void Main_Animal()
		{
			IAnimal<Animal> animalContainer = new AnimalContainer<Animal>(new Dog());
			Animal animal = animalContainer.GetAnimal();
			animal.MakeSound();
		}
	}
}