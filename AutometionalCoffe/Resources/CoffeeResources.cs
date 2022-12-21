using System.Collections.ObjectModel;
using AutometionalCoffee.Model;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Diagnostics;
using Windows.Storage;
using System.Threading.Tasks;

namespace AutometionalCoffe.Resources
{
    public class CoffeeResource
    {
        public static ObservableCollection<CoffeeConfigModel> CoffeeList { get; set; }
        public async static Task<ObservableCollection<CoffeeConfigModel>> LoadCoffeeList()
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/coffee.txt"));
            using (var inputStream = await file.OpenReadAsync())
            using (var classicStream = inputStream.AsStreamForRead())
            using (var streamReader = new StreamReader(classicStream))
            {
                string json = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<ObservableCollection<CoffeeConfigModel>>(json);
            }
        }
    }
}
