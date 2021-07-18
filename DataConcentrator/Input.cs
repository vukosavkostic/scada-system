using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    public class Input : Tag
    {

        #region Fields
        private string ioAddress;
        private double scanTime;
        private double InputValue;
        #endregion

        #region Properties
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

        public double ScanTime
        {
            get
            {
                return scanTime;
            }

            set
            {
                scanTime = value;
                OnPropertyChanged("IOAddress");
            }
        }
        #endregion





    }
}