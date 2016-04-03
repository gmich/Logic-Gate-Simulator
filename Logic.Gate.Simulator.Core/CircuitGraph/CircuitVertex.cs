using System.Collections.Generic;

namespace Logic.Gate.Simulator.Core
{
    public class CircuitVertex
    {
        public CircuitVertex(ICircuitComponent component)
        {
            Component = component;
        }

        public enum State
        {
            UnVisited,
            Visited,
            Triggered
        }

        public State CurrentState { get; set; }
        public ICircuitComponent Component { get; }
        public IList<CircuitEdge> Edges { get; internal set; } = new List<CircuitEdge>();
        
    }

}
