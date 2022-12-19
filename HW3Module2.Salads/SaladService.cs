using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3Module2.Salads
{
    public interface ISaladService
    {
        Salad Sort(Salad salad);
        double GetCallories(Salad salad);
        Salad GetByName(List<Salad> salads, string name);
    }

    public class SaladService : ISaladService
    {
        public double GetCallories(Salad salad)
        {
            return salad.Callories;
        }

        public Salad Sort(Salad salad)
        {
            salad.Ingridients = salad.Ingridients.OrderBy(x => x.Callories).ToList();
            return salad;
        }

        public Salad GetByName(List<Salad> salads, string name)
        {
            return salads.FirstOrDefault(o => o.Name == name);
        }
    }
}
