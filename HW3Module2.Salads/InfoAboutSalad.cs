using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3Module2.Salads
{
    public class InfoAboutSalad
    {
        public static void ShowNewSaladInfo(Salad newSalad)
        {
            Console.WriteLine("Our salad is: ");
            foreach (var ingridient in newSalad.Ingridients)
            {
                Console.WriteLine($"Name salad: {ingridient.Name}, Callories: {ingridient.Callories}, Weight: {ingridient.Weight}");
            }
        }

        public static void ShowAllSaladsInfo()
        {
            List<Salad> salads = SaladDb.GetSaladsList();

            Console.WriteLine("New list Salad is: ");
            foreach (Salad salad in salads)
            {
                Console.WriteLine(salad.Name);

                foreach (Ingridient ingridient in salad.Ingridients)
                {
                    Console.WriteLine($"Name salad: {ingridient.Name}, Callories: {ingridient.Callories}, Weight: {ingridient.Weight}");
                }
            }
        }
    }
}
