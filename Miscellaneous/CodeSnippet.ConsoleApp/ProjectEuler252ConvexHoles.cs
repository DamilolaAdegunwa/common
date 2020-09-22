using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace CodeSnippet.ConsoleApp
{
    public class ProjectEuler252ConvexHoles
    {
        public readonly int S0 = 290797;
        public readonly int M = 50515093;
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        public class ConvexHole
        {
            public Point[] Points { get; set; }
            public decimal Area { get; set; }
        }
        public bool IsValidConvexHole(Point[] Points)
        {
            if (Points.Length < 3)
            {//A valid polygon has to have atleast 3 sides;
                return false;
            }
            if (Points.Length > 3) { }
            return true;
        }
        public List<ConvexHole> GetAllValidConvexHoles(Point[] Points)
        {
            return default;
        }
        public decimal AreaOfBiggestValidConvexHole(List<ConvexHole> convexHoles)
        {
            return default;
        }
        public decimal AreaOfConvexHole(Point[] Points)
        {

            return default;
        }
        public double AreaOfTriangle(Point p1, Point p2, Point p3)
        {
            double a = Distance(p1,p2);
            double b = Distance(p1,p3); 
            double c = Distance(p2,p3); 
            double S = (a +b + c)/2;

            //apply Heron’s formula to find the area of Scalene triangle
            double Area = Math.Sqrt(S * (S - a) * (S - b) * (S - c));
            
            return Area;
        }
        public double Distance(Point p1, Point p2)
        {
            var dy = (p2.Y - p1.Y);
            var dx = (p2.X - p1.X);
            var sumOfTwoSquares = (dx * dx) + (dy * dy);
            var distance = Math.Sqrt(sumOfTwoSquares);
            return distance;
        }
        public List<Point> CreatePoints(int points)
        {
            List<Point> AllPointsOnTheCartesianPlane = new List<Point>();
            int[] SnArr = new int[2*points];
            int[] TnArr = new int[2*points];
            for(int i = 0; i <= (2*points); i++)
            {
                if(i == 0)
                {
                    SnArr[i] = S0;
                    TnArr[i] = 0;
                }
                else
                {
                    SnArr[i] = (SnArr[i - 1] * SnArr[i - 1]) % M;
                    TnArr[i] = (SnArr[i] % 2000) - 1000;
                }
                if(i>= 2 && i%2 == 0)
                {
                    var point = new Point
                    {
                        X = TnArr[i - 1],
                        Y = TnArr[i]
                    };
                    if(AllPointsOnTheCartesianPlane.Where(p => p.X == point.X && p.Y == point.Y).Count() == 0)
                    {
                        AllPointsOnTheCartesianPlane.Add(point);
                    }
                }
            }
            return AllPointsOnTheCartesianPlane;
        }
        /*
         0 < N <= 750
         0 < M <= 100_000_000;
         0 < S0 < M
         */
    }
}
