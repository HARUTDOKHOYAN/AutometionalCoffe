using System.Runtime.CompilerServices;
using AutometionalCoffee.Model;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using System.ComponentModel;
using Windows.UI;
using System;

namespace AutometionalCoffe.ViewModel
{
    public class ChocolateViewModel : INotifyPropertyChanged
    {
        private SolidColorBrush _fillChocolateArrowColor = new SolidColorBrush();
        private SolidColorBrush _chocolateWarmingUpSensor = new SolidColorBrush();

        public ChocolateViewModel()
        {
            ChocolateContainer = new ContainerViewModel(100);
            FillChocolateArrowColor.Color = Color.FromArgb(255, 0, 0, 0);
            ChocolateWarmingUpSensor.Color = Color.FromArgb(255, 255, 0, 0);
        }

        public ContainerViewModel ChocolateContainer { get; set; }

        public SolidColorBrush ChocolateWarmingUpSensor
        {
            get => _chocolateWarmingUpSensor;
            set
            {
                _chocolateWarmingUpSensor = value;
                NotifyPropertyChanged();
            }
        }

        public SolidColorBrush FillChocolateArrowColor
        {
            get => _fillChocolateArrowColor;
            set
            {
                _fillChocolateArrowColor = value;
                NotifyPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public async Task GetChocolate(CoffeeConfigModel config)
        {
            FillChocolateArrowColor.Color = Color.FromArgb(255, 246, 210, 126);
            await ChocolateContainer.GetComponent(config.ChocolatrCount);
            FillChocolateArrowColor.Color = Color.FromArgb(255, 0, 0, 0);
            ChocolateWarmingUpSensor.Color = Color.FromArgb(255, 0, 255, 0);
            await Task.Delay(1000);
            ChocolateWarmingUpSensor.Color = Color.FromArgb(255, 255, 0, 0);
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
