using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace CodeSnippet.ConsoleApp.DesignPatterns.PrototypPatterns
{
    public abstract class Shape : ICloneable
    {
        private string id;
        protected string type;

        public abstract void draw();

        public string getType()
        {
            return type;
        }

        public string getId()
        {
            return id;
        }

        public void setId(string id)
        {
            this.id = id;
        }

        public object Clone()
        {
            object clone = null;

            try
            {
                clone = MemberwiseClone();// this.Clone();

            }
            catch (Exception e)
            {

            }

            return clone;
        }
    }
    public class Rectangle : Shape
    {

       public Rectangle()
        {
            type = "Rectangle";
        }

       public override void draw()
        {
            Console.WriteLine("Inside Rectangle::draw() method.");
        }
    }
    public class Square : Shape
    {

       public Square()
        {
            type = "Square";
        }

       public override void draw()
        {
            Console.WriteLine("Inside Square::draw() method.");
        }
    }
    public class Circle : Shape
    {

       public Circle()
        {
            type = "Circle";
        }

       public override void draw()
        {
            Console.WriteLine  ("Inside Circle::draw() method.");
        }
    }
    public class ShapeCache
    {
        
        private static Dictionary<String, Shape> shapeMap = new Dictionary<String, Shape>();

        public static Shape getShape(String shapeId)
        {
            Shape cachedShape = shapeMap[shapeId];
            return (Shape)cachedShape?.Clone();
        }

        // for each shape run database query and create shape
        // shapeMap.put(shapeKey, shape);
        // for example, we are adding three shapes

        public static void loadCache()
        {
            Circle circle = new Circle();
            circle.setId("1");
            shapeMap.Add(circle.getId(), circle);

            Square square = new Square();
            square.setId("2");
            shapeMap.Add(square.getId(), square);

            Rectangle rectangle = new Rectangle();
            rectangle.setId("3");
            shapeMap.Add(rectangle.getId(), rectangle);
        }

        public static int GetShapeMapLength()
        {
            return shapeMap.Count;
        }
    }
    //just for reference
    //public class PrototypePatternDemo
    //{
    //    public static void main(String[] args)
    //    {
    //        ShapeCache.loadCache();

    //        Shape clonedShape = (Shape)ShapeCache.getShape("1");
    //        Console.WriteLine("Shape : " + clonedShape.getType());

    //        Shape clonedShape2 = (Shape)ShapeCache.getShape("2");
    //        Console.WriteLine("Shape : " + clonedShape2.getType());

    //        Shape clonedShape3 = (Shape)ShapeCache.getShape("3");
    //        Console.WriteLine("Shape : " + clonedShape3.getType());
    //    }
    //}
}
