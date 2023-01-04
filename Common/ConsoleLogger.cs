using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common;

public class ConsoleLogger
{
    public class FileLogger : ILogger
    {
        private static readonly FileLogger _instance = new FileLogger();

        public static FileLogger Instance => _instance;

        private void Log(LogType type, string message)
        {
            string log = $"{type.ToString()} : {message}";
            Console.WriteLine(log);
        }

        public void LogInfo(string message)
        {
            Log(LogType.Info, message);
        }

        public void LogWarning(string message)
        {
            Log(LogType.Warning, message);
        }

        public void LogError(string message)
        {
            Log(LogType.Error, message);
        }          
    }
}
