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

            if (Context == null)
            {
                Context = new ScadaContext();
            }
        }


        private void AddTag(object sender, RoutedEventArgs e)
        {

        }

        private void ExitMainWindow(object sender, RoutedEventArgs e)
        {
            Context.Dispose();
        }

        private void AddAlarm(object sender, RoutedEventArgs e)
        {

        }

        private void AlarmHistory(object sender, RoutedEventArgs e)
        {

        }

        private void DarkMode_Clicked(object sender, RoutedEventArgs e)
        {

        }
    }
}
