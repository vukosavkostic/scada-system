using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    public class Output : Tag
    {
        public enum IO_ADDRESS
        {

        }

        #region Fields
        private IO_ADDRESS ioAddress;
        private double initialValue;
        #endregion

        #region Properties
        public IO_ADDRESS IOAddress
        {
            get
            {
                return ioAddress;
            }

            set
            {
                ioAddress = value;
                OnPropertyChanged("IOAddress");
            }
        }

        public double InitialValue
        {
            get
            {
                return initialValue;
            }

            set
            {
                initialValue = value;
                OnPropertyChanged("InitialValue");
            }
        }
        #endregion
    }
}
