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
        private int scanTime;
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

        public int ScanTime
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