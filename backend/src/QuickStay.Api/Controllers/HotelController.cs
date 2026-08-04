using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickStay.Application.Interfaces;

namespace QuickStay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet("{hotelId}")]
        public async Task<IActionResult> GetHotelById(Guid hotelId)
        {
            var hotelResponse = await _hotelService.GetHotelByIdAsync(hotelId);
            return Ok(hotelResponse);
        }
    }
}
