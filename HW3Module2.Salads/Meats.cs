using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3Module2.Salads
{
    public class Meats : Ingridient
    {
        public Meats()
        {
        }

        public Meats(string name, double callories, double weight) : base(name, callories, weight)
        {
        }

        public override string Name { get; set; }
        public override double Callories { get; set; }
        public override double Weight { get; set; }
    }
}
