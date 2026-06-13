using Microsoft.AspNetCore.Mvc;
using UnitConversionApi.Models;
using UnitConversionApi.Services;

namespace UnitConversionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        private readonly IConversionService _conversionService;

        public ConversionController(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        /// <summary>
        /// Converts a value from one unit to another.
        /// </summary>
        /// <param name="request">Conversion request details.</param>
        /// <returns>Converted value.</returns>
        [HttpPost]
        public IActionResult Convert([FromBody] ConversionRequest request)
        {
            try
            {
                var response = _conversionService.Convert(request);

                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    message = "An unexpected error occurred."
                });
            }
        }
    }
}