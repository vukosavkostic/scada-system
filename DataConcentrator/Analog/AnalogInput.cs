using PLCSimulator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private double value;
        private AnalogInputStatus status;
        // Event triggers when a value is above or below critical level
        public ValueHandler ValueChangedToCritical;
        private object locker = new object();
        #endregion

        #region Properties

        public virtual List<Alarm> Alarms
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

        [MaxLength(30)]
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

        public double Value
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

        public void StopAIThread()
        {
            AThread.Abort();
        }
        public void ScanPLCAnalogInput(object obj)
        {
            while(true)
            {
                lock (locker)
                {
                    Value = ((PLCSimulatorManager)obj).GetAnalogValue(IOAddress);

                    if (Alarms != null)
                    {
                        foreach (Alarm al in Alarms)
                        {
                            if (al.AlarmType == ALARM_TYPE.LowValueAlarm)
                            {
                                if (Value <= al.LimitValue)
                                {
                                    al.AlarmOn = true;
                                    Status = AnalogInputStatus.ALARMING;
                                    ValueChangedToCritical?.Invoke(al.Id);
                                }

                                else
                                {
                                    al.AlarmOn = false;
                                    Status = AnalogInputStatus.REGULAR;
                                }

                            }

                            if (al.AlarmType == ALARM_TYPE.HighValueAlarm)
                            {
                                if (Value >= al.LimitValue)
                                {
                                    al.AlarmOn = true;
                                    Status = AnalogInputStatus.ALARMING;
                                    ValueChangedToCritical?.Invoke(al.Id);
                                }

                                else
                                {
                                    al.AlarmOn = false;
                                    Status = AnalogInputStatus.REGULAR;
                                }

                            }

                        }
                    }


                }

                Thread.Sleep(ScanTime);

            }
        }
        #endregion

    }
}
