using AutometionalCoffe.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;


namespace AutometionalCoffe.View
{
    public sealed partial class UserImputParametrControl : UserControl
    {
        public UserImputParametrControl()
        {
            this.InitializeComponent();
            Loaded +=UserDisplayView_Loaded;
        }

        public UserImputParametrsViewModel ViewModel
        {
            get { return (UserImputParametrsViewModel)GetValue(BalanceProperty); }
            set { SetValue(BalanceProperty, value); }
        }

        public static readonly DependencyProperty BalanceProperty =
            DependencyProperty.Register("ViewModel", typeof(UserImputParametrsViewModel), typeof(UserImputParametrControl), new PropertyMetadata(null));

        private void UserDisplayView_Loaded(object sender, RoutedEventArgs e)
        {
            AddCoinButton.Click +=AddCoinButton_Click;
            Unloaded+=UserDisplayView_Unloaded;
        }

        private void UserDisplayView_Unloaded(object sender, RoutedEventArgs e)
        {
            AddCoinButton.Click -=AddCoinButton_Click; 
        }

        private void AddCoinButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddCoin(int.Parse(CoinCount.Text));
        }

    


    }
}
