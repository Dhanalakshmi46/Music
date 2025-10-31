using Microsoft.AspNetCore.Mvc;
using Music.DTOs;
using Music.Services;


namespace Music.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongController : ControllerBase
    {
        private readonly ISongService _service;
        public SongController(ISongService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var song = await _service.GetByIdAsync(id);
            return song == null ? NotFound() : Ok(song);
        }

        [HttpGet("movie/{movie}")]
        public async Task<IActionResult> GetByMovie(string movie) => Ok(await _service.GetByMovieAsync(movie));

        [HttpGet("singer/{singer}")]
        public async Task<IActionResult> GetBySinger(string singer) => Ok(await _service.GetBySingerAsync(singer));

        [HttpGet("year/{year}")]
        public async Task<IActionResult> GetByYear(int year) => Ok(await _service.GetByYearAsync(year));

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string q) => Ok(await _service.SearchAsync(q));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SongDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SongDto dto)
        {
            var updatedSong = await _service.UpdateAsync(id, dto); 
            if (updatedSong == null)
                return NotFound();

            return Ok(updatedSong); 
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok)
                return NotFound();

            return Ok(new { message ="Successfully Deleted" });
        }
    }
}
