using Music.DTOs;

namespace Music.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetAllAsync();
        Task<MovieDto> GetByIdAsync(int id);
    }
}
