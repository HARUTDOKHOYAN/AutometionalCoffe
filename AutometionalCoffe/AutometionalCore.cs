using AutometionalCoffee.ViewModel;
using AutometionalCoffe.ViewModel;
using AutometionalCoffee.Systems;
using AutometionalCoffee.Model;
using System.Threading.Tasks;

namespace AutometionalCoffee
{
    public class AutometionalCore
    {
        private PaymentSystem _paymentSystem;
        public AutometionalCore()
        {
            InitializeComponent();
        }
        public UserDisplayViewModel UserDisplayViewModel { get; set; }

        public CoffeeWorkViewModel CoffeeWorkViewModel { get; set; }

        public CoffeeMachineDisplayViewModel CoffeeMachineDisplayViewModel { get; set; }



        public async Task CoffeeRegister(CoffeeConfigModel sender)
        {
            if (!_paymentSystem.PayForCoffee(sender.Cost))
                return;
            UserDisplayViewModel.ReturnChange();

            CoffeeMachineDisplayViewModel.SetMachinWorkingState();

            foreach (var action in sender.CoffeeActions)
            {
                await CoffeeWorkViewModel.ExistActions[action].Invoke(sender);
            }
            CoffeeMachineDisplayViewModel.SetCoffeeIsRedyState();
            await Task.Delay(5000);
            CoffeeMachineDisplayViewModel.SetMachinAwaitState();

        }

        private void InitializeComponent()
        {
            _paymentSystem = new PaymentSystem();
            UserDisplayViewModel = new UserDisplayViewModel(_paymentSystem);
            CoffeeWorkViewModel = new CoffeeWorkViewModel();
            CoffeeMachineDisplayViewModel = new CoffeeMachineDisplayViewModel();
        }
    }
}
