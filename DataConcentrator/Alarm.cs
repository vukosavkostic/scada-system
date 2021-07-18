using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    public class Alarm
    {
        private double limitValue;
        private string id;
        private string alarmMessage;
        private DateTime timeStamp;

        public double LimitValue
        {
            get
            {
                return limitValue;
            }

            set
            {
                limitValue = value;
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
            }
        }
    }
}
