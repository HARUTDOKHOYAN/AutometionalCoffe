using AutometionalCoffee.Model;
using Windows.UI.Xaml.Controls;


namespace AutometionalCoffee
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded +=MainPage_Loaded;
            ViewModel = new AutometionalCore();
            this.DataContext = ViewModel;
        }
        public AutometionalCore ViewModel { get; set; }

        private void MainPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            CoffeeConfig.CoffeeAdd +=CoffeeConfig_CoffeeAdd;
            Unloaded+=MainPage_Unloaded;
        }

        private void MainPage_Unloaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            CoffeeConfig.CoffeeAdd-=CoffeeConfig_CoffeeAdd;
        }


        private void CoffeeConfig_CoffeeAdd(CoffeConfigModel sender)
        {
            ViewModel.CoffeeRegister(sender);
        }


    }
}
