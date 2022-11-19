using AutometionalCoffee.ViewModel;
using Windows.UI.Xaml.Controls; 
using Windows.UI.Xaml;


namespace AutometionalCoffe.View
{
    public sealed partial class CoffeeWorkView : UserControl
    {
        public CoffeeWorkView()
        {
            this.InitializeComponent();
        }

        public CoffeeWorkViewModel ViewModel
        {
            get { return (CoffeeWorkViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("MyProperty", typeof(CoffeeWorkViewModel), typeof(CoffeeWorkView), new PropertyMetadata(null));


    }
}
