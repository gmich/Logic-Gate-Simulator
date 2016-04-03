namespace Logic.Gate.Simulator.Core.CircuitGraph
{
    public class CircuitEdge
    {
        public CircuitEdge(CircuitVertex direction)
        {
            DirectsTo = direction;
        }

        public CircuitVertex DirectsTo { get; }
    }
}
