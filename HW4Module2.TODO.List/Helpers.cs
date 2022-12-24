namespace HW4Module2.TODO.List;

public class Helpers
{
    public static int GetValidValueWholeNumber()
    {
        string stringOpinion = Console.ReadLine();
        int option;
        bool parseResult = int.TryParse(stringOpinion, out option);

        while (!parseResult)
        {
            Console.WriteLine("Incorrect Input. Please type only numbers. Letters and signs are prohibited!");
            parseResult = int.TryParse(Console.ReadLine(), out option);
            if (option <= 0)
            {
                parseResult = false;
            }
        }
        return option;
    }

    public static string GetValidStringValue()
    {
        string parametr = Console.ReadLine();
        bool parseResult = string.IsNullOrEmpty(parametr);

        if (parseResult)
        {
            Console.WriteLine("String is empty. Please try again!");
        }

        while (parseResult)
        {
            parametr = Console.ReadLine();
            parseResult = string.IsNullOrEmpty(parametr);
        }
        return parametr;
    }
}
