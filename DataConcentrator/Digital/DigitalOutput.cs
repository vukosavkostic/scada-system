using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator.Digital
{
    public class DigitalOutput : Output
    {
        public override string ToString()
        {
            string retVal = "";
            retVal += $"ID: {Id}\n\n"
                   + $"Description: {Description}\n\n"
                   + $"Type: {TagType}\n\n"
                   + $"Address: {IOAddress}\n\n"
                   + $"Value: {InitialValue}\n\n";

            return retVal;
        }
    }



}
