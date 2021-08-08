using DataConcentrator.Analog;
using DataConcentrator.Digital;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    public class ScadaContext : DbContext
    {
        private static ScadaContext instance;

        public static ScadaContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScadaContext();
                }
                return instance;
            }
        }

        public ScadaContext() { }

        public DbSet<DigitalInput> DigitalInputs { get; set; }
        public DbSet<DigitalOutput> DigitalOutputs { get; set; }
        public DbSet<AnalogInput> AnalogInputs { get; set; }
        public DbSet<AnalogOutput> AnalogOutputs { get; set; }
        public DbSet<Alarm> Alarms { get; set; }

    }
}
