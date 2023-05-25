using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertApp.ConsoleApp.Services.Others.Variance
{
    public interface ICovariant<out T>
    {
        T GetItem();
    }
    public class Animal
    {
        public string Name { get; set; }
    }

    public class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("Woof!");
        }
    }

    public class Cat : Animal
    {
        public void Meow()
        {
            Console.WriteLine("Meow!");
        }
    }

    public class CovariantProvider : ICovariant<Animal>
    {
        public Animal GetItem()
        {
            return new Animal { Name = "Generic Animal" };
        }
    }

    public class Covariant
    {
        public static void Main_Cov()
        {
            //ICovariant<Animal> animalProvider = new CovariantProvider();
            //ICovariant<Dog> dogProvider = new CovariantProvider();
            //ICovariant<Cat> catProvider = new CovariantProvider();

            //Animal animal = animalProvider.GetItem();
            //Dog dog = dogProvider.GetItem();
            //Cat cat = catProvider.GetItem();

            //Console.WriteLine(animal.Name); // Output: Generic Animal
            //dog.Bark(); // Output: Woof!
            //cat.Meow(); // Output: Meow!

            //ICovariant<Dog> dogProvider = new CovariantProvider();
            //ICovariant<Animal> animalProvider = dogProvider; // Error: Cannot implicitly convert type

        }

    }
}
