namespace AutometionalCoffe.Systems
{
    public class SensorSystem
    {
        public static SensorSystem Instens = new SensorSystem();

        public bool CoinSensor(string coinExample)
        {
            int resalt;
            return int.TryParse(coinExample, out resalt);
        }

        public static bool WaterAmountSensor(int amount , int minCount)
        {
            return amount <= minCount;
        }

        public static bool TempSensor(int temp , int minTemp)
        {
            return temp <= minTemp;
        }
    }
}
