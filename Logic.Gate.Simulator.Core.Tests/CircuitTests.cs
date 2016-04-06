using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Gate.Simulator.Core.Tests
{
    [TestClass]
    public class CircuitTests
    {
        [TestMethod]
        public void Circuit_ConnectionsTest()
        {
            var circuit = CircuitSimulator.Bootstrap();

            //component tags
            string and = "AND_Gate";
            string or = "OR_Gate";
            string onSource = "ON_Source";
            string offSource = "OFF_Source";

            //add components to circuit
            circuit.Add(and, f => f.AND);
            circuit.Add(or, f => f.OR);
            circuit.Add(onSource, f => f.OnOffSource);
            circuit.Add(offSource, f => f.OnOffSource);

            //transform
            circuit.Transform<ISource>(onSource, s => s.SwitchOn());
            
            //connect 
            circuit.Connect(onSource, and);
            circuit.Connect(offSource, and);
            circuit.Connect(onSource, or);
            circuit.Connect(and, or);

            var graph = circuit.Graph();
        }
    }
}
