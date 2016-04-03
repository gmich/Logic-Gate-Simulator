using System.Collections.Generic;

namespace Logic.Gate.Simulator.Core
{
    public interface ICircuitComponent
    {
        Result<IOutput> Trigger(IEnumerable<IInput> inputs);
    }
}
