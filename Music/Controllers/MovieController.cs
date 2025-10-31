using Microsoft.AspNetCore.Mvc;
using Music.Services;

namespace Music.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _service;
        public MovieController(IMovieService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _service.GetByIdAsync(id);
            return movie == null ? NotFound() : Ok(movie);
        }
    }
}
