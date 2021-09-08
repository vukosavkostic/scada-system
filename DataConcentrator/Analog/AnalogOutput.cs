using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator.Analog
{
    public class AnalogOutput : Output
    {
        private string unit;

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

        public override string ToString()
        {
            string retVal = "";
            retVal += $"ID: {Id}\n\n"
                   + $"Description: {Description}\n\n"
                   + $"Type: {TagType}\n\n"
                   + $"Address: {IOAddress}\n\n"
                   + $"Unit: {Unit}\n\n"
                   + $"Value: {InitialValue}\n\n";

            return retVal;
        }

    }
}
