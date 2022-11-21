using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;


namespace AutometionalCoffe.View.Control
{
    public sealed partial class SensorControl : UserControl
    {
        public SensorControl()
        {
            this.InitializeComponent();
        }



        public string SensorName
        {
            get { return (string)GetValue(SensorNameProperty); }
            set { SetValue(SensorNameProperty, value); }
        }

        public static readonly DependencyProperty SensorNameProperty =
            DependencyProperty.Register("SensorName", typeof(string), typeof(SensorControl), new PropertyMetadata(0));



        public SolidColorBrush SensorColor
        {
            get { return (SolidColorBrush)GetValue(SensorColorProperty); }
            set { SetValue(SensorColorProperty, value); }
        }

        public static readonly DependencyProperty SensorColorProperty =
            DependencyProperty.Register("SensorColor", typeof(SolidColorBrush), typeof(SensorControl), new PropertyMetadata(0));


    }
}
