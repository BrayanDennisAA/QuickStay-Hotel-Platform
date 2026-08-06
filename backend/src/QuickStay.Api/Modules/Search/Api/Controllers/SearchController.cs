using Microsoft.AspNetCore.Mvc;
using QuickStay.Api.Modules.Search.Application.Interfaces;

namespace QuickStay.Api.Modules.Search.Api.Controllers;

[ApiController]
[Route("api/search")]
public class SearchController : ControllerBase
{
    private readonly ISearchService _searchService;

    public SearchController(ISearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpGet("hotels")]
    public async Task<IActionResult> SearchHotels(
        [FromQuery] string city,
        [FromQuery] DateOnly checkIn,
        [FromQuery] DateOnly checkOut,
        CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(city))
            return BadRequest("city is required");

        if (checkOut <= checkIn)
            return BadRequest("checkOut must be greater than checkIn");

        var result = await _searchService.SearchHotelsAsync(city, checkIn, checkOut, ct);
        return Ok(result);
    }
}