using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLCSimulator;

namespace DataConcentrator
{
    public class PLCContext
    {
        public static PLCSimulatorManager instance;

        public static PLCSimulatorManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new PLCSimulatorManager();
                    instance.StartPLCSimulator();
                }

                return instance;
            }

        }

        public void StopPLCSimulator()
        {
            instance.Abort();
        }
    }
}
