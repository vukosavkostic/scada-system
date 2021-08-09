using DataConcentrator;
using DataConcentrator.Analog;
using DataConcentrator.Digital;
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
using System.Windows.Shapes;

namespace ScadaGUI
{
    /// <summary>
    /// Interaction logic for AddTagWindow.xaml
    /// </summary>
    public partial class AddTagWindow : Window
    {
        private DigitalInput newDigitalInput = new DigitalInput();
        private DigitalOutput newDigitalOutput = new DigitalOutput();
        private AnalogInput newAnalogInput = new AnalogInput();
        private AnalogOutput newAnalogOutput = new AnalogOutput();

        public AddTagWindow()
        {
            InitializeComponent();
            this.tagType.ItemsSource = new List<string> { "Digital Input", "Digital Output", "Analog Input", "Analog Output" };
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            AddTagToDatabase();
        }

        //Poziva se kada se desi TagType value change
        private void SetupAddWindow(object sender, SelectionChangedEventArgs e)
        {
            this.tagAddress.SelectedValue = "";

            if ((string)this.tagType.SelectedItem == "Digital Input")
            {
                this.tagAddress.ItemsSource = new List<string> { "ADDR009", "ADDR010", "ADDR011", "ADDR012" };
                this.AddWindowMainGrid.DataContext = newDigitalInput;

            }
            else if ((string)this.tagType.SelectedItem == "Digital Output")
            {
                this.tagAddress.ItemsSource = new List<string> { "ADDR013", "ADDR014", "ADDR015", "ADDR016" };
                this.AddWindowMainGrid.DataContext = newDigitalOutput;

            }
            else if ((string)this.tagType.SelectedItem == "Analog Input")
            {
                this.tagAddress.ItemsSource = new List<string> { "ADDR001", "ADDR002", "ADDR003", "ADDR004" };
                this.AddWindowMainGrid.DataContext = newAnalogInput;

            }
            else if((string)this.tagType.SelectedItem == "Analog Output")
            {
                this.tagAddress.ItemsSource = new List<string> { "ADDR005", "ADDR006", "ADDR007", "ADDR008" };
                this.AddWindowMainGrid.DataContext = newAnalogOutput;
            }


 
        }

        private void AddTagToDatabase()
        {

            if ((string)this.tagType.SelectedItem == "Digital Input")
            {
                ScadaContext.Instance.DigitalInputs.Add(newDigitalInput);
                ScadaContext.Instance.SaveChanges();
                newDigitalInput.StartDThread();
            }
            else if ((string)this.tagType.SelectedItem == "Digital Output")
            {
                ScadaContext.Instance.DigitalOutputs.Add(newDigitalOutput);
                ScadaContext.Instance.SaveChanges();
            }
            else if ((string)this.tagType.SelectedItem == "Analog Output")
            {
                ScadaContext.Instance.AnalogOutputs.Add(newAnalogOutput);
                ScadaContext.Instance.SaveChanges();
            }
            else if((string)this.tagType.SelectedItem == "Analog Input")
            {
                ScadaContext.Instance.AnalogInputs.Add(newAnalogInput);
                ScadaContext.Instance.SaveChanges();
                newAnalogInput.StartAIThread();
            }

            this.Close();
        }
    }
}
