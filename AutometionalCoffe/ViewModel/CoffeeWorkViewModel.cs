using AutometionalCoffee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutometionalCoffee.ViewModel
{
    public delegate Task CoffeeAction(CoffeConfigModel config);

    public class CoffeeWorkViewModel
    {
        public Dictionary<string, CoffeeAction> ExistActions { get; set; }

        public void StartCreat()
        {

        }
    }
}
