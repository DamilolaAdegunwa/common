using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippet.ConsoleApp.XMLComments
{
    /*
    The main Math class
    Contains all methods for performing basic math functions
    */
    /// <summary>
    /// The main <c>Math</c> class.
    /// Contains all methods for performing basic math functions.
    /// <list type="bullet">
    /// <item>
    /// <term>Add</term>
    /// <description>Addition Operation</description>
    /// </item>
    /// <item>
    /// <term>Subtract</term>
    /// <description>Subtraction Operation</description>
    /// </item>
    /// <item>
    /// <term>Multiply</term>
    /// <description>Multiplication Operation</description>
    /// </item>
    /// <item>
    /// <term>Divide</term>
    /// <description>Division Operation</description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// This class can add, subtract, multiply and divide.
    /// </remarks>
    public class Math
    {
        // Adds two integers and returns the result
        /// <summary>
        /// Adds two integers and returns the result.
        /// </summary>
        /// <returns>
        /// The sum of two integers.
        /// </returns>
        public static int Add(int a, int b)
        {
            // If any parameter is equal to the max value of an integer
            // and the other is greater than zero
            if ((a == int.MaxValue && b > 0) || (b == int.MaxValue && a > 0))
                throw new System.OverflowException();
            return a + b;
        }
        // Adds two doubles and returns the result
        /// <returns>
        /// The sum of two doubles.
        /// </returns>
        public static double Add(double a, double b)
        {
            if ((a == double.MaxValue && b > 0) || (b == double.MaxValue && a > 0))
                throw new System.OverflowException();
            return a + b;
        }
        // Subtracts an integer from another and returns the result
        /// <returns>
        /// The difference of two integers.
        /// </returns>
        public static int Subtract(int a, int b)
        {
            return a - b;
        }
        // Subtracts a double from another and returns the result
        /// <returns>
        /// The difference of two integers.
        /// </returns>
        public static double Subtract(double a, double b)
        {
            return a - b;
        }
        // Multiplies two integers and returns the result
        public static int Multiply(int a, int b)
        {
            return a * b;
        }
        // Multiplies two doubles and returns the result
        public static double Multiply(double a, double b)
        {
            return a * b;
        }
        // Divides an integer by another and returns the result
        public static int Divide(int a, int b)
        {
            return a / b;
        }
        // Divides a double by another and returns the result
        public static double Divide(double a, double b)
        {
            return a / b;
        }
    }

    public class MathTest
    {
        public void mTest()
        {
            var m = new Math();
        }
    }
}
