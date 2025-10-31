using Music.DTOs;

namespace Music.Services
{
    public interface ISingerService
    {
        Task<IEnumerable<SingerDto>> GetAllAsync();
        Task<SingerDto> GetByIdAsync(int id);
    }
}
