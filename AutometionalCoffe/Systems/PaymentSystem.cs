using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;

namespace AutometionalCoffee.Systems
{
    public class PaymentSystem
    {
        private int _balance;
        
        public event PropertyChangedEventHandler PropertyChanged;

        public void AddCoin(int coin)
        {
            _balance += coin;
        }
        
        public bool PayForCoffee(int coffeeValue)
        {
            var isCanePay =  _balance - coffeeValue >= 0;
            if (isCanePay)
            {
                _balance -= coffeeValue;    
                return isCanePay;
            }
            return isCanePay;
        }

        public int GetBance()
        {
            return _balance;    
        }

        public int GetChange()
        {
            var resalt = _balance;
            _balance = 0;
            return resalt; 
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    } 
}
