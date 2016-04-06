namespace Logic.Gate.Simulator.Core
{ 
    public interface ISource : ICircuitComponent
    {
        int Current { get; }

        void SwitchOff();

        void SwitchOn();
    }
}
