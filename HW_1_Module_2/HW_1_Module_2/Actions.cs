namespace HW_1_Module_2
{
    static class Actions
    {
        private static Logger _logger;

        static Actions()
        {
            _logger = Logger.Instance;
        }

        public static Result InfoAction() 
        {
            _logger.LogInfo($"Start method: {nameof(InfoAction)}");
            Result result = new Result() { Status = LogType.Info};
            return result;
        }

        public static Result WarningAction()
        {
            _logger.LogWarning($"Skipped logic in method: {nameof(WarningAction)}");
            Result result = new Result() { Status = LogType.Warning};
            return result;
        }

        public static Result ErrorAction()
        {
            _logger.LogError($"Skipped logic in method: {nameof(ErrorAction)}");
            Result result = new Result() {Status = LogType.Error ,ErrorMessage = "Broke a logic" };
            return result;
        }
    }
}
