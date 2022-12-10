using System.Runtime.CompilerServices;
using AutometionalCoffee.Model;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.UI.Xaml.Media;
using Windows.UI;
using System;

namespace AutometionalCoffe.ViewModel
{

    public class CoffeeGrindViewModel : INotifyPropertyChanged
    {
        private string _coffeeName;
        private int _coffeeContainerCount;
        private SolidColorBrush _grindSensorColor = new SolidColorBrush();
        private SolidColorBrush _coffeeArrowColoe = new SolidColorBrush();


        public CoffeeGrindViewModel()
        {
            CoffeeContainerCount = 400;
            CoffeeName = "None";
            CoffeeArrowColor.Color = Color.FromArgb(255, 0, 0, 0);
            GrindSensorColor.Color = Color.FromArgb(255, 255, 0, 0);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public SolidColorBrush GrindSensorColor
        {
            get => _grindSensorColor;
            set
            {
                _grindSensorColor = value;
                NotifyPropertyChanged();
            }
        }
        public SolidColorBrush CoffeeArrowColor
        {
            get => _coffeeArrowColoe;
            set
            {
                _coffeeArrowColoe = value;
                NotifyPropertyChanged();
            }
        }

        public int CoffeeContainerCount
        {
            get { return _coffeeContainerCount; }
            set
            {
                _coffeeContainerCount = value;
                NotifyPropertyChanged();
            }
        }

        public string CoffeeName
        {
            get { return _coffeeName; }
            set
            {
                _coffeeName = value;
                NotifyPropertyChanged();
            }
        }

        public async Task GetCoffee(CoffeeConfigModel component)
        {
            CoffeeName= component.Name;
            CoffeeContainerCount -= component.CoffeeCount;
            CoffeeArrowColor.Color = Color.FromArgb(255, 200, 23, 23);
            await Task.Delay(component.CoffeeCount*300);
            CoffeeArrowColor.Color = Color.FromArgb(255, 0, 0, 0);
            GrindSensorColor.Color = Color.FromArgb(255, 0, 255, 0);
            await Task.Delay(2500);
            GrindSensorColor.Color = Color.FromArgb(255, 255, 0, 0);
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
