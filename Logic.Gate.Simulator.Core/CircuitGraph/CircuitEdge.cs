namespace Logic.Gate.Simulator.Core
{
    public class CircuitEdge
    {
        public CircuitEdge(CircuitVertex direction, string tag)
        {
            Tag = tag;
            DirectsTo = direction;
        }

        public string Tag { get; }
        public CircuitVertex DirectsTo { get; }
    }
}
