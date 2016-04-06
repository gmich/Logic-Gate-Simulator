using Autofac;
using Logic.Gate.Simulator.Core.Gates;
using Logic.Gate.Simulator.Core.Sources;

namespace Logic.Gate.Simulator.Core
{
    public class CircuitSimulator
    {
        internal IContainer Container { get; }
        private CircuitSimulator()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AND>().AsSelf();
            builder.RegisterType<OR>().AsSelf();
            builder.RegisterType<OnOffSource>().AsSelf();
            builder.RegisterType<ComponentFactory>().As<IComponentFactory>();
            builder.RegisterType<Circuit>().AsSelf();

            Container = builder.Build();
        }

        public static Circuit Bootstrap()
        {
            return new CircuitSimulator().Container.Resolve<Circuit>();
        }

    }
}
