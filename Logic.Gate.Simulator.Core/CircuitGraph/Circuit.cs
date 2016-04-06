using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Gate.Simulator.Core
{
    public class Circuit
    {
        private readonly IComponentFactory factory;
        private readonly  Dictionary<string, CircuitVertex> vertices = new Dictionary<string, CircuitVertex>();

        public Circuit(IComponentFactory factory)
        {
            this.factory = factory;
        }

        public Result Transform<Component>(string id, Action<Component> componentTransformer)
            where Component : class, ICircuitComponent
        {
            DebugArgument.Require.NotNull(() => componentTransformer);
            if (!vertices.ContainsKey(id))
            {
                return Result.FailWith(State.NotFound, $"Unable to find component with id {id}");
            }
            var component = vertices[id] as Component;
            if (component == null)
            {
                return Result.FailWith(State.Error, $"Component with id {id} was not of type {typeof(Component)}");
            }

            componentTransformer(component);
            return Result.Ok();
        }

        public Result<IDisposable> Add(string id, Func<IComponentFactory, ICircuitComponent> circuit)
        {
            DebugArgument.Require.NotNull(() => circuit);

            if (vertices.ContainsKey(id))
            {
                return Result.FailWith<IDisposable>(State.Error, $"A vertex with id {id} was already added.");
            }
            vertices.Add(id, new CircuitVertex(circuit(factory)));
            return Result.Ok(Disposable.Create(vertices, id));
        }

        public Result<IDisposable> Connect(string source, string destination)
        {
            if (!vertices.ContainsKey(source))
            {
                return Result.FailWith<IDisposable>(State.NotFound, $"Unable to connect {source} to {destination}. {source} does not exist");
            }
            if (!vertices.ContainsKey(destination))
            {
                return Result.FailWith<IDisposable>(State.NotFound, $"Unable to connect {source} to {destination}. {destination} does not exist");
            }

            var circuitOutput = new CircuitEdge(vertices[destination],destination);
            vertices[source].Output.Add(circuitOutput);
            var circuitInput = new CircuitEdge(vertices[source],source);
            vertices[destination].Input.Add(circuitInput);

            return Result.Ok(Disposable.Create(() =>
            {
                if (vertices.ContainsKey(source))
                {
                    vertices[source].Output.Remove(circuitOutput);
                }
                if (vertices.ContainsKey(destination))
                {
                    vertices[destination].Input.Remove(circuitInput);
                }
            }));
        }

        public string Graph()
        {
            var builder = new StringBuilder();
            foreach(var vertex in vertices)
            {
                builder.AppendLine($"Component: {vertex.Key}");
                builder.AppendLine(vertex.Value.ToString());
            }
            return builder.ToString();
        }
    }
}

