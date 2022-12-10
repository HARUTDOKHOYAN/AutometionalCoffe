using AutometionalCoffee.ViewModel;
using AutometionalCoffee.Model;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;


namespace AutometionalCoffe.View.Control
{
    public sealed partial class UserDisplayView : UserControl
    {
        private CoffeeConfigModel config;
        public UserDisplayView()
        {
            this.InitializeComponent();
            Loaded +=UserDisplayView_Loaded;
        }



        public delegate void CoffeeHandler(CoffeeConfigModel sender);
        public event CoffeeHandler CoffeeAdd;

        public UserDisplayViewModel ViewModel
        {
            get { return (UserDisplayViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(UserDisplayViewModel), typeof(UserDisplayView), new PropertyMetadata(null));

        private void CoffeeButton_Click(object sender, RoutedEventArgs e)
        {
            config = (sender as Button).DataContext as CoffeeConfigModel;
            ViewModel.SetCoffeeParametrs(config);
        }

        private void GetCoinButton_Click(object sender, RoutedEventArgs e)
        {
            config.SugarValue = ViewModel.UserImputParametrsViewModel.SugarValue;
            CoffeeAdd.Invoke(config);
        }
        private void UserDisplayView_Loaded(object sender, RoutedEventArgs e)
        {
            GetCoinButton.Click +=GetCoinButton_Click;
            Unloaded +=UserDisplayView_Unloaded;
        }

        private void UserDisplayView_Unloaded(object sender, RoutedEventArgs e)
        {
            GetCoinButton.Click -=GetCoinButton_Click;
        }


    }
}
