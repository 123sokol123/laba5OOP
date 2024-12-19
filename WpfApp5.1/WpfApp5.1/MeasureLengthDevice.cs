using System;
using System.Threading;

namespace WpfApp5._1
{
    public class MeasureLengthDevice : IMeasuringDevice
    {
        private Units unitsToUse;
        private int[] dataCaptured;
        private int mostRecentMeasure;
        private DeviceController controller;
        private const DeviceType measurementType = DeviceType.LENGTH;

        public MeasureLengthDevice(Units units)
        {
            unitsToUse = units;
            dataCaptured = new int[10];
        }

        public decimal MetricValue()
        {
            return unitsToUse == Units.Metric
                ? mostRecentMeasure
                : mostRecentMeasure * 25.4m;
        }

        public decimal ImperialValue()
        {
            return unitsToUse == Units.Imperial
                ? mostRecentMeasure
                : mostRecentMeasure * 0.03937m;
        }

        public void StartCollecting()
        {
            if (controller == null) // Проверяем, чтобы не запустить второй раз
            {
                controller = DeviceController.StartDevice(measurementType);
                GetMeasurements();
            }
        }


        public void StopCollecting()
        {
            if (controller != null)
            {
                controller.StopDevice();
                controller = null;

                // Убедимся, что поток сбора данных завершился
                Thread.Sleep(500);
            }
        }


        public int[] GetRawData()
        {
            return dataCaptured;
        }

        private void GetMeasurements()
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                int x = 0;
                Random timer = new Random();

                while (controller != null)
                {
                    try
                    {
                        Thread.Sleep(timer.Next(1000, 5000));

                        lock (dataCaptured) // Блокировка для потокобезопасного доступа
                        {
                            dataCaptured[x] = controller.TakeMeasurement();
                            mostRecentMeasure = dataCaptured[x];
                            x = (x + 1) % 10; // Циклический буфер
                        }
                    }
                    catch
                    {
                        // Игнорируем возможные исключения при завершении потока
                        break;
                    }
                }
            });
        }

    }
}
