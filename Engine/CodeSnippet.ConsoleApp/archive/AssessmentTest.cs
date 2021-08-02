using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippet.ConsoleApp
{
    //    Create a class named Car that implements the interface IVehicle :
    //- The NumberOfSeats property of the Car class must be equal to 5 .
    //- The MoveTo() method must change the Location propterty of the Car.

    //After 3 minutes have elapsed a progressive points penalty will be applied.
    public interface IVehicle
    {
        string Location { get; }
        int NumberOfSeats { get; }
        void MoveTo(string city);
    }
    //----------DO NOT MODIFY CODE ABOVE THIS ROW, IT WILL ANYWAY BE RESET BEFORE EXECUTION----------

    //----------DO NOT MODIFY CODE BELOW THIS ROW, IT WILL ANYWAY BE RESET BEFORE EXECUTION----------
    ////////////////////////////////////////////
    //Implement the IsAPalindrome() method so that it indicates whether the word parameter contains a palindrome.
    //A palindrome is a word which is identical when read from the left or the right.For example : madam, otto...
    public partial class Question
    {
        public bool IsAPalindrome(string word)
        {
            //----------DO NOT MODIFY CODE ABOVE THIS ROW, IT WILL ANYWAY BE RESET BEFORE EXECUTION----------
            return default;
            //----------DO NOT MODIFY CODE BELOW THIS ROW, IT WILL ANYWAY BE RESET BEFORE EXECUTION----------
        }
    }
    //Amend the constructor for the Child class: Child( string name), so it assigns the provided name value to the Name property declared in the Parent class.
    public class Parent
    {
        public string Name { get; private set; }

        public Parent(string name)
        {
            Name = name;
        }
        public Parent()
        {
        }
    }

    public class Child : Parent
    {
        //----------DO NOT MODIFY CODE ABOVE THIS ROW, IT WILL ANYWAY BE RESET BEFORE EXECUTION----------
        public Child(string name)
        {
        }
        //----------DO NOT MODIFY CODE BELOW THIS ROW, IT WILL ANYWAY BE RESET BEFORE EXECUTION----------
    }
    //    Use regular expressions with the given pattern property to complete the GetOptionDictionary() method.
    //The optionText parameter will contain text formatted in this way:
    //optionName1= value1
    //optionName2= value2
    //For this sample, optionName1 would become the first Dictionary element's key and value1 would become its value, optionName2 would become the second Dictionary element's key, and so on...
    //The regular expression object should be case insensitive.
    public partial class Question
    {
        private string pattern = @"(^|\n)(?<optionName>[a-z0-9- ]+)=(?<value>[^\r]+)";
        public Dictionary<string, string> GetOptionDictionary(string optionText)
        {
            Dictionary<string, string> options = new Dictionary<string, string>();
            //----------DO NOT MODIFY CODE ABOVE THIS ROW, IT WILL ANYWAY BE RESET BEFORE EXECUTION----------

            //----------DO NOT MODIFY CODE BELOW THIS ROW, IT WILL ANYWAY BE RESET BEFORE EXECUTION----------
            return options;
        }
    }
}
