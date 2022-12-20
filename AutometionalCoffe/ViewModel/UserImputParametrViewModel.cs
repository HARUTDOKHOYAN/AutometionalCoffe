using System.Runtime.CompilerServices;
using AutometionalCoffee.Systems;
using AutometionalCoffe.Systems;
using System.ComponentModel;
using Windows.UI.Xaml.Media;
using Windows.UI;
using System;

namespace AutometionalCoffe.ViewModel
{
    public class UserImputParametrsViewModel : INotifyPropertyChanged
    {
        private SensorSystem _sensorSystem = SensorSystem.Instens;
        private SolidColorBrush _coinSensorColoe;
        private PaymentSystem _payment;
        private string _coffeeName;
        private int _sugarValue;
        private int _balance;
        private int _change;

        public UserImputParametrsViewModel(PaymentSystem payment)
        {
            _payment = payment;
            CoinSensorColor = new SolidColorBrush();
            CoinSensorColor.Color =  Color.FromArgb(255, 255, 255, 0);
            SugarValue = 3;
            _coffeeName = "Not selected";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string CoffeeName
        {
            get { return _coffeeName; }
            set
            {
                _coffeeName = value;
                NotifyPropertyChanged();
            }
        }

        public int Balance
        {
            get { return _balance; }
            set
            {
                _balance = value;
                NotifyPropertyChanged();
            }
        }

        public int Change
        {
            get { return _change; }
            set
            {
                _change = value;
                Balance = 0;
                CoinSensorColor.Color =  Color.FromArgb(255, 255, 255, 0);
                NotifyPropertyChanged();
            }
        }

        public int SugarValue
        {
            get { return _sugarValue; }
            set
            {
                _sugarValue = value;
                NotifyPropertyChanged();
            }
        }
        public SolidColorBrush CoinSensorColor
        {
            get => _coinSensorColoe;
            set
            {
                _coinSensorColoe = value;
                NotifyPropertyChanged();
            }
        }

        public void AddCoin(string coin)
        {
            if (_sensorSystem.CoinSensor(coin))
            {
                _payment.AddCoin(int.Parse(coin));
                CoinSensorColor.Color = Color.FromArgb(255, 0, 255, 0);
            }
            else CoinSensorColor.Color = Color.FromArgb(255, 255, 0, 0);
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
