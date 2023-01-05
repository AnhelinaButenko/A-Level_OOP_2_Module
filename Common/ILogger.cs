namespace Common;

public interface ILogger
{
    void LogInfo(string message);
    void LogWarning(string message);
    void LogError(string message);
}

public interface IFileLogger : ILogger
{
    void WriteLogs();
}