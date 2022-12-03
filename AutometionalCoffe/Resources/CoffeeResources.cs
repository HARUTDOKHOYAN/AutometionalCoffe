using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutometionalCoffee.Model;

namespace AutometionalCoffe.Resources
{
    public class CoffeeResources
    {
        public static ObservableCollection<CoffeConfigModel> CoffeeList = new ObservableCollection<CoffeConfigModel>()
        {
                new CoffeConfigModel
                {
                    Name = "Coffee1", 
                    Cost = 150,
                    CoffeeActions = new List<string>{ "get_hotwater" , "get_componet" },
                    CoffeeCount = 8,
                    WaterCount= 200,
                },
                new CoffeConfigModel
                {
                    Name = "Coffee2", 
                    Cost = 200
                },
                new CoffeConfigModel
                {
                    Name = "Coffee3", 
                    Cost = 100
                },
                new CoffeConfigModel
                {
                    Name = "Coffee4", 
                    Cost = 250
                },
                new CoffeConfigModel
                {
                    Name = "Coffee5", 
                    Cost = 150
                },
                new CoffeConfigModel
                {
                    Name = "Coffee6",
                    Cost = 300
                },
                new CoffeConfigModel
                {
                    Name = "Coffee7",
                    Cost = 100
                },
                new CoffeConfigModel
                {
                    Name = "Coffee8",
                    Cost = 200
                },
        };
    }
}
