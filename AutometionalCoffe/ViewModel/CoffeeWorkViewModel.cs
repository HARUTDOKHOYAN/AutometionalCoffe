using System.Runtime.CompilerServices;
using AutometionalCoffe.ViewModel;
using System.Collections.Generic;
using AutometionalCoffee.Model;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using System.ComponentModel;
using Windows.UI;
using System;

namespace AutometionalCoffee.ViewModel
{
    public delegate Task CoffeeAction(CoffeeConfigModel config);

    public class CoffeeWorkViewModel : INotifyPropertyChanged
    {
        private SolidColorBrush _waterPipelineColor = new SolidColorBrush();
        private SolidColorBrush _sugarPipelineColor = new SolidColorBrush();
        private SolidColorBrush _milkPipelineColor = new SolidColorBrush();
        private SolidColorBrush _coffeeGrindPipelineColor = new SolidColorBrush();
        private SolidColorBrush _chocolatPipelineColor = new SolidColorBrush();

        public CoffeeWorkViewModel()
        {
            InitViewModels();
            InitColors();
            ExistActions = new Dictionary<string, CoffeeAction>
            {
                ["get_hotwater"] = GetHotWater,
                ["get_componet"] = GetCoffee,
                ["get_milk"] = GetMilk,
                ["get_sugar"] = GetSuger,
                ["get_chocolate"] = GetChocolate
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Dictionary<string, CoffeeAction> ExistActions { get; set; }
        public WaterHeatingViewModel WaterHeatingViewModel { get; set; }
        public CoffeeGrindViewModel CoffeeGrindViewModel { get; set; }
        public ContainerViewModel MilkContainerViewModel { get; set; }
        public ContainerViewModel SugarContainerViewModel { get; set; }
        public ChocolateViewModel ChocolateViewModel { get; set; }


        public SolidColorBrush WaterPipelineColor
        {
            get { return _waterPipelineColor; }
            set
            {
                _waterPipelineColor = value;
                NotifyPropertyChanged();
            }
        }

        public SolidColorBrush SugarPipelineColor
        {
            get { return _sugarPipelineColor; }
            set
            {
                _sugarPipelineColor = value;
                NotifyPropertyChanged();
            }
        }

        public SolidColorBrush ChocoladPipelineColor
        {
            get { return _chocolatPipelineColor; }
            set
            {
                _chocolatPipelineColor = value;
                NotifyPropertyChanged();
            }
        }

        public SolidColorBrush CoffeeGrindPipelineColor
        {
            get { return _coffeeGrindPipelineColor; }
            set
            {
                _coffeeGrindPipelineColor = value;
                NotifyPropertyChanged();
            }
        }

        public SolidColorBrush MilkPipelineColor
        {
            get { return _milkPipelineColor; }
            set
            {
                _milkPipelineColor = value;
                NotifyPropertyChanged();
            }
        }


        private void InitColors()
        {
            WaterPipelineColor.Color = Color.FromArgb(255, 0, 0, 0);
            MilkPipelineColor.Color = Color.FromArgb(255, 0, 0, 0);
            SugarPipelineColor.Color = Color.FromArgb(255, 0, 0, 0);
            CoffeeGrindPipelineColor.Color = Color.FromArgb(255, 0, 0, 0);
            ChocoladPipelineColor.Color = Color.FromArgb(255, 0, 0, 0);
        }

        private void InitViewModels()
        {
            WaterHeatingViewModel = new WaterHeatingViewModel();
            CoffeeGrindViewModel = new CoffeeGrindViewModel();
            MilkContainerViewModel = new ContainerViewModel(100);
            SugarContainerViewModel = new ContainerViewModel(200);
            ChocolateViewModel = new ChocolateViewModel();
        }

        private async Task GetHotWater(CoffeeConfigModel config)
        {
            WaterPipelineColor.Color = Color.FromArgb(255, 0, 0, 255);
            await WaterHeatingViewModel.GetHotWater(config);
            WaterPipelineColor.Color = Color.FromArgb(255, 0, 0, 0);
        }

        private async Task GetCoffee(CoffeeConfigModel config)
        {
            await CoffeeGrindViewModel.GetCoffee(config);
            CoffeeGrindPipelineColor.Color = Color.FromArgb(255, 100, 40, 40);
            await Task.Delay(1500);
            CoffeeGrindPipelineColor.Color = Color.FromArgb(255, 0, 0, 0);
        }

        private async Task GetMilk(CoffeeConfigModel config)
        {
            await MilkContainerViewModel.GetComponent(config.MilkCount);
            MilkPipelineColor.Color = Color.FromArgb(255, 255, 195, 128);
            await Task.Delay(1500);
            MilkPipelineColor.Color = Color.FromArgb(255, 0, 0, 0);
        }

        private async Task GetSuger(CoffeeConfigModel config)
        {
            await SugarContainerViewModel.GetComponent(config.SugarValue);
            SugarPipelineColor.Color = Color.FromArgb(255, 251, 224, 192);
            await Task.Delay(1500);
            SugarPipelineColor.Color = Color.FromArgb(255, 0, 0, 0);
        }

        private async Task GetChocolate(CoffeeConfigModel config)
        {
            await ChocolateViewModel.GetChocolate(config);
            ChocoladPipelineColor.Color = Color.FromArgb(255, 246, 210, 126);
            await Task.Delay(1500);
            ChocoladPipelineColor.Color = Color.FromArgb(255, 0, 0, 0);
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
