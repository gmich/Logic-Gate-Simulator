namespace Logic.Gate.Simulator.Core
{
    public static class ClassExtensions
    {
        public static TAsserted Assert<TAsserted>(this TAsserted asserted)
        {
            InternalAssert(asserted);
            return asserted;
        }

        private static void InternalAssert<TAsserted>(this TAsserted asserted)
        {
            var propertyInfos = asserted.GetType().GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                var customAttributes = propertyInfo.GetCustomAttributes(true);
                var value = propertyInfo.GetValue(asserted);
                foreach (var customAttribute in customAttributes)
                {
                    if (customAttribute is AssertAttribute)
                    {
                        switch (((AssertAttribute)customAttribute).AssertionType)
                        {
                            case That.IsNotNull:
                                Argument.Require.NotNull(() => value);
                                break;
                            case That.IsNotNullOrEmpty:
                                var strValue = value as string;
                                Argument.Require.NotNullOrEmpty(() => strValue);
                                break;
                        }
                    }
                }
                if (value != null)
                {
                    var valueType = value.GetType();
                    if (!valueType.IsValueType && valueType != typeof(string))
                    {
                        value.InternalAssert();
                    }
                }
            }
        }
    }
}

