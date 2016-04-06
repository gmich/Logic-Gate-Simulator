using Autofac;
using Logic.Gate.Simulator.Core.Gates;
using Logic.Gate.Simulator.Core.Sources;

namespace Logic.Gate.Simulator.Core
{
    internal class ComponentFactory : IComponentFactory
    {
        private readonly IComponentContext context;
        public ComponentFactory(IComponentContext context)
        {
            DebugArgument.Require.NotNull(() => context);
            this.context = context;
        }

        public IGate AND => context.Resolve<AND>();
        public IGate OR => context.Resolve<OR>();
        public ISource OnOffSource => context.Resolve<OnOffSource>();
    }
}
