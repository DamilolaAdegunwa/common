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
        public static void Main()
        {
            var shapeFactory = new ShapeFactory<IShape>();

            shapeFactory.GetShape(ShapeType.Cirle);
            shapeFactory.GetShape(ShapeType.Square);
            shapeFactory.GetShape(ShapeType.Rectangle);
        }

    }
}
