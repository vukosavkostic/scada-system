using DataConcentrator;
using DataConcentrator.Analog;
using DataConcentrator.Digital;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
        public static Alarm SelectedAlarm { get; set; }
        public static AnalogInput SelectedAi { get; set; }
        public static AnalogOutput SelectedAo { get; set; }
        public static DigitalInput SelectedDi { get; set; }
        public static DigitalOutput SelectedDo { get; set; }

        public bool ChangeValueDoVar { get; set; }
        private object locker = new object();

        public MainWindow()
        {
            InitializeComponent();
            //dataThread = new Thread(MakeViewData);
            //dataThread.Start();
            CreateAlarmTextFile();

            ScadaContext.Instance.Alarms.Load();
            this.AlarmGrid.ItemsSource = ScadaContext.Instance.Alarms.Local;

            ScadaContext.Instance.AnalogInputs.Load();
            this.AiDataGrid.ItemsSource = ScadaContext.Instance.AnalogInputs.Local;

            ScadaContext.Instance.AnalogOutputs.Load();
            this.AoDataGrid.ItemsSource = ScadaContext.Instance.AnalogOutputs.Local;

            ScadaContext.Instance.DigitalInputs.Load();
            this.DiDataGrid.ItemsSource = ScadaContext.Instance.DigitalInputs.Local;

            ScadaContext.Instance.DigitalOutputs.Load();
            this.DoDataGrid.ItemsSource = ScadaContext.Instance.DigitalOutputs.Local;





            
            StartScan();

            this.DataContext = this;

        }


        private void AddTag(object sender, RoutedEventArgs e)
        {
            AddTagWindow tagWindow = new AddTagWindow();
            tagWindow.Show();
        }

        private void ExitMainWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddAlarm(object sender, RoutedEventArgs e)
        {
            AddAlarmWindow alarmWindow = new AddAlarmWindow();
            alarmWindow.Show();
        }

        private void AlarmHistory(object sender, RoutedEventArgs e)
        {
            AlarmHistory alarmHistory = new AlarmHistory();
            alarmHistory.Show();
        }

        private void DarkMode_Clicked(object sender, RoutedEventArgs e)
        {

        }
        
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

           foreach (AnalogInput ai in ScadaContext.Instance.AnalogInputs)
            {
                ai.StopAIThread();
            }

            foreach (DigitalInput di in ScadaContext.Instance.DigitalInputs)
            {
                di.StopDThread();
            }
            //dataThread.Abort();
            
            
            PLCContext.Instance.Abort();
            //ScadaContext.Instance.Dispose();
            ScadaContext.Instance.Database.Connection.Close();
        }

        private void AiTagDelete(object sender, RoutedEventArgs e)
        {
            if (SelectedAi != null)
            {
                ScadaContext.Instance.AnalogInputs.Remove(SelectedAi);
                ScadaContext.Instance.SaveChanges();
            }
            else
            {
                MessageBox.Show("You didn't select tag to delete...");
            }

        }

        private void DeleteAlarm(object sender, RoutedEventArgs e)
        {
            if (SelectedAlarm != null)
            {
                ScadaContext.Instance.Alarms.Remove(SelectedAlarm);
                ScadaContext.Instance.SaveChanges();
            }

            else
            {
                MessageBox.Show("You didn't select alarm to delete...");
            }
        }

        private void AiTagDetails(object sender, RoutedEventArgs e)
        {
            if (SelectedAi != null)
            {
                MessageBox.Show(SelectedAi.ToString());
            }
            
            else
            {
                MessageBox.Show("You didn't select tag");
            }    
        }

        private void AlarmDetails(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(SelectedAlarm.ToString());
        }

        private void AoTagDelete(object sender, RoutedEventArgs e)
        {
            if (SelectedAo != null)
            {
                ScadaContext.Instance.AnalogOutputs.Remove(SelectedAo);
                ScadaContext.Instance.SaveChanges();
            }
            else
            {
                MessageBox.Show("You didn't select tag to delete...");
            }

        }

        private void AoTagDetails(object sender, RoutedEventArgs e)
        {
            if (SelectedAo != null)
            {
                MessageBox.Show(SelectedAo.ToString());
            }

            else
            {
                MessageBox.Show("You didn't select tag");
            }
        }

        private void ChangeAoValueMet(object sender, RoutedEventArgs e)
        {
            ChangeValueAo ao = new ChangeValueAo(SelectedAo);
            ao.ShowDialog();
            
        }


        private void DiTagDelete(object sender, RoutedEventArgs e)
        {
            if (SelectedDi != null)
            {
                ScadaContext.Instance.DigitalInputs.Remove(SelectedDi);
                ScadaContext.Instance.SaveChanges();
            }
            else
            {
                MessageBox.Show("You didn't select tag to delete...");
            }

        }

        private void DiTagDetails(object sender, RoutedEventArgs e)
        {
            if (SelectedDi != null)
            {
                MessageBox.Show(SelectedDi.ToString());
            }

            else
            {
                MessageBox.Show("You didn't select tag");
            }
        }

        private void DoTagDelete(object sender, RoutedEventArgs e)
        {
            if (SelectedDo != null)
            {
                ScadaContext.Instance.DigitalOutputs.Remove(SelectedDo);
                ScadaContext.Instance.SaveChanges();
            }
            else
            {
                MessageBox.Show("You didn't select tag to delete...");
            }

        }

        private void DoTagDetails(object sender, RoutedEventArgs e)
        {
            if (SelectedDo != null)
            {
                MessageBox.Show(SelectedDo.ToString());
            }

            else
            {
                MessageBox.Show("You didn't select tag");
            }
        }

        private void ChangeDoValueMet(object sender, RoutedEventArgs e)
        {
            ChangeValueDo doWin = new ChangeValueDo(SelectedDo);
            doWin.ShowDialog();
        }


        private void AiSelection(object sender, MouseButtonEventArgs args)
        {
            SelectedAo = null;
            SelectedDi = null;
            SelectedDo = null;
        }

        private void AoSelection(object sender, MouseButtonEventArgs args)
        {
            SelectedAi = null;
            SelectedDi = null;
            SelectedDo = null;
        }

        private void DiSelection(object sender, MouseButtonEventArgs args)
        {
            SelectedAi = null;
            SelectedAo = null;
            SelectedDo = null;
        }

        private void DoSelection(object sender, MouseButtonEventArgs args)
        {
            SelectedAi = null;
            SelectedAo = null;
            SelectedDi = null;
        }



        /*
        private void MakeViewData(object obj)
        {

            while (true)
            {
                lock (locker)
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
                            Unit = aoV.Unit
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
                }
                
                Thread.Sleep(500);
                
            }
            
            
        }
        */
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

        private void CreateAlarmTextFile()
        {
            if (!File.Exists(AnalogInput.path))
            {
                File.Create(AnalogInput.path).Dispose();
                using( TextWriter tw = new StreamWriter(AnalogInput.path))
                {
                    tw.WriteLine("------------------ ALARM HISTORY ------------------ ");
                }

                Console.WriteLine("Creating AlarmHistory file...");
            }
        }
 
    }
}
