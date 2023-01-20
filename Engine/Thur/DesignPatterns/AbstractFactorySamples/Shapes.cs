namespace Thur.DesignPatterns.AbstractFactorySamples
{
    public class ShapeProducer {
        public ShapeFactory GetShapeFactory(ShapeType shapeType) {
            switch (shapeType) {
                case ShapeType.Rectangle:
                    return new RectangleFactory();
                    
                case ShapeType.Square: 
                    return new SquareFactory();

                case ShapeType.Circle:
                    return new CircleFactory();

                case ShapeType.Triangle:
                    return new TriangleFactory();
            }
            return null;
        }
    }
    public abstract class ShapeFactory { 
        public abstract Shape CreateShape();
    }

    #region implementations of shape factory
    public class RectangleFactory : ShapeFactory
    {
        public override Rectangle CreateShape()
        {
            return new Rectangle();
        }
    }
    public class SquareFactory : ShapeFactory
    {
        public override Square CreateShape()
        {
            return new Square();
        }
    }
    public class CircleFactory : ShapeFactory
    {
        public override Circle CreateShape()
        {
            return new Circle();
        }
    }
    public class TriangleFactory : ShapeFactory
    {
        public override Triangle CreateShape()
        {
            return new Triangle();
        }
    }  
    #endregion

    public interface Shape
    {
        void Draw();
    }

    #region implementations of shape
    public class Rectangle : Shape
    {
        public void Draw()
        {
            //throw new System.NotImplementedException();
        }
    }
    public class Square : Shape
    {
        public void Draw()
        {
            //throw new System.NotImplementedException();
        }
    }
    public class Circle : Shape
    {
        public void Draw()
        {
            //throw new System.NotImplementedException();
        }
    }
    public class Triangle : Shape
    {
        public void Draw()
        {
            //throw new System.NotImplementedException();
        }
    }
    //public class RectangleFactory : ShapeFactory    
    #endregion

    public enum ShapeType
    {
        Rectangle = 0,
        Square = 1,
        Circle = 2,
        Triangle = 3,
    }
}