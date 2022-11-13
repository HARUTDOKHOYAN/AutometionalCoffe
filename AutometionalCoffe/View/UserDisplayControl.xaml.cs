using AutometionalCoffee.ViewModel;
using AutometionalCoffee.Model;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;


namespace AutometionalCoffee
{
    public sealed partial class UserDisplayControl : UserControl
    {
        public UserDisplayControl()
        {
            this.InitializeComponent();
        }
        public delegate void CoffeeHandler(CoffeConfigModel sender);
        public event CoffeeHandler CoffeeAdd;

        public UserDisplayViewModel ViewModel
        {
            get { return (UserDisplayViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(UserDisplayViewModel), typeof(UserDisplayControl), new PropertyMetadata(null));

        private void CoffeeButton_Click(object sender, RoutedEventArgs e)
        {
            var coffeeItem = (sender as Button).DataContext as CoffeConfigModel;
            coffeeItem.SugarValue = ViewModel.UserImputParametrsViewModel.SugarValue;
            CoffeeAdd.Invoke(coffeeItem); 
        }
    }
}
