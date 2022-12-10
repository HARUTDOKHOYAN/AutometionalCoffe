using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutometionalCoffee.Model;

namespace AutometionalCoffe.Resources
{
    public class CoffeeResources
    {
        public static ObservableCollection<CoffeeConfigModel> CoffeeList = new ObservableCollection<CoffeeConfigModel>()
        {
                new CoffeeConfigModel
                {
                    Name = "Coffee1", 
                    Cost = 150,
                    CoffeeActions = new List<string>{ "get_hotwater" , "get_componet" , "get_milk" , "get_sugar" },
                    CoffeeCount = 8,
                    MilkCount= 18,
                    WaterCount= 200,
                },
                new CoffeeConfigModel
                {
                    Name = "Coffee2", 
                    Cost = 200
                },
                new CoffeeConfigModel
                {
                    Name = "Coffee3", 
                    Cost = 100
                },
                new CoffeeConfigModel
                {
                    Name = "Coffee4", 
                    Cost = 250
                },
                new CoffeeConfigModel
                {
                    Name = "Coffee5", 
                    Cost = 150
                },
                new CoffeeConfigModel
                {
                    Name = "Coffee6",
                    Cost = 300
                },
                new CoffeeConfigModel
                {
                    Name = "Coffee7",
                    Cost = 100
                },
                new CoffeeConfigModel
                {
                    Name = "Coffee8",
                    Cost = 200
                },
        };
    }
}
