using System;

namespace Logic.Gate.Simulator.Core
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class AssertAttribute : Attribute
    {
        public That AssertionType { get; }

        public AssertAttribute(That assertionType)
        {
            AssertionType = assertionType;
        }
    }

    public enum That
    {
        IsNotNull,
        IsNotNullOrEmpty
    }
}
