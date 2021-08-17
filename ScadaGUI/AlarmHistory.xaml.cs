using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace ScadaGUI
{
    /// <summary>
    /// Interaction logic for AlarmHistory.xaml
    /// </summary>
    public partial class AlarmHistory : Window
    {
        public AlarmHistory()
        {
            InitializeComponent();
            string alarmHistory = File.ReadAllText(DataConcentrator.Analog.AnalogInput.path);
            this.alarmHistoryTextbox.Text = alarmHistory;

            this.DataContext = this;
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
