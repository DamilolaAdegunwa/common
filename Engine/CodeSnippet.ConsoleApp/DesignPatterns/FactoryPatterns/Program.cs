using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CodeSnippet.ConsoleApp.DesignPatterns.FactoryPatterns
{
    public class Program
    {
        public Program()
        {

        }

        //public static void Main()
        //{
        //    var shapeFactory = new ShapeFactory();

        //    shapeFactory.GetShape(ShapeType.Cirle).Draw();
        //    shapeFactory.GetShape(ShapeType.Square).Draw();
        //    shapeFactory.GetShape(ShapeType.Rectangle).Draw();
        //}
        public static void Main()
        {
            var laptopFactory = new LaptopFactory();

            laptopFactory.GetLaptop(LaptopType.Acer).StartUp();
        }
    }
}
