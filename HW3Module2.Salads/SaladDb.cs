using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3Module2.Salads
{
    public class SaladDb
    {
        private static List<Salad> salads = new List<Salad>()
        {
            new Salad
            {
                Name = "Chicken salad",
                Ingridients = new List<Ingridient>
                {
                    new Meats
                    {
                        Name = "Chicken",
                        Callories = 370,
                        Weight = 200
                    },
                    new Vegetables
                    {
                        Name = "Salad",
                        Callories = 60,
                        Weight = 50
                    },
                    new Souces
                    {
                       Name = "Cheese",
                       Callories = 70,
                       Weight = 20
                    },
                    new Vegetables
                    {
                        Name = "Avocado",
                        Callories = 96,
                        Weight = 60
                    }
                }
            },
            new Salad
            {
                Name = "Salad with red fish",
                Ingridients = new List<Ingridient>
                {
                    new SeaFood
                    {
                        Name = "Red fish",
                        Callories = 370,
                        Weight = 150
                    },
                    new Vegetables
                    {
                        Name = "Salad",
                        Callories = 60,
                        Weight = 80
                    },
                    new Souces
                    {
                       Name = "Sea souse",
                       Callories = 70,
                       Weight = 20
                    },
                    new Vegetables
                    {
                        Name = "Avocado",
                        Callories = 96,
                        Weight = 60
                    },
                    new Vegetables
                    {
                        Name = "Cocumber",
                        Callories = 32,
                        Weight = 120
                    }
                }
            },
            new Salad
            {
                Name = "Caesar",
                Ingridients = new List<Ingridient>
                {
                    new SeaFood
                    {
                        Name = "Chicken",
                        Callories = 210,
                        Weight = 150
                    },
                    new Vegetables
                    {
                        Name = "Salad",
                        Callories = 60,
                        Weight = 100
                    },
                    new Souces
                    {
                       Name = "Caesar",
                       Callories = 70,
                       Weight = 20
                    },
                    new Vegetables
                    {
                        Name = "Tomato",
                        Callories = 32,
                        Weight = 160
                    }
                }
            }
        };

        public static List<Salad> GetSaladsList()
        {
            return salads;
        }
    }
}
