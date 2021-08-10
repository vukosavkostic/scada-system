using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    public class Output : Tag
    {

        #region Fields
        private string ioAddress;
        private double initialValue;
        #endregion

        #region Properties
        [MaxLength(30)]
        public string IOAddress
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
