using DataConcentrator.Analog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    public enum ALARM_TYPE
    {
        HighValueAlarm,
        LowValueAlarm
    }

    public class Alarm : INotifyPropertyChanged
    {
        #region Fields
        private double limitValue;
        private string id;
        private string alarmMessage;
        private DateTime timeStamp;
        private ALARM_TYPE alarmType;
        private bool alarmOn;
        //Functionality only needed for writing alarm in AlarmHistory.txt file
        public DateTime lastTimeActivated;

        [ForeignKey("AnalogInput")]
        public string AnalogInputTagName { get; set; }
        public virtual AnalogInput AnalogInput { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public double LimitValue
        {
            get
            {
                return limitValue;
            }

            set
            {
                limitValue = value;
                OnPropertyChanged("LimitValue");
            }
        }

        [Key]
        [MaxLength(30)]
        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        [MaxLength(30)]
        public string AlarmMessage
        {
            get
            {
                return alarmMessage;
            }

            set
            {
                alarmMessage = value;
                OnPropertyChanged("AlarmMessage");
            }
        }

        public DateTime TimeStamp
        {
            get
            {
                return timeStamp;
            }

            set
            {
                timeStamp = value;
                OnPropertyChanged("TimeStamp");

            }
        }

        public ALARM_TYPE AlarmType
        {
            get
            {
                return alarmType;
            }

            set
            {
                alarmType = value;
                OnPropertyChanged("AlarmType");
            }

        }
        public bool AlarmOn
        {
            get
            {
                return alarmOn;
            }

            set
            {
                alarmOn = value;
                OnPropertyChanged("AlarmOn");
            }

        }

        #endregion



        #region Methods
        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public override string ToString()
        {
            string retVal = "";
            retVal += "------------------------\n\n"
                    + $"Alarm ID: {Id}\n\n"
                    + $"Alarm Limit Value: {LimitValue}\n\n"
                    + $"Alarm Type: {AlarmType}\n\n"
                    + $"Alarm Message: {AlarmMessage}\n\n"
                    + $"Alarm Activated: {TimeStamp}\n\n"
                    + $"Analog Input: {AnalogInputTagName}\n\n"
                    +"------------------------\n\n";

            return retVal;
        }

        public string alarmForTextFile()
        {
            string retval = "";
            retval += $"/ [ID: {Id}], [Last Time Activated: {TimeStamp}] [Analog Input: {AnalogInputTagName}] [Message: {AlarmMessage}] /\n";
            return retval;
        }
        #endregion
    }
}
