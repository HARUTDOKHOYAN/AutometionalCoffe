using AutometionalCoffe.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;


namespace AutometionalCoffe.View.Control
{
    public sealed partial class WaterHeatingControl : UserControl
    {
        public WaterHeatingControl()
        {
            this.InitializeComponent();
            Loaded +=WaterHeatingControl_Loaded;
        }

        private void WaterHeatingControl_Loaded(object sender, RoutedEventArgs e)
        {
            
            Unloaded +=WaterHeatingControl_Unloaded;
        }

        private void WaterHeatingControl_Unloaded(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        public WaterHeatingViewModel ViewModel
        {
            get { return (WaterHeatingViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(WaterHeatingViewModel), typeof(WaterHeatingControl), new PropertyMetadata(null));


    }
}
