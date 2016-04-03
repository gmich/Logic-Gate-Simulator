namespace Logic.Gate.Simulator.Core
{
    public static class FlowExtensions
    {
        public static bool HasValue(this IFlow flow)
        {
            return flow.Weight > 0;
        }
    }
}
