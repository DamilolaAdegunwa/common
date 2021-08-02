using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippet.ConsoleApp
{
    public class PatternMatchingTest
    {
        public static double ComputeArea_Version4(object shape)
        {
            switch (shape)
            {
                case Square s when s.Side == 0:
                case Circle c when c.Radius == 0:
                case Triangle t when t.Base == 0 || t.Height == 0:
                case Rectangle r when r.Length == 0 || r.Breadth == 0:
                    return 0;
                case Square s:
                    return s.Side * s.Side;
                case Circle c:
                    return c.Radius * c.Radius * Math.PI;
                case Triangle t:
                    return t.Base * t.Height / 2;
                case Rectangle r:
                    return r.Length * r.Breadth;
                default:
                    throw new ArgumentException(
                    message: "shape is not a recognized shape",
                    paramName: nameof(shape));
            }
        }
        public static double ComputeArea_Version3(object shape)
        {
            switch (shape)
            {
                case Square s when s.Side == 0 && true:
                case Circle c when c.Radius == 0:
                    return 0;
                case Square s:
                    return s.Side * s.Side;
                case Circle c:
                    return c.Radius * c.Radius * Math.PI;
                default:
                    throw new ArgumentException(
                    message: "shape is not a recognized shape",
                    paramName: nameof(shape));
            }
        }
        public static double ComputeAreaModernSwitch(object shape)
        {
            switch (shape)
            {
                case Square s:
                    return s.Side * s.Side;
                case Circle c:
                    return c.Radius * c.Radius * Math.PI;
                case Rectangle r:
                    return r.Breadth * r.Length;
                default:
                    throw new ArgumentException(
                    message: "shape is not a recognized shape",
                    paramName: nameof(shape));
            }
        }
        public static string GenerateMessage(params string[] parts)
        {
            switch (parts.Length)
            {
                case 0:
                    return "No elements to the input";
                case 1:
                    return $"One element: {parts[0]}";
                case 2:
                    return $"Two elements: {parts[0]}, {parts[1]}";
                default:
                    return $"Many elements. Too many to write";
            }
        }
        public static double ComputeAreaModernIs(object shape)
        {
            if (shape is Square s)
                return s.Side * s.Side;
            else if (shape is Circle c)
                return c.Radius * c.Radius * Math.PI;
                
            else if (shape is Rectangle r)
                return r.Breadth * r.Length;
            // elided
            throw new ArgumentException(
            message: "shape is not a recognized shape",
            paramName: nameof(shape));
        }
        public double ComputeArea(object shape)
        {
            double area;
            if (shape is Square)
            {
                Square square = (Square)shape;
                area = square.Side * square.Side;
                return area;
            }
            else if(shape is Circle)
            {
                Circle circle = (Circle)shape;
                area = Math.PI * circle.Radius * circle.Radius;
                return area;
            }
            else if(shape is Rectangle)
            {
                Rectangle rectangle = (Rectangle)shape;
                area = rectangle.Length * rectangle.Breadth;
                return area;
            }
            else if(shape is Triangle)
            {
                Triangle triangle = (Triangle)shape;
                area = 0.5 * triangle.Base * triangle.Height;
            }
            throw new ArgumentException(message: "unknown shape!", paramName: nameof(shape));
        }
    }
    #region shapes class
    public class Square
    {
        public double Side { get; }
        public Square(double side)
        {
            Side = side;
        }
    }
    public class Circle
    {
        public double Radius { get; }
        public Circle(double radius)
        {
            Radius = radius;
        }
    }
    public class Rectangle
    {
        public double Length { get; }
        public double Breadth { get; }
        public Rectangle(double length, double breadth)
        {
            Length = length;
            Breadth = breadth;
        }
    }
    public class Triangle
    {
        public double Base { get; }
        public double Height { get; }
        public Triangle(double @base, double height)
        {
            Base = @base;
            Height = height;
        }
    }
    #endregion
}
