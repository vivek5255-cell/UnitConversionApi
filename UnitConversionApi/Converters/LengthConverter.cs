namespace UnitConversionApi.Converters
{
    public static class LengthConverter
    {
        private static readonly Dictionary<string, double> LengthUnits =
            new()
            {
                { "meter", 1 },
                { "kilometer", 1000 },
                { "feet", 0.3048 },
                { "mile", 1609.34 }
            };

        public static double Convert(double value, string fromUnit, string toUnit)
        {
            fromUnit = fromUnit.ToLower();
            toUnit = toUnit.ToLower();

            if (!LengthUnits.ContainsKey(fromUnit))
                throw new ArgumentException($"Unsupported length unit: {fromUnit}");

            if (!LengthUnits.ContainsKey(toUnit))
                throw new ArgumentException($"Unsupported length unit: {toUnit}");

            double valueInMeters = value * LengthUnits[fromUnit];

            return valueInMeters / LengthUnits[toUnit];
        }
    }
}