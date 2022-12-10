using AutometionalCoffe.ViewModel;
using System.Collections.Generic;
using AutometionalCoffee.Model;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI;

namespace AutometionalCoffee.ViewModel
{
    public delegate Task CoffeeAction(CoffeeConfigModel config);

    public class CoffeeWorkViewModel : INotifyPropertyChanged
    {
        private SolidColorBrush _waterPipelineColor = new SolidColorBrush();
        private SolidColorBrush _sugarPipelineColor = new SolidColorBrush();
        private SolidColorBrush _milkPipelineColor = new SolidColorBrush();
        private SolidColorBrush _coffeeGrindPipelineColor = new SolidColorBrush();


        public CoffeeWorkViewModel()
        {
            InitViewModels();
            InitColors();
            ExistActions = new Dictionary<string, CoffeeAction>
            {
                ["get_hotwater"] = GetHotWater,
                ["get_componet"] = GetCoffee,
                ["get_milk"] = GetMilk,
                ["get_sugar"] = GetSuger
            };
        }

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

        public event PropertyChangedEventHandler PropertyChanged;
        public Dictionary<string, CoffeeAction> ExistActions { get; set; }
        public WaterHeatingViewModel WaterHeatingViewModel { get; set; }
        public CoffeeGrindViewModel CoffeeGrindViewModel { get; set; }
        public ContainerViewModel MilkContainerViewModel { get; set; }
        public ContainerViewModel SugarContainerViewModel { get; set; }

        private void InitColors()
        {
            WaterPipelineColor.Color = Color.FromArgb(255, 0, 0, 0);
            MilkPipelineColor.Color = Color.FromArgb(255, 0, 0, 0);
            SugarPipelineColor.Color = Color.FromArgb(255, 0, 0, 0);
            CoffeeGrindPipelineColor.Color = Color.FromArgb(255, 0, 0, 0);
        }

        private void InitViewModels()
        {
            WaterHeatingViewModel = new WaterHeatingViewModel();
            CoffeeGrindViewModel = new CoffeeGrindViewModel();
            MilkContainerViewModel = new ContainerViewModel(100);
            SugarContainerViewModel = new ContainerViewModel(200);
        }

        private async Task GetHotWater(CoffeeConfigModel config)
        {
            await WaterHeatingViewModel.GetHotWater(config);
            WaterPipelineColor.Color = Color.FromArgb(255, 0, 0, 255);
            await Task.Delay(1000);
            WaterPipelineColor.Color = Color.FromArgb(255, 0, 0, 0);
        }

        private async Task GetCoffee(CoffeeConfigModel config)
        {
            await CoffeeGrindViewModel.GetCoffee(config);
            CoffeeGrindPipelineColor.Color = Color.FromArgb(255, 100, 40, 40);
            await Task.Delay(1000);
            CoffeeGrindPipelineColor.Color = Color.FromArgb(255, 0, 0, 0);
        }

        private async Task GetMilk(CoffeeConfigModel config)
        {
            await MilkContainerViewModel.GetComponent(config);
            MilkPipelineColor.Color = Color.FromArgb(255, 255, 195, 128);
            await Task.Delay(1000);
            MilkPipelineColor.Color = Color.FromArgb(255, 0, 0, 0);
        }

        private async Task GetSuger(CoffeeConfigModel config)
        {
            await SugarContainerViewModel.GetComponent(config);
            SugarPipelineColor.Color = Color.FromArgb(255, 251, 224, 192);
            await Task.Delay(1000);
            SugarPipelineColor.Color = Color.FromArgb(255, 0, 0,0);
        }


        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
