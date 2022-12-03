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
            get { return (ContainerViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(ContainerViewModel), typeof(ContainerControl), new PropertyMetadata(null));


    }
}
