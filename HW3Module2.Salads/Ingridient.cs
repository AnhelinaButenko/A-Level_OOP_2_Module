using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3Module2.Salads
{
    public abstract class Ingridient
    {
        public Ingridient()
        {
        }

        public Ingridient(string name, double callories, double weight)
        {
            Name = name;
            Callories = callories;
            Weight = weight;
        }

        public abstract string Name { get; set; }

        public abstract double Callories { get; set; }

        public abstract double Weight { get; set; }
    }
}
