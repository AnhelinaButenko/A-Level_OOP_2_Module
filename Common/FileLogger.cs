using System.Text;
using Common;

namespace HW_1_Module_2;

public enum LogType
{
    Info,
    Warning,
    Error
}

public class FileLogger : ILogger
{
    private static readonly FileLogger _instance = new FileLogger();
    private readonly StringBuilder _allLogs;

    private FileLogger()
    {
        _allLogs = new StringBuilder();
    }

    public static FileLogger Instance => _instance;

    public string AllLogs => _allLogs.ToString();

    private void Log(LogType type, string message)
    {
        string log = $"{DateTime.UtcNow} : {type.ToString()} : {message}";
        _allLogs.AppendLine(log);
        Console.WriteLine(log);
    }

    public void LogInfo(string message )
    {
        Log(LogType.Info, message);
    }

    public void LogWarning(string message ) 
    { 
        Log(LogType.Warning, message);
    }    

    public void LogError(string message ) 
    {
        Log(LogType.Error, message);
    }
}

