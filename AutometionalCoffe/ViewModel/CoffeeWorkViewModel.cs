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
        public WaterHeatingViewModel WaterHeatingViewModel { get; set; }
        public ContainerViewModel ContainerViewModel { get; set; }
        public MilkContainerViewModel MilkContainerViewModel { get; set; }


        public CoffeeWorkViewModel()
        {
            WaterHeatingViewModel = new WaterHeatingViewModel();
            ContainerViewModel = new ContainerViewModel();
            MilkContainerViewModel = new MilkContainerViewModel();
            ExistActions = new Dictionary<string, CoffeeAction>
            {
                ["get_hotwater"] = WaterHeatingViewModel.GetHotWater,
                ["get_componet"] = ContainerViewModel.GetComponent
 
            };
        }
    }
}
