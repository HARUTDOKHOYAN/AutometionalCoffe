using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

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

        // Using a DependencyProperty as the backing store for SensorName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SensorNameProperty =
            DependencyProperty.Register("SensorName", typeof(string), typeof(SensorControl), new PropertyMetadata(0));



        public SolidColorBrush SensorColor
        {
            get { return (SolidColorBrush)GetValue(SensorColorProperty); }
            set { SetValue(SensorColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SensorColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SensorColorProperty =
            DependencyProperty.Register("SensorColor", typeof(SolidColorBrush), typeof(SensorControl), new PropertyMetadata(0));


    }
}
