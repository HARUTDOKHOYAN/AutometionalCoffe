using System.Runtime.CompilerServices;
using AutometionalCoffe.Systems;
using AutometionalCoffee.Model;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.UI.Xaml.Media;
using Windows.UI;
using System;

namespace AutometionalCoffe.ViewModel
{
    public class WaterHeatingViewModel : INotifyPropertyChanged
    {
        #region Fild
        private SolidColorBrush _waterAmountSensorColor = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        private SolidColorBrush _hotWaterSensorColor = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        private SolidColorBrush _fillWaterArrowColor = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        private SolidColorBrush _waterSensorColor = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        private SolidColorBrush _heaterWorkColor = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        private SolidColorBrush _tempSensorColor = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        private int _hotWaterCount;
        private int _waterCount;
        private int _temp ;
        #endregion

        public WaterHeatingViewModel()
        {
            WaterCount = 1000;
            InitializeComponent();
        }

        #region Prop
        public int HotWaterCount
        {
            get { return _hotWaterCount; }
            set
            {
                _hotWaterCount = value;
                NotifyPropertyChanged();
            }
        }

        public int WaterCount
        {
            get { return _waterCount; }
            set
            {
                _waterCount = value;
                NotifyPropertyChanged();
                SetWaterIndicator();
            }
        }

        public int Temp
        {
            get { return _temp; }
            set
            {
                _temp = value;
                NotifyPropertyChanged();
            }
        }

        public SolidColorBrush WaterSensorColor
        {
            get => _waterSensorColor;
            set
            {
                _waterSensorColor = value;
                NotifyPropertyChanged();
            }
        }

        public SolidColorBrush WaterAmountSensorColor
        {
            get => _waterAmountSensorColor;
            set
            {
                _waterAmountSensorColor = value;
                NotifyPropertyChanged();
            }
        }

        public SolidColorBrush HotWaterSensorColor
        {
            get => _hotWaterSensorColor;
            set
            {
                _hotWaterSensorColor = value;
                NotifyPropertyChanged();
            }
        }

        public SolidColorBrush FillWaterArrowColor
        {
            get => _fillWaterArrowColor;
            set
            {
                _fillWaterArrowColor = value;
                NotifyPropertyChanged();
            }
        }

        public SolidColorBrush HeaterWorkColor
        {
            get => _heaterWorkColor;
            set
            {
                _heaterWorkColor = value;
                NotifyPropertyChanged();
            }
        }

        public SolidColorBrush TempSensorColor
        {
            get => _tempSensorColor;
            set
            {
                _tempSensorColor = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        public  Task GetHotWater(CoffeConfigModel component)
        {
            if (HotWaterCount <= component.WaterCount)
            {
                _ = FillHotTank();
            }
            HotWaterCount -= component.WaterCount;
            return Task.CompletedTask;
        }   

        public event PropertyChangedEventHandler PropertyChanged;

        #region Private Metods

        private void InitializeComponent()
        {
            _ = FillHotTank();
            _ = MonitoringTemp();
        }

        private void SetWaterIndicator()
        {
            if (WaterCount >= 600)
            {
                WaterSensorColor.Color = Color.FromArgb(255, 0, 255, 0);
            }
            else if (WaterCount > 0)
            {
                WaterSensorColor.Color = Color.FromArgb(255, 255, 255, 0);
            }
            else
            {
                WaterSensorColor.Color = Color.FromArgb(255, 255, 0, 0);
            }
        }

        private async Task MonitoringTemp()
        {
            var minTemp = 90;
            while (true) 
            {
                if(HotWaterCount == 0) 
                {
                    Temp = 0;
                    HeaterWorkColor.Color = Color.FromArgb(255, 0, 0, 0);
                    break;
                }
                if (SensorSystem.TempSensor(Temp, minTemp) && HotWaterCount > 0)
                {
                    minTemp = 90;
                    TempSensorColor.Color = Color.FromArgb(255, 0, 255, 0);
                    HeaterWorkColor.Color = Color.FromArgb(255,255,0,0); 
                    Temp+=2;
                }
                else
                {
                    minTemp = 70;
                    TempSensorColor.Color = Color.FromArgb(255, 255, 0, 0);
                    HeaterWorkColor.Color = Color.FromArgb(255, 0, 0, 0);
                    Temp-=1;
                }
                await Task.Delay(HotWaterCount*2);
            }
        }

        private async Task FillHotTank()
        {
            while (SensorSystem.WaterAmountSensor(HotWaterCount, 390) &&
                   !SensorSystem.WaterAmountSensor(WaterCount, 0))
            {
                HotWaterCount += 10;
                FillWaterArrowColor.Color = Color.FromArgb(255, 0, 0, 255);
                WaterAmountSensorColor.Color = Color.FromArgb(255, 0, 255, 0);
                WaterCount -= 10;
                await Task.Delay(200);
                WaterAmountSensorColor.Color = Color.FromArgb(255, 255, 0, 0);
                FillWaterArrowColor.Color = Color.FromArgb(255, 0, 0, 0);
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
