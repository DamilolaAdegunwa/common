using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace CodeSnippet.ConsoleApp
{
    public class Logger//take the ...er suffix as a convention 
    {
        public static Action<string> WriteMessage;
        public static Severity LogLevel { get; set; } = Severity.Warning;
        public void LogMessage(Severity s, string component, string msg)
        {
            if (s < LogLevel)
                return;
            var outputMsg = $"{DateTime.Now}\t{s}\t{component}\t{msg}";
            WriteMessage?.Invoke(outputMsg);
        }
    }
    public class FileLogger : ILogger
    {
        //this would typically come from appsettings
        private readonly string logPath;
        public FileLogger()
        {
            //logPath = path;
            logPath = $"logger.FileLogger.log";
            //Logger.WriteMessage += LogMessage;
        }
        public void AttachLog()
        {
            Logger.WriteMessage += LogMessage;
        }
        public void DetachLog() => Logger.WriteMessage -= LogMessage;
        // make sure this can't throw.
        public void LogMessage(string msg)
        {
            try
            {
                using (var log = File.AppendText(logPath))
                {
                    log.WriteLine(msg);
                    log.Flush();
                }
            }
            catch (Exception)
            {
                // Hmm. We caught an exception while
                // logging. We can't really log the
                // problem (since it's the log that's failing).
                // So, while normally, catching an exception
                // and doing nothing isn't wise, it's really the
                // only reasonable option here.
            }
        }
    }
    public class ConsoleLogger : ILogger
    {
        public ConsoleLogger()
        {
            //Logger.WriteMessage += LogMessage;
        }
        public void AttachLog()
        {
            Logger.WriteMessage += LogMessage;
        }
        public void DetachLog()
        {
            Logger.WriteMessage -= LogMessage;
            //throw new NotImplementedException();
        }

        public void LogMessage(string msg)
        {
            Console.Error.WriteLine(msg);
            //throw new NotImplementedException();
        }
    }
    public enum Severity
    {
        Verbose,
        Trace,
        Information,
        Warning,
        Error,
        Critical
    }
    public interface ILogger
    {
        public void LogMessage(string msg);
        public void DetachLog();
        public void AttachLog();
    }
    public class UseLoggerService
    {
        private readonly ILogger _logger;
        public UseLoggerService(ConsoleLogger logger)
        {
            _logger = logger;
        }
        public UseLoggerService()
        {
            //_logger = new FileLogger();
            _logger = new ConsoleLogger();
        }
        public void Log(Severity s, string component, string msg, Action<Severity,string,string> action)
        {
            _logger.AttachLog();
            action(s,component,msg);
            _logger.DetachLog();
            //action($"{DateTime.Now} | {Severity.Information.ToString()} | {this.GetType().FullName} : "+message);
        }
        public void Index()
        {
            _logger.LogMessage("Please take this a work in progress!!");
        }
    }
}
//Messager