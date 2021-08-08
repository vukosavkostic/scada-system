using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator.Analog
{
    public class AnalogOutput : Output
    {
        private string unit;

        public string Unit
        {
            get
            {
                return unit;
            }

            set
            {
                unit = value;
                OnPropertyChanged("Unit");
            }
        }

    }
}
