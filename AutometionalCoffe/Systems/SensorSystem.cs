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
    }
}
