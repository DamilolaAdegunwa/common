using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace CodeSnippet.ConsoleApp
{
    #region group result by contiguous keys

    #endregion
    #region student class
    public class StudentClass
    {
        #region data
        protected enum GradeLevel { FirstYear = 1, SecondYear, ThirdYear, FourthYear };
        protected class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int ID { get; set; }
            public GradeLevel Year;
            public List<int> ExamScores;
        }
        protected static List<Student> students = new List<Student>
{
new Student {FirstName = "Terry", LastName = "Adams", ID = 120,
Year = GradeLevel.SecondYear,
ExamScores = new List<int>{ 99, 82, 81, 79}},
new Student {FirstName = "Fadi", LastName = "Fakhouri", ID = 116,
Year = GradeLevel.ThirdYear,
ExamScores = new List<int>{ 99, 86, 90, 94}},
new Student {FirstName = "Hanying", LastName = "Feng", ID = 117,
Year = GradeLevel.FirstYear,
ExamScores = new List<int>{ 93, 92, 80, 87}},
new Student {FirstName = "Cesar", LastName = "Garcia", ID = 114,
Year = GradeLevel.FourthYear,
ExamScores = new List<int>{ 97, 89, 85, 82}},
new Student {FirstName = "Debra", LastName = "Garcia", ID = 115,
Year = GradeLevel.ThirdYear,
ExamScores = new List<int>{ 35, 72, 91, 70}},
new Student {FirstName = "Hugo", LastName = "Garcia", ID = 118,
Year = GradeLevel.SecondYear,
ExamScores = new List<int>{ 92, 90, 83, 78}},
new Student {FirstName = "Sven", LastName = "Mortensen", ID = 113,
Year = GradeLevel.FirstYear,
ExamScores = new List<int>{ 88, 94, 65, 91}},
new Student {FirstName = "Claire", LastName = "O'Donnell", ID = 112,
//Grouping is one of the most powerful capabilities of LINQ. The following examples show how to group data in
//various ways:
//By a single property.
//By the first letter of a string property.
//By a computed numeric range.
//By Boolean predicate or other expression.
//By a compound key.
//In addition, the last two queries project their results into a new anonymous type that contains only the student's
//first and last name. For more information, see the group clause.
//All the examples in this topic use the following helper classes and data sources.
Year = GradeLevel.FourthYear,
ExamScores = new List<int>{ 75, 84, 91, 39}},
new Student {FirstName = "Svetlana", LastName = "Omelchenko", ID = 111,
Year = GradeLevel.SecondYear,
ExamScores = new List<int>{ 97, 92, 81, 60}},
new Student {FirstName = "Lance", LastName = "Tucker", ID = 119,
Year = GradeLevel.ThirdYear,
ExamScores = new List<int>{ 68, 79, 88, 92}},
new Student {FirstName = "Michael", LastName = "Tucker", ID = 122,
Year = GradeLevel.FirstYear,
ExamScores = new List<int>{ 94, 92, 91, 91}},
new Student {FirstName = "Eugene", LastName = "Zabokritski", ID = 121,
Year = GradeLevel.FourthYear,
ExamScores = new List<int>{ 96, 85, 91, 60}}
};
        #endregion
        //Helper method, used in GroupByRange.
        protected static int GetPercentile(Student s)
        {
            double avg = s.ExamScores.Average();
            return avg > 0 ? (int)avg / 10 : 0;
        }
        public void QueryHighScores(int exam, int score)
        {
            var highScores = from student in students
                             where student.ExamScores[exam] > score
                             select new { Name = student.FirstName, Score = student.ExamScores[exam] };
            foreach (var item in highScores)
            {
                Console.WriteLine($"{item.Name,-15}{item.Score}");
            }
        }
        public void GroupBySingleProperty()
        {
            Console.WriteLine("Group by a single property in an object:");
            // Variable queryLastNames is an IEnumerable<IGrouping<string,
            // DataClass.Student>>.
            var queryLastNames =
            from student in students
            group student by student.LastName into newGroup
            orderby newGroup.Key
            select newGroup;
            foreach (var nameGroup in queryLastNames)
            {
                Console.WriteLine($"Key: {nameGroup.Key}");
                foreach (var student in nameGroup)
                {
                    Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
                }
            }
        }

        /* Output:
        Group by a single property in an object:
        Key: Adams
        Adams, Terry
        Key: Fakhouri
        Fakhouri, Fadi
        Key: Feng
        Feng, Hanying
        Key: Garcia
        Garcia, Cesar
        Garcia, Debra
        Garcia, Hugo
        Key: Mortensen
        Mortensen, Sven
        Key: O'Donnell
        O'Donnell, Claire
        Key: Omelchenko
        Omelchenko, Svetlana
        Key: Tucker
        Tucker, Lance
        Tucker, Michael
        Key: Zabokritski
        Zabokritski, Eugene
        */
        public void GroupBySubstring()
        {
            Console.WriteLine("\r\nGroup by something other than a property of the object:");
            var queryFirstLetters =
            from student in students
            group student by student.LastName[0];
            foreach (var studentGroup in queryFirstLetters)
            {
                Console.WriteLine($"Key: {studentGroup.Key}");
                // Nested foreach is required to access group items.
                foreach (var student in studentGroup)
                {
                    Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
                }
            }
        }
        /* Output:
        Group by something other than a property of the object:
        Key: A
        Adams, Terry
        Key: F
        Fakhouri, Fadi
        Feng, Hanying
        Key: G
        Garcia, Cesar
        Garcia, Debra
        Garcia, Hugo
        Key: M
        Mortensen, Sven
        Key: O
        O'Donnell, Claire
        Omelchenko, Svetlana
        Key: T
        Tucker, Lance
        Tucker, Michael
        Key: Z
        Zabokritski, Eugene
        */
        public void GroupByRange()
        {
            Console.WriteLine("\r\nGroup by numeric range and project into a new anonymous type:");
            var queryNumericRange =
            from student in students
            let percentile = GetPercentile(student)
            group new { student.FirstName, student.LastName } by percentile into percentGroup
            orderby percentGroup.Key
            select percentGroup;
            // Nested foreach required to iterate over groups and group items.
            foreach (var studentGroup in queryNumericRange)
            {
                Console.WriteLine($"Key: {studentGroup.Key * 10}");
                foreach (var item in studentGroup)
                {
                    Console.WriteLine($"\t{item.LastName}, {item.FirstName}");
                }
            }
        }
        /* Output:
        Group by numeric range and project into a new anonymous type:
        Key: 60
        Garcia, Debra
        Key: 70
        O'Donnell, Claire
        Key: 80
        Adams, Terry
        Feng, Hanying
        Garcia, Cesar
        Garcia, Hugo
        Mortensen, Sven
        Omelchenko, Svetlana
        Tucker, Lance
        Zabokritski, Eugene
        Key: 90
        Fakhouri, Fadi
        Tucker, Michael
        */
        public void GroupByBoolean()
        {
            Console.WriteLine("\r\nGroup by a Boolean into two groups with string keys");
            Console.WriteLine("\"True\" and \"False\" and project into a new anonymous type:");
            var queryGroupByAverages = from student in students
                                       group new { student.FirstName, student.LastName }
                                       by student.ExamScores.Average() > 75 into studentGroup
                                       select studentGroup;
            foreach (var studentGroup in queryGroupByAverages)
            {
                Console.WriteLine($"Key: {studentGroup.Key}");
                foreach (var student in studentGroup)
                    Console.WriteLine($"\t{student.FirstName} {student.LastName}");
            }
        }
        /* Output:
        Group by a Boolean into two groups with string keys
        "True" and "False" and project into a new anonymous type:
        Key: True
        Terry Adams
        Fadi Fakhouri
        Hanying Feng
        Cesar Garcia
        Hugo Garcia
        Sven Mortensen
        Svetlana Omelchenko
        Lance Tucker
        Michael Tucker
        Eugene Zabokritski
        Key: False
        Debra Garcia
        Claire O'Donnell
        */
        public void GroupByCompositeKey()
        {
            var queryHighScoreGroups =
            from student in students
            group student by new
            {
                FirstLetter = student.LastName[0],
                Score = student.ExamScores[0] > 85
            } into studentGroup
            orderby studentGroup.Key.FirstLetter
            select studentGroup;
            Console.WriteLine("\r\nGroup and order by a compound key:");
            foreach (var scoreGroup in queryHighScoreGroups)
            {
                string s = scoreGroup.Key.Score == true ? "more than" : "less than";
                Console.WriteLine($"Name starts with {scoreGroup.Key.FirstLetter} who scored {s} 85");
                foreach (var item in scoreGroup)
                {
                    Console.WriteLine($"\t{item.FirstName} {item.LastName}");
                }
            }
        }
        /* Output:
        Group and order by a compound key:
        Name starts with A who scored more than 85
        Terry Adams
        Name starts with F who scored more than 85
        Fadi Fakhouri
        Hanying Feng
        Name starts with G who scored more than 85
        Cesar Garcia
        Hugo Garcia
        Name starts with G who scored less than 85
        Debra Garcia
        Name starts with M who scored more than 85
        Sven Mortensen
        Name starts with O who scored less than 85
        Claire O'Donnell
        Name starts with O who scored more than 85
        Svetlana Omelchenko
        Name starts with T who scored less than 85
        Lance Tucker
        Name starts with T who scored more than 85
        Michael Tucker
        Name starts with Z who scored more than 85
        Eugene Zabokritski
        */
        public void QueryNestedGroups()
        {
            var queryNestedGroups =
            from student in students
            group student by student.Year into newGroup1
            from newGroup2 in
            (from student in newGroup1
             group student by student.LastName)
            group newGroup2 by newGroup1.Key;
            // Three nested foreach loops are required to iterate
            // over all elements of a grouped group. Hover the mouse
            // cursor over the iteration variables to see their actual type.
            foreach (var outerGroup in queryNestedGroups)
            {
                Console.WriteLine($"DataClass.Student Level = {outerGroup.Key}");
                foreach (var innerGroup in outerGroup)
                {
                    Console.WriteLine($"\tNames that begin with: {innerGroup.Key}");
                    foreach (var innerGroupElement in innerGroup)
                    {
                        Console.WriteLine($"\t\t{innerGroupElement.LastName} {innerGroupElement.FirstName}");
                    }
                }
            }
        }
        /*
        Output:
        DataClass.Student Level = SecondYear
        Names that begin with: Adams
        Adams Terry
        Names that begin with: Garcia
        Garcia Hugo
        Names that begin with: Omelchenko
        Omelchenko Svetlana
        DataClass.Student Level = ThirdYear
        Names that begin with: Fakhouri
        Fakhouri Fadi
        Names that begin with: Garcia
        Garcia Debra
        Names that begin with: Tucker
        Tucker Lance
        DataClass.Student Level = FirstYear
        Names that begin with: Feng
        Feng Hanying
        Names that begin with: Mortensen
        Mortensen Sven
        Names that begin with: Tucker
        Tucker Michael
        DataClass.Student Level = FourthYear
        Names that begin with: Garcia
        Garcia Cesar
        Names that begin with: O'Donnell
        O'Donnell Claire
        Names that begin with: Zabokritski
        Zabokritski Eugene
        */
        public void QueryMax()
        {
            var queryGroupMax =
            from student in students
            group student by student.Year into studentGroup
            select new
            {
                Level = studentGroup.Key,
                HighestScore =
            (from student2 in studentGroup
             select student2.ExamScores.Average()).Max()
            };
            int count = queryGroupMax.Count();
            Console.WriteLine($"Number of groups = {count}");
            foreach (var item in queryGroupMax)
            {
                Console.WriteLine($" {item.Level} Highest Score={item.HighestScore}");
            }
        }
        public void QueryMaxUsingMethodSyntax()
        {
            var queryGroupMax = students
            .GroupBy(student => student.Year)
            .Select(studentGroup => new
            {
                Level = studentGroup.Key,
                HighestScore = studentGroup.Select(student2 => student2.ExamScores.Average()).Max()
            });
            int count = queryGroupMax.Count();
            Console.WriteLine($"Number of groups = {count}");
            foreach (var item in queryGroupMax)
            {
                Console.WriteLine($" {item.Level} Highest Score={item.HighestScore}");
            }
        }
    }
    public class Program
    {
        public static void Main()
        {
            StudentClass sc = new StudentClass();
            sc.QueryHighScores(1, 90);
            sc.GroupBySingleProperty();
            sc.GroupBySubstring();
            sc.GroupByRange();
            sc.GroupByBoolean();
            sc.QueryNestedGroups();
            sc.QueryMax();
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
    #endregion
    #region store result of query to memory
    class StoreQueryResults
    {
        static List<int> numbers = new List<int>() { 1, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
        static void Main()
        {
            IEnumerable<int> queryFactorsOfFour =
            from num in numbers
            where num % 4 == 0
            select num;
            // Store the results in a new variable
            // without executing a foreach loop.
            List<int> factorsofFourList = queryFactorsOfFour.ToList();
            // Iterate the list just to prove it holds data.
            Console.WriteLine(factorsofFourList[2]);
            factorsofFourList[2] = 0;
            Console.WriteLine(factorsofFourList[2]);
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
    }
    #endregion
    #region checking for queryables
    public class MQ
    {
        // QueryMethhod1 returns a query as its value.
        IEnumerable<string> QueryMethod1(ref int[] ints)
        {
            var intsToStrings = from i in ints
                                where i > 4
                                select i.ToString();
            return intsToStrings;
        }
        // QueryMethod2 returns a query as the value of parameter returnQ.
        void QueryMethod2(ref int[] ints, out IEnumerable<string> returnQ)
        {
            var intsToStrings = from i in ints where i < 4 select i.ToString();
            returnQ = intsToStrings;
        }
        static void Execute()
        {
            MQ app = new MQ();
            int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // QueryMethod1 returns a query as the value of the method.
            var myQuery1 = app.QueryMethod1(ref nums);
            // Query myQuery1 is executed in the following foreach loop.
            Console.WriteLine("Results of executing myQuery1:");
            // Rest the mouse pointer over myQuery1 to see its type.
            foreach (string s in myQuery1)
            {
                Console.WriteLine(s);
            }
            // You also can execute the query returned from QueryMethod1
            // directly, without using myQuery1.
            Console.WriteLine("\nResults of executing myQuery1 directly:");

            Console.WriteLine("\nResults of executing myQuery1 directly:");
            // Rest the mouse pointer over the call to QueryMethod1 to see its
            // return type.
            foreach (string s in app.QueryMethod1(ref nums))
            {
                Console.WriteLine(s);
            }
            IEnumerable<string> myQuery2;
            // QueryMethod2 returns a query as the value of its out parameter.
            app.QueryMethod2(ref nums, out myQuery2);
            // Execute the returned query.
            Console.WriteLine("\nResults of executing myQuery2:");
            foreach (string s in myQuery2)
            {
                Console.WriteLine(s);
            }
            // You can modify a query by using query composition. A saved query
            // is nested inside a new query definition that revises the results
            // of the first query.
            myQuery1 = from item in myQuery1
                       orderby item descending
                       select item;
            // Execute the modified query.
            Console.WriteLine("\nResults of executing modified myQuery1:");
            foreach (string s in myQuery1)
            {
                Console.WriteLine(s);
            }
            // Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    #endregion
    #region simple & complete test
    public class Student
    {
        #region data
        public enum GradeLevel { FirstYear = 1, SecondYear, ThirdYear, FourthYear };
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public GradeLevel Year;
        public List<int> ExamScores;
        protected static List<Student> students = new List<Student>
        {
        new Student {FirstName = "Terry", LastName = "Adams", Id = 120,
        Year = GradeLevel.SecondYear,
        ExamScores = new List<int> { 99, 82, 81, 79}},
        new Student {FirstName = "Fadi", LastName = "Fakhouri", Id = 116,
        Year = GradeLevel.ThirdYear,
        ExamScores = new List<int> { 99, 86, 90, 94}},
        new Student {FirstName = "Hanying", LastName = "Feng", Id = 117,
        Year = GradeLevel.FirstYear,
        ExamScores = new List<int> { 93, 92, 80, 87}},
        new Student {FirstName = "Cesar", LastName = "Garcia", Id = 114,
        Year = GradeLevel.FourthYear,
        ExamScores = new List<int> { 97, 89, 85, 82}},
        new Student {FirstName = "Debra", LastName = "Garcia", Id = 115,
        Year = GradeLevel.ThirdYear,
        ExamScores = new List<int> { 35, 72, 91, 70}},
        new Student {FirstName = "Hugo", LastName = "Garcia", Id = 118,
        Year = GradeLevel.SecondYear,
        ExamScores = new List<int> { 92, 90, 83, 78}},
        new Student {FirstName = "Sven", LastName = "Mortensen", Id = 113,
        Year = GradeLevel.FirstYear,
        ExamScores = new List<int> { 88, 94, 65, 91}},
        new Student {FirstName = "Claire", LastName = "O'Donnell", Id = 112,
        Year = GradeLevel.FourthYear,
        ExamScores = new List<int> { 75, 84, 91, 39}},
        new Student {FirstName = "Svetlana", LastName = "Omelchenko", Id = 111,
        Year = GradeLevel.SecondYear,
        ExamScores = new List<int> { 97, 92, 81, 60}},
        new Student {FirstName = "Lance", LastName = "Tucker", Id = 119,
        Year = GradeLevel.ThirdYear,
        ExamScores = new List<int> { 68, 79, 88, 92}},
        new Student {FirstName = "Michael", LastName = "Tucker", Id = 122,
        Year = GradeLevel.FirstYear,
        ExamScores = new List<int> { 94, 92, 91, 91}},
        new Student {FirstName = "Eugene", LastName = "Zabokritski", Id = 121,
        Year = GradeLevel.FourthYear,
        ExamScores = new List<int> { 96, 85, 91, 60}}
        };
        #endregion
        // Helper method, used in GroupByRange.
        protected static int GetPercentile(Student s)
        {
            double avg = s.ExamScores.Average();
            return avg > 0 ? (int)avg / 10 : 0;
        }
        public static void QueryHighScores(int exam, int score)
        {
            var highScores = from student in students
                             where student.ExamScores[exam] > score
                             select new { Name = student.FirstName, Score = student.ExamScores[exam] };
            foreach (var item in highScores)
            {
                Console.WriteLine($"{item.Name,-15}{item.Score}");
            }
        }
    }
    public class ExecuteProgram
    {
        public static void Execute()
        {
            Student.QueryHighScores(1, 90);
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
    #endregion
    public class LinqTest
    {
        class Country
        {
            public string Name { get; set; }
            public int Population { get; set; }
        }
        public LinqTest()
        {
            var countries = new List<Country> { new Country { Name = "Zealand" }, new Country { Name="Weasy" }, new Country { Name = "Fishy" }, new Country { Name="FishTaste" } };
            var queryCountryGroups =
            from country in countries
            group country by country.Name[1];

            // percentileQuery is an IEnumerable<IGrouping<int, Country>>
            var percentileQuery =
            from country in countries
            let percentile = (int)country.Population / 10_000_000
            group country by percentile into countryGroup
            where countryGroup.Key >= 20
            orderby countryGroup.Key
            select countryGroup;
            var done = "";
        }
    }
}
