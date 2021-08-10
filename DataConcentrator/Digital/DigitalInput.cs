using PLCSimulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataConcentrator.Digital
{
    public class DigitalInput : Input
    {

        #region Fields
        private Thread DThread;
        private bool value;
        private object locker = new object();
        #endregion

        public bool Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
                OnPropertyChanged("Value");
            }

        }


        #region Methods
        public DigitalInput()
        {
            DThread = new Thread(ScanPLCDigitalInput);

        }

        public void StartDThread()
        {
            DThread.Start(PLCContext.Instance);
        }

        public void StopDThread()
        {
            DThread.Abort();
        }

        public void ScanPLCDigitalInput(object obj)
        {
            while(true)
            {
                lock (locker) 
                {
                    Value = ((PLCSimulatorManager)obj).GetDigitalValue(IOAddress);
                }

                Thread.Sleep(ScanTime);
            }

        }
        #endregion
    }
}
