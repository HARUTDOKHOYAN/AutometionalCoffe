using AutometionalCoffe.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace AutometionalCoffe.View.Control
{
    public sealed partial class CoffeeGrindControl : UserControl
    {
        public CoffeeGrindControl()
        {
            this.InitializeComponent();
        }

        public CoffeeGrindViewModel ViewModel
        {
            get { return (CoffeeGrindViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(CoffeeGrindViewModel), typeof(CoffeeGrindControl), new PropertyMetadata(null));


    }
}
