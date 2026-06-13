using UnitConversionApi.Models;
using UnitConversionApi.Services;

namespace UnitConversionApi.Tests
{
    public class ConversionServiceTests
    {
        private readonly ConversionService _conversionService;

        public ConversionServiceTests()
        {
            _conversionService = new ConversionService();
        }

        [Fact]
        public void Convert_MeterToFeet_ReturnsCorrectValue()
        {
            var request = new ConversionRequest
            {
                Value = 10,
                FromUnit = "meter",
                ToUnit = "feet"
            };

            var result = _conversionService.Convert(request);

            Assert.Equal(32.8084, result.ConvertedValue, 4);
        }

        [Fact]
        public void Convert_KilometerToMile_ReturnsCorrectValue()
        {
            var request = new ConversionRequest
            {
                Value = 1,
                FromUnit = "kilometer",
                ToUnit = "mile"
            };

            var result = _conversionService.Convert(request);

            Assert.Equal(0.6214, result.ConvertedValue, 4);
        }

        [Fact]
        public void Convert_CelsiusToFahrenheit_ReturnsCorrectValue()
        {
            var request = new ConversionRequest
            {
                Value = 100,
                FromUnit = "celsius",
                ToUnit = "fahrenheit"
            };

            var result = _conversionService.Convert(request);

            Assert.Equal(212, result.ConvertedValue);
        }

        [Fact]
        public void Convert_KilogramToPound_ReturnsCorrectValue()
        {
            var request = new ConversionRequest
            {
                Value = 5,
                FromUnit = "kilogram",
                ToUnit = "pound"
            };

            var result = _conversionService.Convert(request);

            Assert.Equal(11.0231, result.ConvertedValue, 4);
        }

        [Fact]
        public void Convert_InvalidUnits_ThrowsArgumentException()
        {
            var request = new ConversionRequest
            {
                Value = 100,
                FromUnit = "abc",
                ToUnit = "xyz"
            };

            Assert.Throws<ArgumentException>(() =>
                _conversionService.Convert(request));
        }
    }
}