using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace CodeSnippet.ConsoleApp
{
    // Interface defining a Change method
    internal interface IChangeBoxedPoint
    {
        void Change(Int32 x, Int32 y);
    }
    // Point is a value type.
    internal struct Point : IChangeBoxedPoint
    {
        private Int32 m_x, m_y;
        public Point(Int32 x, Int32 y)
        {
            m_x = x;
            m_y = y;
        }
        public void Change(Int32 x, Int32 y)
        {
            m_x = x; m_y = y;
        }
        public override String ToString()
        {
            return String.Format("({0}, {1})", m_x.ToString(), m_y.ToString());
        }
    }
    public sealed class Program
    {
        public static void Main()
        {
            Point p = new Point(1, 1);
            Console.WriteLine(p);
            p.Change(2, 2);
            Console.WriteLine(p);
            Object o = p;
            Console.WriteLine(o);
            ((Point)o).Change(3, 3);
            Console.WriteLine(o);
            // Boxes p, changes the boxed object and discards it
            ((IChangeBoxedPoint)p).Change(4, 4);
            Console.WriteLine(p);
            // Changes the boxed object and shows it
            ((IChangeBoxedPoint) o).Change(5, 5);
            Console.WriteLine(o);
        }
    }
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
}
