using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    public class Input : Tag , INotifyPropertyChanged
    {
        public enum IO_ADDRESS
        {
            ADDR001,
            ADDR002,
            ADDR003,
            ADDR004,
            ADDR005,
            ADDR006,
            ADDR007,
            ADDR008,
            ADDR009,
            ADDR0010
        }

        #region Fields
        private IO_ADDRESS ioAddress;
        private double scanTime;

        public event PropertyChangedEventHandler PropertyChanged;
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


        #region Methods
        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }


    }
}