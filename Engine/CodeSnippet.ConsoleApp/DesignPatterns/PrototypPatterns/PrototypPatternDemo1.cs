using System;

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
                //clone = this.Clone();

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
}
