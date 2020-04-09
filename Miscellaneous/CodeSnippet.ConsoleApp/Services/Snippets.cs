using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Linq.Expressions;
namespace CodeSnippet.ConsoleApp.Services
{

    #region fake it easy

    //Model
    public class Request
    {
        public string Param { get; set; }
    }

    //Repository
    public class MyRepository : IMyRepository
    {
        public string Get(Expression<Func<Request, bool>> query) { return default; }
    }

    //Service
    public class MyService
    {
        private readonly IMyRepository _myRepository;
        public MyService(IMyRepository myRepository)
        {
            _myRepository = myRepository;
        }

        public string Search(string searchText)
        {
            return _myRepository.Get(x => x.Param == searchText);
        }
    }
    [TestClass]
    public class DashboardServiceTest
    {
        MyService service;
        IMyRepository _fakeMyRepository;

        public void Initialize()
        {
            _fakeMyRepository = A.Fake<IMyRepository>();
            service = new MyService(_fakeMyRepository);
        }

        [TestMethod]
        public void GetFilteredRfqs_FilterBy_RfqId()
        {
            //var result = service.Search("abc");
            //A.CallTo(() => _fakeMyRepository.Get(A<Expression<Func<Request, bool>>>._)).MustHaveHappened();
            //A.CallTo(() => _fakeMyRepository.Get(x => x.Param == "abc")).MustHaveHappened();
            //A.CallTo(() => _fakeMyRepository.Get(x => x.Param == "abc")).WhenArgumentsMatch(default);
            //A.CallTo(() => _fakeMyRepository.Get(x => x.Param == "abc")).WhenArgumentsMatch((Expression<Func<Request, bool>> query) => true).Returns("Correctly worked!!");
            //A.CallTo(() => _fakeMyRepository.Get(x => x.Param == "abc")).WhenArgumentsMatch((Expression<Func<Request, bool>> query) => query.ReturnType.Name == "xyz").Throws<Exception>();
            //var s = A<string>.That.Matches(s => s.Length == 3 && s[1] == 'X');
            //query.Equals(default)
            var req = new Request
            {
                Param = "My Soul"
            };
            Expression<Func<Request, bool>> ExReq = req => req.Param.Contains("q");
            A.CallTo(() => _fakeMyRepository.Get(A<Expression<Func<Request, bool>>>.That.Matches(ExReq => ExReq.Body.ToString() == "req.Param.Contains(\"q\")"))).MustHaveHappened();
        }
    }

    public interface IMyRepository
    {
        public string Get(Expression<Func<Request, bool>> query);
    }


    #endregion

    #region Smaller numbers than current
    /*
     public class Solution
    {
        public int[] SmallerNumbersThanCurrent(int[] nums)
        {

            var groups = nums
                .Select((val, index) => new { index, val })
                .GroupBy(x => x.val)
                .OrderBy(g => g.Key)
                .Select(g => g.Select(x => x.index).ToArray());

            var arr = new int[nums.Length];

            int numSmaller = 0;

            foreach (var indices in groups)
            {
                foreach (var index in indices)
                {
                    arr[index] = numSmaller;
                }

                numSmaller += indices.Length;
            }

            return arr;
        }

        public int[] SmallerNumbersThanCurrentShorter(int[] nums)
        {
            return (from x in nums select (from y in nums where y < x select y).Count()).ToArray();
        }
    }
    */
    #endregion

    #region sqlconnection snippet
    /*
    SqlConnection con = new SqlConnection("Data Source=MCNDESKTOP03;Initial Catalog=pulkit;User ID=sa;Password=wintellect@123");
    SqlCommandBuilder cmd;
    SqlDataAdapter da;
    DataSet ds;

    private void Form1_Load(object sender, EventArgs e)
    {
     con.Open();
     da = new SqlDataAdapter("select *from emp5", con);
     cmd = new SqlCommandBuilder(da);
     ds = new DataSet();
     da.Fill(ds);
     dataGridView1.DataSource = ds.Tables[0];
     con.Close();
    }
     */
    #endregion

    #region writting to the event log (event viewer)
    /*
     using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Diagnostics;  
using System.IO;  
using System.Security.Permissions;  
  
namespace Common {  
    //This Class is used for logging messages to either a custom EventViewer or in a plain text file located on web server.

    public class Logging
    {
        #region "Variables"  

        private string sLogFormat;
        private string sErrorTime;

        #endregion


        #region "Local methods"  

        //Write to Txt Log File
        public void WriteToLogFile(string sErrMsg)
        {
            try
            {
                //sLogFormat used to create log format :  
                // dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message  
                sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";

                //this variable used to create log filename format "  
                //for example filename : ErrorLogYYYYMMDD  
                string sYear = DateTime.Now.Year.ToString();
                string sMonth = DateTime.Now.Month.ToString();
                string sDay = DateTime.Now.Day.ToString();
                sErrorTime = sYear + sMonth + sDay;

                //writing to log file  
                string sPathName = "C:\\Logs\\ErrorLog" + sErrorTime;
                StreamWriter sw = new StreamWriter(sPathName + ".txt", true);
                sw.WriteLine(sLogFormat + sErrMsg);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                WriteToEventLog("MySite", "Logging.WriteToLogFile", "Error: " + ex.ToString(), EventLogEntryType.Error);
            }
        }
        
    public void WriteToEventLog(string sLog, string sSource, string message, EventLogEntryType level) {  
    //RegistryPermission regPermission = new RegistryPermission(PermissionState.Unrestricted);  
    //regPermission.Assert();  
  
    if (!EventLog.SourceExists(sSource)) EventLog.CreateEventSource(sSource, sLog);  
  
    EventLog.WriteEntry(sSource, message, level);  
    }  
 
    #endregion
    }  
    } 
     */
    #endregion

    #region Parameter Lines Sorter
    /*
     public class ParameterLinesSorter : IParameterLinesSorter
    {
        private int identiferIndex;
        private IEnumerable<string[]> parameterLines;

        public IEnumerable<IEnumerable<string[]>> Sort(IEnumerable<string[]> parameterLines, int identiferIndex)
        {
            this.identiferIndex = identiferIndex;
            this.parameterLines = parameterLines;

            return IsNotNullAndNotEmpty() ? FilterAndSort() : new List<IEnumerable<string[]>>();
        }

        private bool IsNotNullAndNotEmpty()
        {
            return parameterLines != null && parameterLines.Any();
        }

        private IEnumerable<IEnumerable<string[]>> FilterAndSort()
        {
            var resp = parameterLines
                .Where(parameterLine => parameterLine.Any())
                .GroupBy(parameterLine => parameterLine.ElementAt(identiferIndex));
            return resp;
        }
        [Test]
        public void ShouldReturnListWithTwoGroupsOfOneElement()
        {
            IEnumerable<string[]> parameterLines = new List<string[]>() {
                new string[]{ "C", "3", "3" },
                new string[]{ "M", "3", "5" }
            };

            #region hand tested q and a
            IEnumerable<string[]> parameterLines2 = new List<string[]>() {
                new string[]{ "A", "5", "2" },
                new string[]{ "A", "3", "0" },
                new string[]{ "A", "1", "2" },
                new string[]{ "B", "3", "4" },
                new string[]{ "B", "5", "6" },
                new string[]{ "B", "7", "8" },
                new string[]{ "B", "9", "10" },
                new string[]{ "B", "11", "12" },
                new string[]{ "B", "12", "14" },
            };

            var answer = new List<IEnumerable<string[]>>()//using parameter2
            {
                new List<string[]>()
                {
                    new string[]{ "A", "5", "2" },
                    new string[]{ "A", "3", "0" },
                    new string[]{ "A", "1", "2" },
                },
                new List<string[]>()
                {
                    new string[]{ "B", "3", "4" },
                    new string[]{ "B", "5", "6" },
                    new string[]{ "B", "7", "8" },
                    new string[]{ "B", "9", "10" },
                    new string[]{ "B", "11", "12" },
                    new string[]{ "B", "12", "14" },
                },
            };
            #endregion

            IEnumerable<IEnumerable<string[]>> expectedGroups = new List<IEnumerable<string[]>>() {
                new List<string[]>(){ new string[]{ "C", "3", "3" }},
                new List<string[]>(){ new string[]{ "M", "3", "5" }}
            };

            Assert.AreEqual(expectedGroups, Sort(parameterLines, 0));
        }
    }

    public interface IParameterLinesSorter
    {
    }
    */
    #endregion
}