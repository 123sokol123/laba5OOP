namespace WpfApp5._1
{
    public interface IMeasuringDevice
    {
        /// <summary>
        /// Возвращает последнее измерение в метрических единицах.
        /// </summary>
        decimal MetricValue();

        /// <summary>
        /// Возвращает последнее измерение в имперских единицах.
        /// </summary>
        decimal ImperialValue();

        /// <summary>
        /// Запускает устройство измерения.
        /// </summary>
        void StartCollecting();

        /// <summary>
        /// Останавливает устройство измерения.
        /// </summary>
        void StopCollecting();

        /// <summary>
        /// Возвращает необработанные данные с устройства.
        /// </summary>
        int[] GetRawData();
    }
}
