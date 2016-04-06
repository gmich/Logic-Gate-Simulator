using Logic.Gate.Simulator.Core.Gates;
using Logic.Gate.Simulator.Core.Sources;

namespace Logic.Gate.Simulator.Core
{
    public interface IComponentFactory
    {
        IGate AND { get; }
        ISource OnOffSource { get; }
        IGate OR { get; }
    }
}