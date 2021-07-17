using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    public class Input
    {
        public enum IO_ADDRESS
        {

        }

        #region Fields
        private string id;
        private string description;
        private IO_ADDRESS ioAddress;
        private double scanTime;
        #endregion

        #region Properties
        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }

        }

        public IO_ADDRESS IOAddress
        {
            get
            {
                return ioAddress;
            }

            set
            {
                ioAddress = value;
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
            }
        }
        #endregion
    }
}