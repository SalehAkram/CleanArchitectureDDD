using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VitalCare.API.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class VitalSignController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            // Implement version-specific logic for version 2.0 of the MeterReading API here
            return Ok("This is version 2.0 of the MeterReading API.");
        }
    }
}
