using AutometionalCoffee.ViewModel;
using AutometionalCoffee.Systems;
using AutometionalCoffee.Model;

namespace AutometionalCoffee
{
    public class AutometionalCore 
    {
        private  PaymentSystem _paymentSystem;
        public AutometionalCore()
        {
            InitializeComponent();
        }
        public UserDisplayViewModel UserDisplayViewModel { get; set; }
        
        public void CoffeeRegister(CoffeConfigModel sender)
        {
            if (!_paymentSystem.PayForCoffee(sender.Cost))
                return;
            UserDisplayViewModel.ReturnChange();
        }

        private void InitializeComponent()
        {
            _paymentSystem = new PaymentSystem();
            UserDisplayViewModel = new UserDisplayViewModel(_paymentSystem);
        }
    }
}
