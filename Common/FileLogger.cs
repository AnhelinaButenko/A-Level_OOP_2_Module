using System.Text;

namespace Common;

public enum LogType
{
    Info,
    Warning,
    Error
}

public class FileLogger : IFileLogger
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
        string log = $"{type.ToString()} : {message}";
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

    public void WriteLogs()
    {
        string dateStr = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        string filePath = $"{dateStr}log.txt";
        File.WriteAllText(filePath, AllLogs);
    }
}

