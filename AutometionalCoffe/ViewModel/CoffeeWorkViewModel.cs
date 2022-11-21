using AutometionalCoffe.ViewModel;
using System.Collections.Generic;
using AutometionalCoffee.Model;
using System.Threading.Tasks;

namespace AutometionalCoffee.ViewModel
{
    public delegate Task CoffeeAction(CoffeConfigModel config);

    public class CoffeeWorkViewModel
    {
        public Dictionary<string, CoffeeAction> ExistActions { get; set; }
        public WaterHeatingViewModel waterHeatingViewModel { get; set; }


        public CoffeeWorkViewModel()
        {
            waterHeatingViewModel = new WaterHeatingViewModel();
        }
        public void StartCreat()
        {
            var a = waterHeatingViewModel.GetHotWater(200);
        }
    }
}
