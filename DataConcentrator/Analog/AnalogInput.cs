using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator.Analog
{
    public class AnalogInput : Input 
    {
        #region Fields
        private List<Alarm> alarms;
        private string unit;
        #endregion

        #region Properties
        public List<Alarm> Alarms
        {
            get
            {
                return alarms;
            }

            set
            {
                alarms = value;
                OnPropertyChanged("Alarms");
            }
        }

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
        #endregion



    }
}
