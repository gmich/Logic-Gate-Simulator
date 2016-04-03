using System.Collections.Generic;

namespace Logic.Gate.Simulator.Core
{
    public interface ICircuitComponent
    {
        Result<IFlow> Trigger(IEnumerable<IFlow> inputs);
    }
}
