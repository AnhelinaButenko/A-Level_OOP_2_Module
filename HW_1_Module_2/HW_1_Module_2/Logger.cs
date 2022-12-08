using System.Text;

namespace HW_1_Module_2
{
    class Logger
    {
        private static readonly Logger _instance = new Logger();
        private  readonly StringBuilder _logLevel;

        static Logger() 
        { 
        }

        private Logger()
        {
            _logLevel = new StringBuilder();
        }

        public static Logger Instance => _instance;

        public string AllLogs => _logLevel.ToString();

        public void Log( LogType type, string message)
        {
            string log = $"{DateTime.UtcNow} : {type.ToString()} : {message}";
            _logLevel.AppendLine(log);
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
