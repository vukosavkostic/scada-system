using DataConcentrator.Digital;
using PLCSimulator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.IO;
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
        private static TimeSpan tresholdHighValue = TimeSpan.Zero;
        private static TimeSpan tresholdLowValue = TimeSpan.Zero;
        private int delayAlarmFor = 5;
        public static string path = @"..\\..\\..\\AlarmHistory.txt";
        //Where AlarmHistory.txt file is located
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
                try
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
                                        al.TimeStamp = DateTime.Now;
                                        //if alarm trigered for the first time
                                        if (al.lastTimeActivated == null)
                                        {
                                            al.lastTimeActivated = DateTime.Now;
                                        }

                                        if (al.TimeStamp >= al.lastTimeActivated.Add(tresholdLowValue))
                                        {
                                            File.AppendAllText(path, al.alarmForTextFile());

                                            tresholdLowValue = TimeSpan.FromMinutes(delayAlarmFor);
                                            al.lastTimeActivated = DateTime.Now;
                                        }
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
                                        al.TimeStamp = DateTime.Now;

                                        //if alarm trigered for the first time
                                        if (al.lastTimeActivated == null)
                                        {
                                            al.lastTimeActivated = DateTime.Now;
                                        }

                                        if (al.TimeStamp >= al.lastTimeActivated.Add(tresholdHighValue))
                                        {
                                            File.AppendAllText(path, al.alarmForTextFile());

                                            tresholdHighValue = TimeSpan.FromMinutes(delayAlarmFor);
                                            al.lastTimeActivated = DateTime.Now;
                                        }
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
                    
                }

                finally 
                {   /*
                    foreach (AnalogInput ai in ScadaContext.Instance.AnalogInputs)
                    {
                        ai.StopAIThread();
                    }

                    foreach (DigitalInput di in ScadaContext.Instance.DigitalInputs)
                    {
                        di.StopDThread();
                    }
                    //dataThread.Abort();


                    PLCContext.Instance.Abort();
                    ScadaContext.Instance.Dispose();
                    */
                }

                Thread.Sleep(ScanTime);

            }
        }

        public override string ToString()
        {
            string retVal = "";
            retVal += $"ID: {Id}\n\n"
                   + $"Description: {Description}\n\n"
                   + $"Type: {TagType}\n\n"
                   + $"Address: {IOAddress}\n\n"
                   + $"Scan Time: {ScanTime}\n\n"
                   + $"Unit: {Unit}\n\n"
                   + $"Value: {Value}\n\n";

            return retVal;
        }

        public string AlarmList()
        {
            string retVal = "";

            foreach (var alarm in Alarms)
            {
                retVal += $"Name: {alarm.Id} Limit: {alarm.LimitValue}  Type: {alarm.AlarmType}\n";
            }

            return retVal;
        }
        #endregion

    }
}
