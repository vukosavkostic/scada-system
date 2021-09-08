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
using System.Windows.Shapes;

namespace ScadaGUI
{
    /// <summary>
    /// Interaction logic for ChangeValueAo.xaml
    /// </summary>
    public partial class ChangeValueAo : Window
    {
        private AnalogOutput SelAo { get; set; }
        public double ChangeValueAoVar { get; set; }

        public ChangeValueAo(object obj)
        {
            InitializeComponent();
            SelAo = (AnalogOutput)obj;
            this.DataContext = this;
        }

        private void PotvrdiClick(object sender, RoutedEventArgs e)
        {
            foreach(AnalogOutput ao in ScadaContext.Instance.AnalogOutputs)
            {
                if(ao.Id == SelAo.Id)
                {
                    ao.InitialValue = ChangeValueAoVar;
                    break;
                }
            }
            ScadaContext.Instance.SaveChanges();
            this.Close();
        }
    }
}
