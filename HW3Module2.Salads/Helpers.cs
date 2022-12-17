using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3Module2.Salads
{
    static class Helpers
    {
        public static int GetUserInput(int[] possibleValues)
        {
            int.TryParse(Console.ReadLine(), out int userInput);

            while (!possibleValues.Contains(userInput))
            {
                Console.WriteLine("Incorrect Input. Please type 1, 2, 3");
                int.TryParse(Console.ReadLine(), out userInput);
            }

            if (userInput == 3)
            {
                System.Environment.Exit(0);
            }
            return userInput;
        }

        public static bool GetUserInput(string[] possibleValues)
        {
            string userInput = Console.ReadLine().ToLower();

            while (!possibleValues.Contains(userInput))
            {
                Console.WriteLine("Incorrect Input. Please type 'true' or 'false'");
                userInput = Console.ReadLine().ToLower();
            }

            if (userInput.ToLower() == "true")
            {
                return true;
            }
            return false;
        }

        public static int GetValidValueWholeNumber()
        {
            string stringOpinion = Console.ReadLine();
            int opinion;
            bool parseResult = int.TryParse(stringOpinion, out opinion);

            while (!parseResult)
            {
                Console.WriteLine("Incorrect Input. Please type only numbers. Letters and signs are prohibited!");
                parseResult = int.TryParse(Console.ReadLine(), out opinion);
                if (opinion <= 0)
                {
                    parseResult = false;
                }
            }
            return opinion;
        }

        public static double GetValidValueNumber()
        {
            string stringOpinion = Console.ReadLine();
            double opinion;
            bool parseResult = double.TryParse(stringOpinion, out opinion);

            while (!parseResult)
            {
                Console.WriteLine("Incorrect Input. Please type only numbers. Letters and signs are prohibited!");
                parseResult = double.TryParse(Console.ReadLine(), out opinion);
                if (opinion <= 0)
                {
                    parseResult = false;
                }
            }
            return opinion;
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
}
