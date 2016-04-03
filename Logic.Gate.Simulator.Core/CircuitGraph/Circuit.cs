using System;
using System.Collections.Generic;

namespace Logic.Gate.Simulator.Core.CircuitGraph
{
    public class Circuit
    {
        private readonly Dictionary<string, CircuitVertex> vertices = new Dictionary<string, CircuitVertex>();
        public IEnumerable<CircuitVertex> Vertices => vertices.Values;

        public Result<IDisposable> Add(string id, ICircuitComponent circuit)
        {
            DebugArgument.Require.NotNull(() => circuit);

            if (vertices.ContainsKey(id))
            {
                return Result.FailWith<IDisposable>(State.Error, $"A vertex with id {id} was already added.");
            }
            vertices.Add(id, new CircuitVertex(circuit));
            return Result.Ok(Disposable.Create(vertices, id));
        }

        public Result<IDisposable> Connect(string source, string destination)
        {
            if (vertices.ContainsKey(source))
            {
                return Result.FailWith<IDisposable>(State.NotFound, $"Unable to connect {source} to {destination}. {source} does not exist");
            }
            if (vertices.ContainsKey(destination))
            {
                return Result.FailWith<IDisposable>(State.NotFound, $"Unable to connect {source} to {destination}. {destination} does not exist");
            }

            var circuitEdge = new CircuitEdge(vertices[destination]);
            vertices[source].Edges.Add(circuitEdge);
            return Result.Ok(Disposable.Create(() =>
            {
                if (vertices.ContainsKey(source))
                {
                    vertices[source].Edges.Remove(circuitEdge);
                }
            }));
        }
    }
}

