using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.UI.Xaml.Media;
using Windows.UI;
using System;

namespace AutometionalCoffe.ViewModel
{
    public class ContainerViewModel : INotifyPropertyChanged
    {
        private int _containerCount;
        private SolidColorBrush _containerWorkSensorColor = new SolidColorBrush();

        public ContainerViewModel(int containerControl)
        {
            ContainerCount = containerControl;
            ContainerWorkSensorColor.Color = Color.FromArgb(255, 255, 0, 0);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public SolidColorBrush ContainerWorkSensorColor
        {
            get { return _containerWorkSensorColor; }
            set
            {
                _containerWorkSensorColor = value;
                NotifyPropertyChanged();
            }
        }

        public int ContainerCount
        {
            get { return _containerCount; }
            set
            {
                _containerCount = value;
                NotifyPropertyChanged();
            }
        }

        public async Task GetComponent(int config)
        {
            ContainerWorkSensorColor.Color = Color.FromArgb(255, 0, 255, 0);
            await Task.Delay(1000);
            ContainerCount -= config;
            ContainerWorkSensorColor.Color = Color.FromArgb(255, 255, 0, 0);
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
