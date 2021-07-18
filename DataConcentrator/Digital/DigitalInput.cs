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
        private object locker = new object();
        #endregion

        #region Methods
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

            }

        }
        #endregion
    }
}
