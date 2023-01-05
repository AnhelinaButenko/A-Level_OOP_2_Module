using Common;

namespace HW4Module2.TODO.List;

public class MenuProgram
{
    private static IFileLogger _logger;
    private static ILogger _consoleLogger;

    public MenuProgram()
    {
        _logger = FileLogger.Instance;
        _consoleLogger = ConsoleLogger.Instance;
    }

    public static void BuildMenuOperation()
    {
        _logger = FileLogger.Instance;
        _consoleLogger = ConsoleLogger.Instance;

        //string userSearilization = "json";
        //UserSeializationSetting.Setting = userSearilization;
        //_logger.LogInfo("Test log");
        //_logger.WriteLogs();

        IItemService itemService = new ItemService();

        bool hasElement = itemService.Any();
        if (hasElement == false)
        {
            Console.WriteLine("Please input the word: Add");
        }
        else
        {
            Console.WriteLine("Choice and input:");
          
            Console.WriteLine("Add");               
            Console.WriteLine("Remove");
            Console.WriteLine("Update");
            Console.WriteLine("Get All");
            Console.WriteLine("Exit");
        }
    }

    public static void Back()
    {
        BuildMenuOperation();
        string operationSelectionOption = Helpers.GetValidStringValue();
        var info = $"This operation was selected by the user {operationSelectionOption}";
        _logger.LogInfo(info);
        _consoleLogger.LogInfo(info);
        HandleUserChoise(operationSelectionOption);
    }

    public static void AddTask()
    {
        IItemService itemService = new ItemService();
       
        Console.WriteLine("Choice and input:");
        Console.WriteLine("Add");
        Console.WriteLine("Add-reminder");
        Console.WriteLine("Add-reminder-rc");
        string optionChoice = Helpers.GetValidStringValue();
        var info = $"This operation for add was selected by the user {optionChoice}";
        _logger.LogInfo(info);
        _consoleLogger.LogInfo(info);

        switch (optionChoice)
        {
            case "Add":
                Console.WriteLine($"Input task name for Add: ");
                string taskNameAdd = Helpers.GetValidStringValue();                
                itemService.Add(taskNameAdd);
                break;

            case "Add-reminder":
                Console.WriteLine($"Input task name for Add-reminder: ");
                string taskNameAddReminder = Helpers.GetValidStringValue();
                Console.WriteLine($"Input task time: ");
                DateTime timeReminder = Helpers.GetValidDateTimeValue();
                itemService.Add(taskNameAddReminder, timeReminder);
                break;

            case "Add-reminder-rc":
                Console.WriteLine($"Input task name for Add-reminder-rc: ");
                string taskNameAddReminderRc = Helpers.GetValidStringValue();
                Console.WriteLine($"Input task time: ");
                DateTime timeReminderRc = Helpers.GetValidDateTimeValue();
                Console.WriteLine("Input repetition type: Daily, Weekly, Monthly or Yearly");
                string repetitionType = Helpers.GetValidStringValue();;
                if (RepetitionTypes.VerifyRepetitionType(repetitionType))
                {
                    itemService.Add(taskNameAddReminderRc, timeReminderRc, repetitionType);
                }
                else
                {
                    var error = $"Wrong repetition Type {repetitionType}";
                    _logger.LogError(error);
                    _consoleLogger.LogError(error);
                }
                break;

            default:
                break;
        }            
    }

    public static void HandleUserChoise(string operationSelectionOption)
    {
        IItemService itemService = new ItemService();

        
        switch (operationSelectionOption)
        {
            case "Add":
                AddTask();
                Back();
                break;

            case "Remove":
                Console.WriteLine($"Input number Id for Remove: ");
                int removeNumberId = Helpers.GetValidValueWholeNumber();
                itemService.Remove(removeNumberId);
                Back();
                break;

            case "Update":
                Console.WriteLine($"Input item Id for Update: ");
                int updateNumberId = Helpers.GetValidValueWholeNumber();

                Console.WriteLine($"Input task name for Update: ");
                string name = Helpers.GetValidStringValue();
                Console.WriteLine($"Input task time for Update: ");
                string taskRepetitionType = Helpers.GetValidStringValue();               
                Console.WriteLine($"Input repetition type for Update: Daily, Weekly, Monthly or Yearly ");
                DateTime fulfillmentTime = Helpers.GetValidDateTimeValue();                            
                
                var newItem = new Item 
                {
                    Name = name,
                    TaskRepetitionType = taskRepetitionType,
                    FulfillmentTime = fulfillmentTime                   
                };

                if (RepetitionTypes.VerifyRepetitionType(taskRepetitionType))
                {
                    itemService.Update(updateNumberId, newItem);
                }
                else
                {
                    var error = $"Wrong answer entered {operationSelectionOption}";
                    _consoleLogger.LogError(error);
                    _logger.LogError(error);
                    Console.WriteLine("Mistake!");
                }
                
                Back();
                break;

            case "Get All":
                List<Item> items = itemService.GetAll();

                foreach (var item in items)
                {
                    Console.WriteLine($"{item.Id} {item.Name} {item.FulfillmentTime} {item.TaskRepetitionType}");        
                }  
                
                Back();
                return;

            case "Exit":
                Console.WriteLine("Please choice and input format xml or json");
                string userSearilization = Helpers.GetValidStringValue().ToLower();
                UserSeializationSetting.Setting = userSearilization;
                _logger.WriteLogs();               

                Environment.Exit(0);
                break;
            default:
                break;
        }
    }
}
