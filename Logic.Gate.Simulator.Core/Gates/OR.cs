using System.Collections.Generic;

namespace Logic.Gate.Simulator.Core.Gates
{
    internal class OR : IGate
    {

        public Result<IFlow> Trigger(IEnumerable<IFlow> inputs)
        {
            foreach (var input in inputs)
            {
                if (input.HasValue())
                    return Result.Ok(GateFlow.True as IFlow);
            }
            return Result.Ok(GateFlow.False as IFlow);
        }
    }
}
