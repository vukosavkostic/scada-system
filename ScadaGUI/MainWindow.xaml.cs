using DataConcentrator;
using DataConcentrator.Analog;
using DataConcentrator.Digital;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Threading;

namespace ScadaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        public Alarm SelectedAlarm { get; set; }
        public AnalogInput SelectedTag { get; set; }
        private Thread mainThread;
        private IEnumerable<ViewModelTag> viewData;

        public MainWindow()
        {
            InitializeComponent();
            mainThread = new Thread(MakeViewData);
            mainThread.Start();
            StartScan();


            ScadaContext.Instance.Alarms.Load();
            this.AlarmGrid.ItemsSource = ScadaContext.Instance.Alarms.Local;






        }


        private void AddTag(object sender, RoutedEventArgs e)
        {
            AddTagWindow tagWindow = new AddTagWindow();
            tagWindow.Show();
        }

        private void ExitMainWindow(object sender, RoutedEventArgs e)
        {
            mainThread.Abort();
            foreach (AnalogInput ai in ScadaContext.Instance.AnalogInputs)
            {
                ai.StopAIThread();
            }

            foreach (DigitalInput di in ScadaContext.Instance.DigitalInputs)
            {
                di.StopDThread();
            }

            ScadaContext.Instance.Dispose();
            PLCContext.Instance.Abort();
  

            this.Close();
        }

        private void AddAlarm(object sender, RoutedEventArgs e)
        {
            AddAlarmWindow alarmWindow = new AddAlarmWindow();
            alarmWindow.Show();
        }

        private void AlarmHistory(object sender, RoutedEventArgs e)
        {

        }

        private void DarkMode_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void MakeViewData(object obj)
        {

            while (true)
            {
                ScadaContext.Instance.AnalogInputs.Load();

                IEnumerable<ViewModelTag> AnalogInputViewModel =
                    from aiV in ScadaContext.Instance.AnalogInputs.Local
                    select new ViewModelTag
                    {
                        Id = aiV.Id,
                        TagType = aiV.TagType,
                        Address = aiV.IOAddress,
                        Value = aiV.Value,
                        Unit = aiV.Unit
                    };

                ScadaContext.Instance.AnalogOutputs.Load();

                IEnumerable<ViewModelTag> AnalogOutputViewModel =
                    from aoV in ScadaContext.Instance.AnalogOutputs.Local
                    select new ViewModelTag
                    {
                        Id = aoV.Id,
                        TagType = aoV.TagType,
                        Address = aoV.IOAddress,
                        Value = aoV.InitialValue,
                        Unit = "/"
                    };

                ScadaContext.Instance.DigitalInputs.Load();

                IEnumerable<ViewModelTag> DigitalInputViewModel =
                    from diV in ScadaContext.Instance.DigitalInputs.Local
                    select new ViewModelTag
                    {
                        Id = diV.Id,
                        TagType = diV.TagType,
                        Address = diV.IOAddress,
                        Value = diV.Value ? 1 : 0,
                        Unit = "/"
                    };

                ScadaContext.Instance.DigitalOutputs.Load();

                IEnumerable<ViewModelTag> DigitalOutputViewModel =
                      from doV in ScadaContext.Instance.DigitalOutputs.Local
                      select new ViewModelTag
                      {
                          Id = doV.Id,
                          TagType = doV.TagType,
                          Address = doV.IOAddress,
                          Value = doV.InitialValue,
                          Unit = "/"
                      };

                var CombinedViewModel = AnalogInputViewModel.Concat(AnalogOutputViewModel).Concat(DigitalInputViewModel).Concat(DigitalOutputViewModel);
                Dispatcher.BeginInvoke(
                    DispatcherPriority.Normal,
                    (Action)delegate
                    {
                        this.DataGrid.ItemsSource = CombinedViewModel.ToList();
                    });

                Thread.Sleep(300);
            }
            
            
        }

        private void StartScan()
        {
            foreach (AnalogInput ai in ScadaContext.Instance.AnalogInputs)
            {
                ai.StartAIThread();
            }

            foreach (DigitalInput di in ScadaContext.Instance.DigitalInputs)
            {
                di.StartDThread();
            }
        }
 
    }
}
