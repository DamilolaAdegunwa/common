using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CodeSnippet.ConsoleApp
{
    public partial class HowTo
    {
        public static void MainHowTo()
        { sample2(); }
        public void Sample1()
        {
            DateTimeFormatInfo dateTimeFormatInfo;
            IFormatProvider formatProvider;
            CultureInfo cultureInfo;
            //NoCurrentDateDefault 

            CultureInfo MyCultureInfo = new CultureInfo("de-DE");
            string MyString = "12 Juni 2008";
            DateTime MyDateTime = DateTime.Parse(MyString, MyCultureInfo);
            Console.WriteLine(MyDateTime);
            // The example displays the following output:
            // 6/12/2008 12:00:00 AM
        }
        public void StringSplit()
        {
            //string[] separatingStrings = { "<<", "..." };
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            string text = "one\ttwo three:four,five six seven";
            System.Console.WriteLine($"Original text: '{text}'");
            string[] words = text.Split(delimiterChars,StringSplitOptions.RemoveEmptyEntries);
            System.Console.WriteLine($"{words.Length} words in text:");
            foreach (var word in words)
            {
                System.Console.WriteLine($"<{word}>");
            }
        }
        public static void sample2()
        {
            string source = "The mountains are still there behind the clouds today.";
            // Use Regex.Replace for more flexibility.
            // Replace "the" or "The" with "many" or "Many".
            // using System.Text.RegularExpressions
            string replaceWith = "many ";
            source = System.Text.RegularExpressions.Regex.Replace(source, "the\\s", LocalReplaceMatchCase,
            System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Console.WriteLine(source);
            string LocalReplaceMatchCase(System.Text.RegularExpressions.Match matchExpression)
            {
                // Test whether the match is capitalized
                if (Char.IsUpper(matchExpression.Value[0]))
                {
                    // Capitalize the replacement string
                    System.Text.StringBuilder replacementBuilder = new System.Text.StringBuilder(replaceWith);
                    replacementBuilder[0] = Char.ToUpper(replacementBuilder[0]);
                    return replacementBuilder.ToString();
                }
                else
                {
                    return replaceWith;
                }
            }
        }
        public static void sample3()
        {
            
            // constructing a string from a char array, prefix it with some additional characters
            char[] chars = { 'a', 'b', 'c', 'd', '\0' };
            int length = chars.Length + 2;
            string result = string.Create(length, chars, (Span<char> strContent, char[] charArray) =>
            {
                strContent[0] = '0';
                strContent[1] = '1';
                for (int i = 0; i < charArray.Length; i++)
                {
                    strContent[i + 2] = charArray[i];
                }
            });
            Console.WriteLine(result);
        }
        public static void sample4()
        {
            string root = @"C:\users";
            string root2 = @"C:\Users";
            bool result = root.Equals(root2, StringComparison.OrdinalIgnoreCase);
            bool areEqual = String.Equals(root, root2, StringComparison.OrdinalIgnoreCase);
            int comparison = String.Compare(root, root2, comparisonType: StringComparison.OrdinalIgnoreCase);
            Console.WriteLine($"Ordinal ignore case: <{root}> and <{root2}> are {(result ? "equal." : "not equal.")}");
            Console.WriteLine($"Ordinal static ignore case: <{root}> and <{root2}> are {(areEqual ? "equal." : "not equal.")}");
            if (comparison < 0)
                Console.WriteLine($"<{root}> is less than <{root2}>");
            else if (comparison > 0)
                Console.WriteLine($"<{root}> is greater than <{root2}>");
            else
                Console.WriteLine($"<{root}> and <{root2}> are equivalent in order");
        }
        public static void sample5()
        {
            string first = "Sie tanzen auf der Straße.";
            string second = "Sie tanzen auf der Strasse.";
            Console.WriteLine($"First sentence is <{first}>");
            Console.WriteLine($"Second sentence is <{second}>");
            bool equal = String.Equals(first, second, StringComparison.InvariantCulture);
            Console.WriteLine($"The two strings {(equal == true ? "are" : "are not")} equal.");
            showComparison(first, second);
            string word = "coop";
            string words = "co-op";
            string other = "cop";
            showComparison(word, words);
            showComparison(word, other);
            showComparison(words, other);
            void showComparison(string one, string two)
            {
                int compareLinguistic = String.Compare(one, two, StringComparison.InvariantCulture);
                int compareOrdinal = String.Compare(one, two, StringComparison.Ordinal);
                if (compareLinguistic < 0)
                    Console.WriteLine($"<{one}> is less than <{two}> using invariant culture");
                else if (compareLinguistic > 0)
                    Console.WriteLine($"<{one}> is greater than <{two}> using invariant culture");
                else
                    Console.WriteLine($"<{one}> and <{two}> are equivalent in order using invariant culture");
                if (compareOrdinal < 0)
                    Console.WriteLine($"<{one}> is less than <{two}> using ordinal comparison");
                else if (compareOrdinal > 0)
                    Console.WriteLine($"<{one}> is greater than <{two}> using ordinal comparison");
                else
                    Console.WriteLine($"<{one}> and <{two}> are equivalent in order using ordinal comparison");
            }
        }
        public static void sample6()
        {
            string first = "Sie tanzen auf der Straße.";
            string second = "Sie tanzen auf der Strasse.";
            Console.WriteLine($"First sentence is <{first}>");
            Console.WriteLine($"Second sentence is <{second}>");
            var en = new System.Globalization.CultureInfo("en-US");
            // For culture-sensitive comparisons, use the String.Compare
            // overload that takes a StringComparison value.
            int i = String.Compare(first, second, en, System.Globalization.CompareOptions.None);
            Console.WriteLine($"Comparing in {en.Name} returns {i}.");
            var de = new System.Globalization.CultureInfo("de-DE");
            i = String.Compare(first, second, de, System.Globalization.CompareOptions.None);
            Console.WriteLine($"Comparing in {de.Name} returns {i}.");
            bool b = String.Equals(first, second, StringComparison.CurrentCulture);
            Console.WriteLine($"The two strings {(b ? "are" : "are not")} equal.");
            string word = "coop";
            string words = "co-op";
            string other = "cop";
            showComparison(word, words, en);
            showComparison(word, other, en);
            showComparison(words, other, en);
            void showComparison(string one, string two, System.Globalization.CultureInfo culture)
            {
                int compareLinguistic = String.Compare(one, two, en, System.Globalization.CompareOptions.None);
                int compareOrdinal = String.Compare(one, two, StringComparison.Ordinal);
                if (compareLinguistic < 0)
                    Console.WriteLine($"<{one}> is less than <{two}> using en-US culture");
                else if (compareLinguistic > 0)
                    Console.WriteLine($"<{one}> is greater than <{two}> using en-US culture");
                else
                    Console.WriteLine($"<{one}> and <{two}> are equivalent in order using en-US culture");
                if (compareOrdinal < 0)
                    Console.WriteLine($"<{one}> is less than <{two}> using ordinal comparison");
                else if (compareOrdinal > 0)
                    Console.WriteLine($"<{one}> is greater than <{two}> using ordinal comparison");
                else
                    Console.WriteLine($"<{one}> and <{two}> are equivalent in order using ordinal comparison");
            }
        }
        public static void sample7()
        {
            string[] lines = new string[]
            {
            @"c:\public\textfile.txt",
            @"c:\public\textFile.TXT",
            @"c:\public\Text.txt",
            @"c:\public\testfile2.txt"
            };
            Array.Sort(lines, StringComparer.CurrentCulture);
            string searchString = @"c:\public\TEXTFILE.TXT";
            Console.WriteLine($"Binary search for <{searchString}>");
            int result = Array.BinarySearch(lines, searchString, StringComparer.CurrentCulture);
            ShowWhere<string>(lines, result);
            Console.WriteLine($"{(result > 0 ? "Found" : "Did not find")} {searchString}");
            void ShowWhere<T>(T[] array, int index)
            {
                if (index < 0)
                {
                    index = ~index;
                    Console.Write("Not found. Sorts between: ");
                    if (index == 0)
                        Console.Write("beginning of sequence and ");
                    else
                        Console.Write($"{array[index - 1]} and ");
                    if (index == array.Length)
                        Console.WriteLine("end of sequence.");
                    else
                        Console.WriteLine($"{array[index]}.");
                }
                else
                {
                    Console.WriteLine($"Found at index {index}.");
                }
            }
        }
    }
    public partial class Program
    {
        static void MainPatternMatchingSwitch(string[] args)
        {
            PatternMatchingSwitch(null);
            //int i = 5;
            //PatternMatchingNullable(i);
            //int? j = null;
            //PatternMatchingNullable(j);
            //double d = 9.78654;
            //PatternMatchingNullable(d);
            //PatternMatchingSwitch(i);
            //PatternMatchingSwitch(j);
            //PatternMatchingSwitch(d);
        }
        static void PatternMatchingNullable(System.ValueType val)
        {
            if (val is int j) // Nullable types are not allowed in patterns
            {
                Console.WriteLine(j);
            }
            else if (val is null) // If val is a nullable type with no value, this expression is true
            {
                Console.WriteLine("val is a nullable type with the null value");
            }
            else
            {
                Console.WriteLine("Could not convert " + val.ToString());
            }
        }
        static void PatternMatchingSwitch(System.ValueType val)
        {
            switch (val)
            {
                case int number:
                    Console.WriteLine(number);
                    break;
                case long number:
                    Console.WriteLine(number);
                    break;
                case decimal number:
                    Console.WriteLine(number);
                    break;
                case float number:
                    Console.WriteLine(number);
                    break;
                case double number:
                    Console.WriteLine(number);
                    break;
                case null:
                    Console.WriteLine("val is a nullable type with the null value");
                    break;
                default:
                    Console.WriteLine("Could not convert " + val.ToString());
                    break;
            }
        }
    }
}
