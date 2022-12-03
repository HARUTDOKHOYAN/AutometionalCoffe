using System.Collections.Generic;

namespace AutometionalCoffee.Model
{
    public class CoffeConfigModel
    {
        public string Name { get; set; }

        public int Cost { get; set; }

        public int WaterCount { get; set; }

        public int SugarValue { get; set; }

        public int CoffeeCount { get; set; }

        public List<string> CoffeeActions { get; set; }
    }
}
