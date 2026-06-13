using UnitConversionApi.Converters;
using UnitConversionApi.Models;

namespace UnitConversionApi.Services
{
    public class ConversionService : IConversionService
    {
        private readonly HashSet<string> _lengthUnits =
            new() { "meter", "kilometer", "feet", "mile" };

        private readonly HashSet<string> _weightUnits =
            new() { "kilogram", "gram", "pound" };

        private readonly HashSet<string> _temperatureUnits =
            new() { "celsius", "fahrenheit" };

        public ConversionResponse Convert(ConversionRequest request)
        {
            string fromUnit = request.FromUnit.ToLower();
            string toUnit = request.ToUnit.ToLower();

            double result;

            if (_lengthUnits.Contains(fromUnit) &&
                _lengthUnits.Contains(toUnit))
            {
                result = LengthConverter.Convert(
                    request.Value,
                    fromUnit,
                    toUnit);
            }
            else if (_weightUnits.Contains(fromUnit) &&
                     _weightUnits.Contains(toUnit))
            {
                result = WeightConverter.Convert(
                    request.Value,
                    fromUnit,
                    toUnit);
            }
            else if (_temperatureUnits.Contains(fromUnit) &&
                     _temperatureUnits.Contains(toUnit))
            {
                result = TemperatureConverter.Convert(
                    request.Value,
                    fromUnit,
                    toUnit);
            }
            else
            {
                throw new ArgumentException(
                    "Unsupported unit conversion.");
            }

            return new ConversionResponse
            {
                OriginalValue = request.Value,
                FromUnit = request.FromUnit,
                ToUnit = request.ToUnit,
                ConvertedValue = Math.Round(result, 4)
            };
        }
    }
}