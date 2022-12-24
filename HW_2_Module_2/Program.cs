using System.Collections.Generic;

namespace HW2Module2.GadgetStore
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService productService = new ProductService();

            var products = productService.GetProducts();

            foreach (var item in products)
            {
                Console.WriteLine($"Id: {item.Id}, Description: {item.Description}, Model: {item.Model}, Price: {item.Price} ");
            }

            Console.WriteLine("How many products do you want to buy: ");

            var userInput = GetProductsinBasket();

            productService.SelectProducts(userInput);

            Console.WriteLine("Do you want to remove something from the cart? Please, input yes or not. ");
            string option = Console.ReadLine();

            if (option == "yes")
            {
                Console.WriteLine("How many products do you want to cancel: ");

                var userInputForUpdate = GetProductsinBasket();

                productService.ReturnProducts(userInputForUpdate);  
            }

            NotificationService notificationService = new NotificationService();

            notificationService.Notify(GetInfoUser());
        }

        public static UserInformation GetInfoUser()
        {
            Console.WriteLine($"Your data: ");

            Console.WriteLine($"Enter name: ");
            var name = Console.ReadLine();

            Console.WriteLine($"Enter last name: ");
            var lastName = Console.ReadLine();

            Console.WriteLine($"Enter addres: ");
            var addres = Console.ReadLine();

            Console.WriteLine($"Enter email: ");
            var email = Console.ReadLine();

            Console.WriteLine($"Enter phone: ");
            var phone = Console.ReadLine();

            UserInformation userInformation = new UserInformation
            {
                Name = name,
                LastName = lastName,
                Address = addres,
                Email = email,
                Phone = phone
            };

            return userInformation;
        }

        public static Dictionary<int, int> GetProductsinBasket()
        {
            var productsinBasket = new Dictionary<int, int>();
            int productsQuantity = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < productsQuantity; i++)
            {
                Console.WriteLine("Input item Id: ");
                int productid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                productsinBasket.Add(productid, quantity);
            }

            return productsinBasket;
        }
    }
}