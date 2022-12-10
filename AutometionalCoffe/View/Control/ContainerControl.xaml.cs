using AutometionalCoffe.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;


namespace AutometionalCoffe.View.Control
{
    public sealed partial class ContainerControl : UserControl
    {
        public ContainerControl()
        {
            this.InitializeComponent();
        }

        public ContainerViewModel ViewModel
        {
            get { return (ContainerViewModel)GetValue(VIewModelProperty); }
            set { SetValue(VIewModelProperty, value); }
        }

        public static readonly DependencyProperty VIewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(int), typeof(ContainerControl), new PropertyMetadata(null));



        public string ContainerName
        {
            get { return (string)GetValue(ContainerNameProperty); }
            set { SetValue(ContainerNameProperty, value); }
        }

        public static readonly DependencyProperty ContainerNameProperty =
            DependencyProperty.Register("ContainerName", typeof(string), typeof(ContainerControl), new PropertyMetadata(0));



    }
}
