using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippet.ConsoleApp.DesignPatterns.FactoryPatterns
{
    public interface IShape
    {
        void Draw();
    }
    public class ShapeFactory<T> where T : IShape
    {
        public IShape GetShape(ShapeType shapeType)
        {
            switch (shapeType)
            {
                case ShapeType.Cirle: return new Circle();
                case ShapeType.Square: return new Square();
                case ShapeType.Rectangle: return new Rectangle();
            }
            return null;
        }
    }
    public enum ShapeType
    {
        Cirle = 0,
        Square = 1,
        Rectangle = 2
    }
    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("This is a Circle");
        }
    }
    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("This is a Square");
        }
    }
    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("This is a Rectangle");
        }
    }
}
