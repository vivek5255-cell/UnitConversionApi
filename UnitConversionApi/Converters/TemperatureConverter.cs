namespace UnitConversionApi.Converters
{
    public static class TemperatureConverter
    {
        public static double Convert(double value, string fromUnit, string toUnit)
        {
            fromUnit = fromUnit.ToLower();
            toUnit = toUnit.ToLower();

            if (fromUnit == toUnit)
                return value;

            if (fromUnit == "celsius" && toUnit == "fahrenheit")
                return (value * 9 / 5) + 32;

            if (fromUnit == "fahrenheit" && toUnit == "celsius")
                return (value - 32) * 5 / 9;

            throw new ArgumentException("Unsupported temperature conversion.");
        }
    }
}