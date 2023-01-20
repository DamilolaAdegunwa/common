using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippet.ConsoleApp.DesignPatterns.BuilderPatterns
{
    public interface Packing
    {

    }

    public interface FoodItem
    {
        string Name();
        Packing Packing();
        float Price();
    }
    public class Wrapper : Packing
    {

    }
    public class Bottle : Packing
    {

    }
    public abstract class Burger : FoodItem
    {
        public abstract string Name();

        public Packing Packing()
        {
            return new Wrapper();
        }

        public abstract float Price();
    }
    public abstract class ColdDrink : FoodItem
    {
        public abstract string Name();

        public Packing Packing()
        {
            return new Bottle();
        }

        public abstract float Price();
    }
    public class VegBurger : Burger
    {
        public override string Name()
        {
            return "Vegetable Burger";
        }

        public override float Price()
        {
            return 2.5f;
        }
    }
    public class NonVegBurger : Burger
    {
        public override string Name()
        {
            return "Vegetable Burger";
        }

        public override float Price()
        {
            return 3.5f;
        }
    }
    public class Pepsi : ColdDrink
    {
        public override string Name()
        {
            return "Pepsi";
        }

        public override float Price()
        {
            return 0.5f;
        }
    }
    public class Coke : ColdDrink
    {
        public override string Name()
        {
            return "Coca Cola";
        }

        public override float Price()
        {
            return 1.5f;
        }
    }
    public class Meal 
    {
        public List<FoodItem> foodItems = new List<FoodItem>();

        public void AddItem(FoodItem foodItem)
        {
            foodItems.Add(foodItem);
        }

        public float GetCost()
        {
            return foodItems.Sum(x => x.Price());
        }
        public void ShowItems()
        {
            Console.WriteLine($"--------Food Item-----------");
            foreach(var f in foodItems)
            {
                Console.WriteLine($"food={f.Name()}, price= {f.Price()}, packing type= {f.Packing().GetType().Name}");
            }
            Console.WriteLine("--end--");

        }
    }
    public class MealBuilder
    {
        public Meal PrepareMeal()
        {
            //use default
            Meal meal = new Meal();
            meal.AddItem(new NonVegBurger());
            meal.AddItem(new Coke());
            return meal;
        }
        public Meal PrepareMeal(Burger burger, ColdDrink drink)
        {
            Meal meal = new Meal();
            meal.AddItem(burger);
            meal.AddItem(drink);
            return meal;
        }
    }
}
