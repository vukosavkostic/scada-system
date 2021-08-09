using DataConcentrator;
using DataConcentrator.Analog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


namespace ScadaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        public static ScadaContext Context { get; set; }
        public Alarm SelectedAlarm { get; set; }
        public AnalogInput SelectedAnalogInput { get; set; }

    

        public MainWindow()
        {
           InitializeComponent();

           Context = new ScadaContext();


        }


        private void AddTag(object sender, RoutedEventArgs e)
        {
            AddTagWindow tagWindow = new AddTagWindow();
            tagWindow.Show();
        }

        private void ExitMainWindow(object sender, RoutedEventArgs e)
        {
            ScadaContext.Instance.Dispose();
            PLCContext.Instance.Abort();
            foreach (AnalogInput ai in ScadaContext.Instance.AnalogInputs)
            {
                ai.StartAIThread();
            }

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
    }
}
