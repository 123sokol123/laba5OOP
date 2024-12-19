namespace WpfApp5._1
{
    public enum DeviceType { LENGTH, MASS }

    public class DeviceController
    {
        public static DeviceController StartDevice(DeviceType type)
        {
            return new DeviceController();
        }

        public void StopDevice()
        {
            // Заглушка для остановки устройства
        }

        public int TakeMeasurement()
        {
            Random random = new Random();
            return random.Next(1, 101); // Возвращает случайное значение
        }
    }
}
