using System.Text;

namespace Common;

public class ConsoleLogger : ILogger
{
    private static readonly ConsoleLogger _instance = new ConsoleLogger();
    private readonly StringBuilder _allLogs;

    private ConsoleLogger()
    {
        _allLogs = new StringBuilder();
    }

    public static ConsoleLogger Instance => _instance;

    public string AllLogs => _allLogs.ToString();

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
