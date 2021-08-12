using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    public class ViewModelTag
    {
        public string Id { get; set; }
        public string TagType { get; set; }
        public string Address { get; set; }
        public double Value { get; set; }
        public string Unit { get; set; }


        public ViewModelTag(string id,  string tagType, string address, double value, string unit)
        {
            Id = id;
            TagType = tagType;
            Address = address;
            Value = value;
            Unit = unit;
        }
    }
}
