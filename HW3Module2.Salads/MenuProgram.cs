using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3Module2.Salads
{
    public class MenuProgram
    {
        public enum Choices
        {
            ChoiceOurSalad = 1,
            CreateOwnSalad,
            Exit
        }

        public static void BuildMenuOperation()
        {
            Console.WriteLine("Choice:");
            Console.WriteLine("1 - Choice our salad");
            Console.WriteLine("2 - Create own salad");
            Console.WriteLine("3 - Exit");
        }

        public static void Back()
        {
            BuildMenuOperation();
            int userInput = Helpers.GetUserInput(new[] { 1, 2, 3 });
            HandleUserChoise(userInput);
        }

        public static void HandleUserChoiseOurSalad()
        {
            ISaladService saladService = new SaladService();

            List<Salad> salads = SaladDb.GetSaladsList();

            foreach (Salad salad in salads)
            {
                Console.WriteLine(salad.Name);
                Salad saladSort = saladService.Sort(salad);

                double calloriesSalad = saladService.GetCallories(salad);
                Console.WriteLine($"Callories salad: {calloriesSalad}");

                foreach (Ingridient ingridient in salad.Ingridients)
                {
                    Console.WriteLine($"Name salad: {ingridient.Name}, Callories: {ingridient.Callories}, Weight: {ingridient.Weight}");
                }
            }

            Console.WriteLine("Choose and write salad name: ");
            string optionsPresents = Helpers.GetValidStringValue();

            Salad chooseSalad = saladService.GetByName(salads, optionsPresents);

            foreach (var ingridient in chooseSalad.Ingridients)
            {
                Console.WriteLine($"Name salad: {ingridient.Name}, Callories: {ingridient.Callories}, Weight: {ingridient.Weight}");
            }
        }

        public static Salad CreateNewSalad(string newNameSalad)
        {
            Salad newSalad = new Salad
            {
                Name = newNameSalad,
                Ingridients = new List<Ingridient>()
            };

            Console.WriteLine("How many ingridients do you want to put in salad?");
            int amountIngridients = Helpers.GetValidValueWholeNumber();

            for (int i = 1; i <= amountIngridients; i++)
            {
                Console.WriteLine("Which kind of food you want to create? You can create Fruits, Vegetables, Meats, SeaFood and Souces");
                string desireKindOfFood = Helpers.GetValidStringValue();

                Console.WriteLine("Input ingridient name: ");
                string name = Helpers.GetValidStringValue();

                Console.WriteLine("Input callories on 100 gr: ");
                double callories = Helpers.GetValidValueNumber();

                Console.WriteLine("Input salad weight: ");
                double weight = Helpers.GetValidValueNumber();

                Ingridient ingridient = null;

                switch (desireKindOfFood)
                {
                    case "Fruits":
                        ingridient = new Fruits(name, callories, weight);
                        break;

                    case "Vegetables":
                        ingridient = new Vegetables(name, callories, weight);
                        break;

                    case "Meats":
                        ingridient = new Meats(name, callories, weight);
                        break;

                    case "SeaFood":
                        ingridient = new SeaFood(name, callories, weight);
                        break;

                    case "Souces":
                        ingridient = new Souces(name, callories, weight);
                        break;

                    default:
                        break;
                }
                newSalad.Ingridients.Add(ingridient);
            }

            List<Salad> salads = SaladDb.GetSaladsList();
            salads.Add(newSalad);
            return newSalad;
        }

        public static void HandleUserChoiseCreateNewSalad()
        {
            Console.WriteLine("Input salad name:");
            string newNameSalad = Helpers.GetValidStringValue();

            ISaladService saladService = new SaladService();

            List<Salad> salads = SaladDb.GetSaladsList();

            Salad existingSalad = saladService.GetByName(salads, newNameSalad);

            if (existingSalad == null)
            {
                Salad newSalad = CreateNewSalad(newNameSalad);
                InfoAboutSalad.ShowNewSaladInfo(newSalad);

                InfoAboutSalad.ShowAllSaladsInfo();
            }
            else
            {
                while (existingSalad != null)
                {
                    Console.WriteLine("Name with this name was used. Try again!");
                    Console.WriteLine("Input salad name:");
                    newNameSalad = Helpers.GetValidStringValue();
                    existingSalad = saladService.GetByName(salads, newNameSalad);

                    if (existingSalad == null)
                    {
                        Salad newSalad = CreateNewSalad(newNameSalad);
                        InfoAboutSalad.ShowNewSaladInfo(newSalad);

                        InfoAboutSalad.ShowAllSaladsInfo();
                    }
                }
            }
        }

        public static void HandleUserChoise(int optionChoice)
        {
            switch ((Choices)optionChoice)
            {
                case Choices.ChoiceOurSalad:
                    HandleUserChoiseOurSalad();
                    Back();
                    return;

                case Choices.CreateOwnSalad:
                    HandleUserChoiseCreateNewSalad();
                    Back();
                    return;

                case Choices.Exit:
                    System.Environment.Exit(0);
                    return;

                default:
                    {
                        Console.WriteLine("MISTAKE! Try again, please!");
                    }
                    break;
            }
        }
    }
}
