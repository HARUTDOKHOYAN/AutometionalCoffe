using System.Collections.Generic;
using Newtonsoft.Json;

namespace AutometionalCoffee.Model
{
    public class CoffeeConfigModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("cost")]
        public int Cost { get; set; }
        [JsonProperty("water_count")]
        public int WaterCount { get; set; }
        [JsonIgnore]
        public int SugarValue { get; set; }
        [JsonProperty("coffee_count")]
        public int CoffeeCount { get; set; }
        [JsonProperty("milk_count")]
        public int MilkCount { get; set; }
        [JsonProperty("chocoolatr_count")]
        public int ChocolatrCount { get; set; }
        [JsonProperty("coffee_actioons")]
        public List<string> CoffeeActions { get; set; }
    }
}
