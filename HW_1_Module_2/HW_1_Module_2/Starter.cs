using Common;

namespace HW_1_Module_2
{
    static class Starter
    {
        private const string FilePath = "log.txt";
         
        private static readonly FileLogger _logger;

        static Starter()
        {
            _logger = FileLogger.Instance;
        }
        public static void Run()
        {
            var random = new Random();
            var result = new Result();

            for (var i = 0; i < 50; i++)
            {
                switch (random.Next(maxValue:3))
                {
                    case 0:
                        result = Actions.InfoAction();
                        break;
                        case 1:
                        result = Actions.WarningAction();
                        break;
                        case 2:
                        result = Actions.ErrorAction();
                        break;
                }

                if (result.Status == LogType.Error)
                {
                    _logger.LogError($"Action failed by a reason: {result.ErrorMessage}");
                }
            }
            File.WriteAllText(FilePath, _logger.AllLogs);
        }
    }
}
