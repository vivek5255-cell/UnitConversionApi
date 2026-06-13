namespace UnitConversionApi.Converters
{
    public static class WeightConverter
    {
        private static readonly Dictionary<string, double> WeightUnits =
            new()
            {
                { "kilogram", 1 },
                { "gram", 0.001 },
                { "pound", 0.453592 }
            };

        public static double Convert(double value, string fromUnit, string toUnit)
        {
            fromUnit = fromUnit.ToLower();
            toUnit = toUnit.ToLower();

            if (!WeightUnits.ContainsKey(fromUnit))
                throw new ArgumentException($"Unsupported weight unit: {fromUnit}");

            if (!WeightUnits.ContainsKey(toUnit))
                throw new ArgumentException($"Unsupported weight unit: {toUnit}");

            double valueInKilograms = value * WeightUnits[fromUnit];

            return valueInKilograms / WeightUnits[toUnit];
        }
    }
}