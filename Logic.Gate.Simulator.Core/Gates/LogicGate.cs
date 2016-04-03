using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Gate.Simulator.Core.Gates
{
    public class LogicGate
    {
        public static IGate AND => new AND();
        public static IGate OR => new OR();
    }
}
