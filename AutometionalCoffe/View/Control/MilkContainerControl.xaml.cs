using AutometionalCoffe.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;


namespace AutometionalCoffe.View.Control
{
    public sealed partial class MilkContainerControl : UserControl
    {
        public MilkContainerControl()
        {
            this.InitializeComponent();
        }

        public MilkContainerViewModel ViewModel
        {
            get { return (MilkContainerViewModel)GetValue(VIewModelProperty); }
            set { SetValue(VIewModelProperty, value); }
        }

        public static readonly DependencyProperty VIewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(int), typeof(MilkContainerControl), new PropertyMetadata(null));


    }
}
