using System;
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
        public IList<CircuitEdge> Output { get; internal set; } = new List<CircuitEdge>();
        public IList<CircuitEdge> Input { get; internal set; } = new List<CircuitEdge>();

        private string GetEdgeString(IList<CircuitEdge> edges)
        {
            var str = string.Empty;
            foreach (var edge in edges)
            {
                str += $"{edge.Tag} of type {edge.DirectsTo.Component.GetType()} , ";
            }
            return str;
        }

        public override string ToString()
        {
            return $" Type-> {Component.GetType()} {Environment.NewLine} State-> {CurrentState} {Environment.NewLine} Input({Input.Count})-> {GetEdgeString(Input)} {Environment.NewLine} Output({Output.Count})-> {GetEdgeString(Output)}";
        }

    }

}
