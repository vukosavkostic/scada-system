using DataConcentrator;
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
    /// Interaction logic for ChangeValueDo.xaml
    /// </summary>
    public partial class ChangeValueDo : Window
    {
        public DigitalOutput SelDo { get; set; }
        public string ChangeValue { get; set; }
        public ChangeValueDo(object obj)
        {
            InitializeComponent();
            SelDo = (DigitalOutput)obj;
            this.ValueCheckbox.ItemsSource = new List<string> { "true", "false" };

            this.DataContext = this;
        }

        private void PotvrdiClick(object sender, RoutedEventArgs e)
        {
            foreach(DigitalOutput diO in ScadaContext.Instance.DigitalOutputs)
            {
                if(diO.Id == SelDo.Id)
                {
                    if(ChangeValue == "false")
                    {
                        diO.InitialValue = 0;
                    }
                    else
                    {
                        diO.InitialValue = 1;
                    }

                    break;
                }
            }

            ScadaContext.Instance.SaveChanges();
            this.Close();
        }
    }
}
