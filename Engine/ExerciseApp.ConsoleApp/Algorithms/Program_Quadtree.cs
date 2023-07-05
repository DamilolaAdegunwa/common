using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

//2
namespace ExerciseApp.ConsoleApp.Algorithms
{

    public class Point
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }
    }

    public class Quadtree
    {
        private const int MAX_CAPACITY = 4; // Maximum number of points in a leaf node
        private readonly int MAX_LEVELS; // Maximum depth of the quadtree
        private QuadtreeNode root; // Root node of the quadtree

        // Quadtree node class
        private class QuadtreeNode
        {
            public int Level { get; set; }
            public List<Point> Points { get; set; }
            public QuadtreeNode[] Children { get; set; }
            public Rectangle Bounds { get; set; }

            public QuadtreeNode(int level, Rectangle bounds)
            {
                Level = level;
                Points = new List<Point>();
                Children = new QuadtreeNode[4];
                Bounds = bounds;
            }
        }

        // Rectangle class representing the boundaries of a quadtree node
        public class Rectangle
        {
            public float X { get; set; }
            public float Y { get; set; }
            public float Width { get; set; }
            public float Height { get; set; }

            public Rectangle(float x, float y, float width, float height)
            {
                X = x;
                Y = y;
                Width = width;
                Height = height;
            }

            public bool Contains(Point point)
            {
                return point.X >= X && point.X <= X + Width && point.Y >= Y && point.Y <= Y + Height;
            }

            public bool Intersects(Rectangle other)
            {
                return X < other.X + other.Width && X + Width > other.X && Y < other.Y + other.Height && Y + Height > other.Y;
            }
        }

        public Quadtree(float x, float y, float width, float height, int maxLevels)
        {
            MAX_LEVELS = maxLevels;
            root = new QuadtreeNode(0, new Rectangle(x, y, width, height));
        }

        // Insert a point into the quadtree
        public void Insert(Point point)
        {
            InsertPoint(root, point);
        }

        // Helper method to recursively insert a point into a quadtree node
        private void InsertPoint(QuadtreeNode node, Point point)
        {
            // If the node has children, try inserting the point into them
            if (node.Children[0] != null)
            {
                int index = GetChildIndex(node.Bounds, point);
                if (index != -1)
                {
                    InsertPoint(node.Children[index], point);
                    return;
                }
            }

            // Add the point to the current node
            node.Points.Add(point);

            // Split the node if it has reached maximum capacity and maximum level has not been reached
            if (node.Points.Count > MAX_CAPACITY && node.Level < MAX_LEVELS)
            {
                if (node.Children[0] == null)
                {
                    SplitNode(node);
                }

                // Reinsert the points into the child nodes
                for (int i = 0; i < node.Points.Count; i++)
                {
                    int index = GetChildIndex(node.Bounds, node.Points[i]);
                    if (index != -1)
                    {
                        InsertPoint(node.Children[index], node.Points[i]);
                        node.Points.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        // Helper method to split a quadtree node into four child nodes
        private void SplitNode(QuadtreeNode node)
        {
            float subWidth = node.Bounds.Width / 2f;
            float subHeight = node.Bounds.Height / 2f;
            float x = node.Bounds.X;
            float y = node.Bounds.Y;

            node.Children[0] = new QuadtreeNode(node.Level + 1, new Rectangle(x + subWidth, y, subWidth, subHeight));
            node.Children[1] = new QuadtreeNode(node.Level + 1, new Rectangle(x, y, subWidth, subHeight));
            node.Children[2] = new QuadtreeNode(node.Level + 1, new Rectangle(x, y + subHeight, subWidth, subHeight));
            node.Children[3] = new QuadtreeNode(node.Level + 1, new Rectangle(x + subWidth, y + subHeight, subWidth, subHeight));
        }

        // Retrieve all points within a given range
        public List<Point> QueryRange(Rectangle range)
        {
            List<Point> pointsInRange = new List<Point>();
            QueryRange(root, range, pointsInRange);
            return pointsInRange;
        }

        // Helper method to recursively find points within a range in a quadtree node
        private void QueryRange(QuadtreeNode node, Rectangle range, List<Point> pointsInRange)
        {
            if (node == null)
                return;

            // Check if the node's bounds intersect with the query range
            if (!node.Bounds.Intersects(range))
                return;

            foreach (Point point in node.Points)
            {
                if (range.Contains(point))
                {
                    pointsInRange.Add(point);
                }
            }

            // Recursively check the child nodes
            foreach (QuadtreeNode child in node.Children)
            {
                QueryRange(child, range, pointsInRange);
            }
        }

        // Helper method to determine the index of the child node that contains a given point
        private int GetChildIndex(Rectangle bounds, Point point)
        {
            int index = -1;
            float midX = bounds.X + bounds.Width / 2f;
            float midY = bounds.Y + bounds.Height / 2f;

            // Determine the quadrant based on the point's position
            bool top = point.Y < midY;
            bool bottom = point.Y >= midY;
            bool left = point.X < midX;
            bool right = point.X >= midX;

            if (top && left)
                index = 1;
            else if (top && right)
                index = 0;
            else if (bottom && left)
                index = 2;
            else if (bottom && right)
                index = 3;

            return index;
        }
    }

    public class Program_Quadtree
    {
        public static void Main_Quadtree(string[] args)
        {
            // Create a quadtree with a range of (0, 0) to (100, 100) and a maximum depth of 4
            Quadtree quadtree = new Quadtree(0, 0, 100, 100, 4);

            // Insert some points into the quadtree
            quadtree.Insert(new Point(10, 10));
            quadtree.Insert(new Point(20, 20));
            quadtree.Insert(new Point(30, 30));
            quadtree.Insert(new Point(40, 40));
            quadtree.Insert(new Point(50, 50));
            quadtree.Insert(new Point(60, 60));
            quadtree.Insert(new Point(70, 70));
            quadtree.Insert(new Point(80, 80));
            quadtree.Insert(new Point(90, 90));

            // Query the quadtree for points within a range
            Quadtree.Rectangle range = new Quadtree.Rectangle(25, 25, 50, 50);
            List<Point> pointsInRange = quadtree.QueryRange(range);

            // Print the points within the range
            Console.WriteLine("Points within range:");
            foreach (Point point in pointsInRange)
            {
                Console.WriteLine($"({point.X}, {point.Y})");

            }
            Console.ReadKey();
        }
    }

}
