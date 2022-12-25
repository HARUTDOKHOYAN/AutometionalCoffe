using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutometionalCoffe.ViewModel
{
    public class CoffeeMachineDisplayViewModel : INotifyPropertyChanged
    {
        private string _displayText;
        public CoffeeMachineDisplayViewModel()
        {
            SetMachinAwaitState();
        }

        public string DisplayText
        {
            get { return _displayText; }
            set
            {
                _displayText = value;
                NotifyPropertyChanged();
            }
        }


        public void SetMachinAwaitState()
        {
            DisplayText = "Waiting for order";
        }

        public void SetMachinWorkingState()
        {
            DisplayText = "Making Coffee";
        }

        public void SetCoffeeIsRedyState()
        {
            DisplayText = "Coffee is Ready";
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
