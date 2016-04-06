using System.Collections.Generic;

namespace Logic.Gate.Simulator.Core.Sources
{
    internal class OnOffSource : ISource
    {
        public Result<IFlow> Trigger(IEnumerable<IFlow> inputs)
        {
            return Result.Ok(new Flow(Current) as IFlow);
        }

        public int Current { get; private set; }

        public void SwitchOff() => Current = 0;

        public void SwitchOn() => Current = 1;

        private class Flow : IFlow
        {
            public Flow(int weight) { Weight = weight; }
            public int Weight { get; }

        }
    }
}
