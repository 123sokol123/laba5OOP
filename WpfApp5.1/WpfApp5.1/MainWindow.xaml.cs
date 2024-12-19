using System.Windows;

namespace WpfApp5._1
{
    public partial class MainWindow : Window
    {
        private MeasureLengthDevice device;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateInstance_Click(object sender, RoutedEventArgs e)
        {
            Units selectedUnit = MetricRadioButton.IsChecked == true
                ? Units.Metric
                : Units.Imperial;

            device = new MeasureLengthDevice(selectedUnit);
            MessageBox.Show("Устройство создано.");
        }

        private void StartCollecting_Click(object sender, RoutedEventArgs e)
        {
            device?.StartCollecting();
            MessageBox.Show("Сбор данных начат.");
        }

        private void StopCollecting_Click(object sender, RoutedEventArgs e)
        {
            if (device != null)
            {
                device.StopCollecting();
                MessageBox.Show("Сбор данных остановлен.");
            }
            else
            {
                MessageBox.Show("Устройство не активно.");
            }
        }


        private void GetRawData_Click(object sender, RoutedEventArgs e)
        {
            if (device != null)
            {
                RawDataListBox.ItemsSource = device.GetRawData();
            }
        }

        private void GetMetricValue_Click(object sender, RoutedEventArgs e)
        {
            if (device != null)
            {
                MessageBox.Show($"Метрическое значение: {device.MetricValue()}");
            }
        }

        private void GetImperialValue_Click(object sender, RoutedEventArgs e)
        {
            if (device != null)
            {
                MessageBox.Show($"Имперское значение: {device.ImperialValue()}");
            }
        }
    }
}
