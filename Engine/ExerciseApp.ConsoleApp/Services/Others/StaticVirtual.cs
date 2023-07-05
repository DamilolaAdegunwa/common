using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
namespace ConvertApp.ConsoleApp.Services.Others
{
    public class StaticVirtual
    {
		private readonly ObjectPool<StringBuilder> _stringBuilderPool =
	new DefaultObjectPoolProvider().CreateStringBuilderPool();
		//public void Clone() { }
		//public static double MidPoint(double left, double right) => (left + right) / (2.0);
		public static T MidPoint<T>(T left, T right) where T : INumber<T> => (left + right) / T.CreateChecked(2);  
        // note: the addition of left and right may overflow here; it's just for demonstration purposes
    }

    /// <summary>
    /// IIncrement: use this for entities. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGetNext<T> where T : IGetNext<T>
    {
        static abstract T operator ++(T other);
    }
    public unsafe partial record struct RepeatSequence : IGetNext<RepeatSequence>
    {
        private const char Ch = 'A';
        public string Text = new string(Ch, 1);

        public RepeatSequence() { }

        public static RepeatSequence operator ++(RepeatSequence other)
            => other with { Text = other.Text + Ch };

        public override string ToString() => Text;
    }
    // Note: Not complete. This won't compile yet.
    public record Translation<T>(T XOffset, T YOffset) : IAdditiveIdentity<Translation<T>, Translation<T>> where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>
    {
        public static Translation<T> AdditiveIdentity =>
            new Translation<T>(XOffset: T.AdditiveIdentity, YOffset: T.AdditiveIdentity);
    }

    public record Point<T>(T X, T Y) : IAdditionOperators<Point<T>, Translation<T>, Point<T>>
    where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>
    {
        public static Point<T> operator +(Point<T> left, Translation<T> right) =>
            left with { X = left.X + right.XOffset, Y = left.Y + right.YOffset };
    }

    public class Program_StaticVirtual
    {
        public static void Main_StaticVirtual()
        {
            RepeatSequence r = new RepeatSequence();
            r++; //update, add to list, search for all up to date, fetch everything, fetch one more
            var pt = new Point<int>(3, 4);
            var translate = new Translation<int>(5, 10);
            var final = pt + translate;
            Console.WriteLine(pt);
            Console.WriteLine(translate);
            Console.WriteLine(final);
        }
    }
}