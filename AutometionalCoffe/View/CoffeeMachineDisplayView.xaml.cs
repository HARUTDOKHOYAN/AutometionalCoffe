using AutometionalCoffe.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;


namespace AutometionalCoffe.View
{
    public sealed partial class CoffeeMachineDisplayView : UserControl
    {
        public CoffeeMachineDisplayView()
        {
            this.InitializeComponent();
        }



        public CoffeeMachineDisplayViewModel ViewModel
        {
            get { return (CoffeeMachineDisplayViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register(nameof(ViewModel), typeof(CoffeeMachineDisplayViewModel), typeof(CoffeeMachineDisplayView), new PropertyMetadata(null));


    }
}
