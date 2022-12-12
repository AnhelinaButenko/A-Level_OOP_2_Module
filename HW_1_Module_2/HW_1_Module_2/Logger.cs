using System.Text;

namespace HW_1_Module_2
{
    class Logger
    {
        private static readonly Logger _instance = new Logger();
        private readonly StringBuilder _allLogs;

        private Logger()
        {
            _allLogs = new StringBuilder();
        }

        public static Logger Instance => _instance;

        public string AllLogs => _allLogs.ToString();

        private void Log( LogType type, string message)
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
}
