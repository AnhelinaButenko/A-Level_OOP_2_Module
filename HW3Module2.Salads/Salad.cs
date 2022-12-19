using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3Module2.Salads
{
    public class Salad
    {
        public List<Ingridient> Ingridients { get; set; } = new List<Ingridient>();

        public string Name { get; set; }

        public double Callories
        {
            get
            {
                double sumSaladCallories = 0;
                foreach (var ingridient in Ingridients)
                {
                    double callotiesOneIngridient = ingridient.Callories + ingridient.Weight / 100;
                    sumSaladCallories += callotiesOneIngridient;
                }
                return sumSaladCallories;
            }
        }

        public double Weight => Ingridients.Sum(x => x.Weight);
    }
}
