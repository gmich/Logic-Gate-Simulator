namespace Logic.Gate.Simulator.Core.Gates
{
    public class GateFlow : IFlow
    {
        internal GateFlow(int value)
        {
            Weight = value;
        }

        public static GateFlow True => new GateFlow(1);
        public static GateFlow False => new GateFlow(0);
        public int Weight { get; } 

    }
}
