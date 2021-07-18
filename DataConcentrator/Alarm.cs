using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        #endregion



        #region Methods
        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}
