using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;

namespace Common;

public enum LogType
{
    Info,
    Warning,
    Error
}

public class Log
{
    public Guid Id { get; set; }
    public DateTime LogTime { get; set; }
    public string Content { get; set; }
}

public class UserSeializationSetting
{
    public static string Setting { get; set; }
}

public class FileLogger : IFileLogger
{
    private static readonly FileLogger _instance = new FileLogger();

    private readonly List<Log> _logList;

    private readonly UserSeializationSetting _userSeializationSetting;

    private FileLogger()
    {
        _logList = new List<Log>();
    }

    public static FileLogger Instance => _instance;

    private void Log(LogType type, string message)
    {
        string content = $"{type.ToString()} : {message}";
        Log log = new Log
        {
            Id = Guid.NewGuid(),
            LogTime = DateTime.Now,
            Content = content
        };
        
        Console.WriteLine(JsonConvert.SerializeObject(log));
        _logList.Add(log);
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

    public void WriteLogs()
    {
        ////CREARE DIRECTCORY IS NOT EXISTS
        // check how many directories contain

        string path = string.Empty;
        string directory = "Log";
        string dateStr = DateTime.Now.ToString("MMddyyyyHHmmss");

        if (UserSeializationSetting.Setting == "json")
        {
            path = $"Log\\log-{dateStr}.json";
            Directory.CreateDirectory(directory);
            File.WriteAllText(path, JsonConvert.SerializeObject(_logList));
        }

        if (UserSeializationSetting.Setting == "xml")
        {
            path = $"Log\\log-{dateStr}.xml";
            Directory.CreateDirectory(directory);
            XmlSerializer formatter = new XmlSerializer(typeof(List<Log>));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, _logList);
            }
        }

        DirectoryInfo info = new DirectoryInfo(directory);
        FileInfo[] files = info.GetFiles().OrderByDescending(p => p.CreationTime).ToArray();

        if (files.Length > 3)
        {
            File.Delete(files[0].FullName);
        }
    }
}

