using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertApp.ConsoleApp.Services.Others
{
    #region contra variance
    public interface IContravariant<in T>
    {
        void Process(T item);
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

    public class ContravariantProcessor : IContravariant<Animal>
    {
        public void Process(Animal item)
        {
            Console.WriteLine($"Processing {item.Name}");
        }
    }
    
    public class VarianceCode
    {
        public static void Main_VarianceCode()
        {
            IContravariant<Dog> dogProcessor = new ContravariantProcessor();
            IContravariant<Cat> catProcessor = new ContravariantProcessor();

            var dog = new Dog { Name = "Fido" };
            var cat = new Cat { Name = "Whiskers" };

            dogProcessor.Process(dog); // Output: Processing Fido
            catProcessor.Process(cat); // Output: Processing Whiskers

            IContravariant<Animal> animalProcessor = new ContravariantProcessor();
            IContravariant<Dog> _dogProcessor = animalProcessor; // Error: Cannot implicitly convert type
            //IContravariant<Animal> _animalProcessor = dogProcessor; // Error: Cannot implicitly convert type
            _dogProcessor.Process(dog); // Output: Processing Fido
            animalProcessor.Process(dog); // Output: Processing Fido
            _ = "";
        }
    }
    #endregion

}