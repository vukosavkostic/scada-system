using DataConcentrator;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for AddAlarmWindow.xaml
    /// </summary>
    public partial class AddAlarmWindow : Window
    {
        Alarm newAlarm = new Alarm();

        public AddAlarmWindow()
        {
            InitializeComponent();

            this.alarmType.ItemsSource = new List<string> { "Low Limit", "High Limit" };

            if (ScadaContext.Instance.AnalogInputs != null)
            {
                ScadaContext.Instance.AnalogInputs.Load();

                var imena =
                    from aInput in ScadaContext.Instance.AnalogInputs.Local
                    select aInput.Id;

                this.analogInput.ItemsSource = imena;

            }

            this.MainAlarmGrid.DataContext = newAlarm;
            
        }

        private void ConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            if ((string)this.alarmType.SelectedItem == "Low Limit")
            {
                newAlarm.AlarmType = ALARM_TYPE.LowValueAlarm;
            }
            else
            {
                newAlarm.AlarmType = ALARM_TYPE.HighValueAlarm;
            }

            newAlarm.TimeStamp = DateTime.Now;
            newAlarm.AlarmOn = false;

            ScadaContext.Instance.Alarms.Add(newAlarm);
            ScadaContext.Instance.SaveChanges();

            this.Close();

        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



    }
}
