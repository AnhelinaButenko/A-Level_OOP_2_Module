namespace HW4Module2.TODO.List;

public class MenuProgram
{
    public static void BuildMenuOperation()
    {
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
                DateTime timeReminder = Convert.ToDateTime(Console.ReadLine());
                itemService.Add(taskNameAddReminder, timeReminder);
                break;

            case "Add-reminder-rc":
                Console.WriteLine($"Input task name for Add-reminder-rc: ");
                string taskNameAddReminderRc = Helpers.GetValidStringValue();
                Console.WriteLine($"Input task time: ");
                DateTime timeReminderRc = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Input repetition type: Daily, Weekly, Monthly or Yearly");
                string repetitionType = Helpers.GetValidStringValue();
                
                if (RepetitionTypes.VerifyRepetitionType(repetitionType))
                {
                    itemService.Add(taskNameAddReminderRc, timeReminderRc, repetitionType);
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

                // call service to check if the item wit provided Id exists

                Console.WriteLine($"Input item name for Update: ");
                string name = Console.ReadLine();
                // the same for reminder and repetition type

                //Console.WriteLine("Do you want to update the");

                var newItem = new Item 
                {
                    Name = name,
                    // the same for reminder and repetition type
                };
                itemService.Update(updateNumberId, newItem);
                Back();
                break;

            case "Get All":
                List<Item> items = itemService.GetAll();

                foreach (var item in items)
                {
                    Console.WriteLine($"{ item.Id},{ item.Name},{ item.TaskRepetitionType},{item.FulfillmentTime}");
                }  
                
                Back();
                return;

            case "Exit":
                Environment.Exit(0);
                break;
            default:
                break;
        }
    }
}
