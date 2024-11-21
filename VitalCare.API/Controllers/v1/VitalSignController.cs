using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VitalCare.API.Commands;
using VitalCare.API.Dtos;

namespace VitalCare.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class VitalSignController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VitalSignController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("upload")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UploadVitalSignResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadMeterReadings(IFormFile file)
        {
            // Validate the file
            if (file == null || file.Length == 0)
            {
                return BadRequest("The file is empty or missing.");
            }
            // Check if the file has a .csv extension
            if (!Path.GetExtension(file.FileName).Equals(".csv", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Invalid file format. Only CSV files are allowed.");
            }
            try
            {
                // Send the command to the handler
                var command = new UploadVitalSignCommand(file);
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while processing the file: {ex.Message}");
            }
        }
    }
}
