using Microsoft.AspNetCore.Mvc;
using Music.Services;

namespace Music.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SingerController : ControllerBase
    {
        private readonly ISingerService _service;
        public SingerController(ISingerService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var singer = await _service.GetByIdAsync(id);
            return singer == null ? NotFound() : Ok(singer);
        }
    }
}
