using PLCSimulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataConcentrator.Analog
{
    public delegate void ValueHandler(string name);

    public class AnalogInput : Input 
    {
        public enum AnalogInputStatus
        {
            REGULAR,
            ALARMING
        }


        #region Fields
        private List<Alarm> alarms;
        private Thread AThread;
        private string unit;
        private AnalogInputStatus status;
        // Event triggers when a value is above or below critical level
        public ValueHandler ValueChangedToCritical;
        private object locker = new object();
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

        public AnalogInputStatus Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }
        #endregion

        #region Methods
        public AnalogInput()
        {
            this.Alarms = new List<Alarm>();
            AThread = new Thread(ScanPLCAnalogInput);
            this.Status = AnalogInputStatus.REGULAR;
        }

        public void StartAIThread()
        {
            AThread.Start(PLCContext.Instance);
        }

        public void ScanPLCAnalogInput(object obj)
        {
            while(true)
            {
                lock(locker)
                {
                    double currentAIValue = ((PLCSimulatorManager)obj).GetAnalogValue(IOAddress);



                }

            }
        }
        #endregion

    }
}
