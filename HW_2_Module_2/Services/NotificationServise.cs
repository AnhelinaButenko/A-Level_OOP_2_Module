using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2Module2.GadgetStore
{
    class NotificationService
    {
        public void Notify(List<Product> products)
        {
            foreach (var item in products)
            {
                Console.WriteLine($"Id: {item.Id}, Description: {item.Description}, Model: {item.Model}, Price: {item.Price}, Quantity: {item.Quantity}");
            }

            Console.WriteLine("_________");
            var sum = products.Sum(p => p.Price * p.Quantity);

            Console.WriteLine($"Price: {sum}");
        }

        public int Notify(UserInformation userInformation)
        {
            Console.WriteLine($"{userInformation.Name}, {userInformation.LastName}, Address: {userInformation.Address}, Phone: {userInformation.Phone}, Email: {userInformation.Email}");

            Random rnd = new Random();

            int specialNumber = rnd.Next(50000, 100000);

            Console.WriteLine($"Your order number: {specialNumber} \nYour order will be with you within 3-5 days. Have a good day! =)");

            return specialNumber;
        }

        public void NotifyError(Product product)
        {
            Console.WriteLine($"There are more items to delete than there are in the basket Id: {product.Id} {product.Model}");
        }
    }
}
