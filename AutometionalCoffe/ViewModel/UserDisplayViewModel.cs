using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using AutometionalCoffe.Resources;
using AutometionalCoffe.ViewModel;
using AutometionalCoffee.Systems;
using AutometionalCoffee.Model;
using System.ComponentModel;
using System;

namespace AutometionalCoffee.ViewModel
{
    public class UserDisplayViewModel : INotifyPropertyChanged
    {
        private readonly PaymentSystem _paymentSystem;
        private ObservableCollection<CoffeeConfigModel> _coffeeList;

        public UserDisplayViewModel(PaymentSystem paymentSystem)
        {
            _paymentSystem = paymentSystem;
            CoffeeList = CoffeeResource.CoffeeList
            UserImputParametrsViewModel = new UserImputParametrsViewModel(_paymentSystem);
        }

        public ObservableCollection<CoffeeConfigModel> CoffeeList
        {
            get { return _coffeeList; }
            set
            {
                _coffeeList = value;
                NotifyPropertyChanged();
            }
        }

        public UserImputParametrsViewModel UserImputParametrsViewModel { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void SetCoffeeParametrs(CoffeeConfigModel config)
        {
            UserImputParametrsViewModel.Balance = config.Cost;
            UserImputParametrsViewModel.CoffeeName = config.Name;
        }

        public void ReturnChange()
        {
            UserImputParametrsViewModel.Change =  _paymentSystem.GetChange();
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
