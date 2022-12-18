using AutometionalCoffe.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;


namespace AutometionalCoffe.View.Control
{
    public sealed partial class ChocolateControl : UserControl
    {
        public ChocolateControl()
        {
            this.InitializeComponent();
            ViewModel = new ChocolateViewModel();
        }

        public ChocolateViewModel ViewModel
        {
            get { return (ChocolateViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(ChocolateViewModel), typeof(ChocolateControl), new PropertyMetadata(null));


    }
}
