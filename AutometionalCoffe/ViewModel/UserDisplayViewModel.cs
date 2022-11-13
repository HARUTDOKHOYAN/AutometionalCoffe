using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using AutometionalCoffe.ViewModel;
using AutometionalCoffee.Systems;
using AutometionalCoffe.Resources;
using AutometionalCoffee.Model;
using System.ComponentModel;
using System;

namespace AutometionalCoffee.ViewModel
{
    public class UserDisplayViewModel : INotifyPropertyChanged
    {
        private readonly PaymentSystem _paymentSystem;
        private ObservableCollection<CoffeConfigModel> _coffeeList;

        public UserDisplayViewModel(PaymentSystem paymentSystem)
        {
            CoffeeList = CoffeeResources.CoffeeList;
            _paymentSystem = paymentSystem;
            UserImputParametrsViewModel = new UserImputParametrsViewModel(_paymentSystem);
        }
        public ObservableCollection<CoffeConfigModel> CoffeeList
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
