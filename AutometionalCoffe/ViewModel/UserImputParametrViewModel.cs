using System.Runtime.CompilerServices;
using AutometionalCoffee.Systems;
using System.ComponentModel;
using System;

namespace AutometionalCoffe.ViewModel
{
    public class UserImputParametrsViewModel:INotifyPropertyChanged
    {
        private PaymentSystem _payment;
        private int _balance;
        private int _change;
        private int _sugarValue;
        public UserImputParametrsViewModel(PaymentSystem payment)
        {
            _payment = payment;
            SugarValue = 3;
        }

        public event PropertyChangedEventHandler PropertyChanged;

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

        public void AddCoin(int coin)
        {
            _payment.AddCoin(coin);
            Balance = _payment.GetBance();
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
