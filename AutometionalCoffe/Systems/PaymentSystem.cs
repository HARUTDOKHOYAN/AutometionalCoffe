using System.ComponentModel;

namespace AutometionalCoffee.Systems
{
    public class PaymentSystem
    {
        private int _balance;
        private const int defoltBalance = 0;

        public void AddCoin(int coin)
        {
            _balance += coin;
        }

        public bool PayForCoffee(int coffeeValue)
        {
            var isCanePay = _balance - coffeeValue >= 0;
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
            _balance = defoltBalance;
            return resalt;
        }
    }
}
