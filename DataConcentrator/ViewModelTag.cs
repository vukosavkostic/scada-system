using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    public class ViewModelTag : INotifyPropertyChanged
    {
        private string id;
        private string tagType;
        private string address;
        private double value;
        private string unit;

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
        public string TagType
        { 
            get
            {
                return tagType;
            }
            set
            {
                tagType = value;
                OnPropertyChanged("TagType");
            }

        }
        public string Address
        { 
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged("Address");
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

        public event PropertyChangedEventHandler PropertyChanged;


        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }
}
