using Microsoft.AspNetCore.Mvc;
using QuickStay.Api.Modules.Availability.Application.Interfaces;

namespace QuickStay.Api.Modules.Availability.Api.Controllers;

[ApiController]
[Route("api/availability")]
public class AvailabilityController : ControllerBase
{
    private readonly IAvailabilityService _availabilityService;

    public AvailabilityController(IAvailabilityService availabilityService)
    {
        _availabilityService = availabilityService;
    }

    [HttpGet]
    public async Task<IActionResult> Check(
        [FromQuery] Guid hotelId,
        [FromQuery] DateOnly checkIn,
        [FromQuery] DateOnly checkOut,
        CancellationToken ct)
    {
        if (hotelId == Guid.Empty)
            return BadRequest("hotelId is required");

        if (checkOut <= checkIn)
            return BadRequest("checkOut must be greater than checkIn");

        var result = await _availabilityService.CheckAvailabilityAsync(hotelId, checkIn, checkOut, ct);
        return Ok(result);
    }
}