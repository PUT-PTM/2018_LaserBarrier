using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeMeasurmentApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly string _startSerialPortNumber = "COM5";
        private readonly string _endSerialPortNumber = "COM8";
        private readonly int _baudrate = 9600;
        private readonly int _dataBits = 8;

        private SerialPort _startSerialPort;
        private SerialPort _endSerialPort;
        private Measurment _temporaryMeasurment; 

        public ObservableCollection<Measurment> Measurments { get; private set; } =  new ObservableCollection<Measurment>();


        public MainWindow()
        {

            InitializeComponent();
            MeasurmentsDataGrid.ItemsSource = Measurments;

            InitStartSerialPort();
            InitEndSerialPort();
        }

        private void InitStartSerialPort()
        {
            _startSerialPort = new SerialPort(_startSerialPortNumber, _baudrate);
            _startSerialPort.Parity = Parity.None;
            _startSerialPort.Handshake = Handshake.None;
            _startSerialPort.StopBits = StopBits.One;
            _startSerialPort.DataBits = _dataBits;
            _startSerialPort.DataReceived += StartSerialPortOnDataReceived;
            _startSerialPort.Open();
        }

        private void InitEndSerialPort()
        {
            _endSerialPort = new SerialPort(_endSerialPortNumber, _baudrate);
            _endSerialPort.Parity = Parity.None;
            _endSerialPort.Handshake = Handshake.None;
            _endSerialPort.StopBits = StopBits.One;
            _endSerialPort.DataBits = _dataBits;
            _endSerialPort.DataReceived += EndSerialPortOnDataReceived;
            _endSerialPort.Open();
        }

        private void EndSerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
        {
            var msgFromStm = _endSerialPort.ReadLine();
            if (msgFromStm.Contains("STM2;e"))
            {
                 _temporaryMeasurment.End = DateTime.Now;
                var result = (_temporaryMeasurment.End - _temporaryMeasurment.Start).TotalSeconds;
                Console.WriteLine("stm Kamila" + result);
                _temporaryMeasurment.Result = result;
                Application.Current.Dispatcher.BeginInvoke(new Action(() => this.Measurments.Add(_temporaryMeasurment)));

            }
        }

        private void StartSerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
        {
            var msgFromStm = _startSerialPort.ReadLine();
            if (msgFromStm.Contains("STM1;s"))
            {
                _temporaryMeasurment = new Measurment();
                _temporaryMeasurment.Start = DateTime.Now;
                Console.WriteLine($@"Stm michal, ID:{_temporaryMeasurment.Id},Date:{_temporaryMeasurment.Start}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _startSerialPort.Write("R");
            Thread.Sleep(200);
            _endSerialPort.Write("R");
        }
    }
}
