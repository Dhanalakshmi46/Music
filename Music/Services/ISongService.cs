using Music.DTOs;

namespace Music.Services
{
    public interface ISongService
    {
        Task<IEnumerable<SongDto>> GetAllAsync();
        Task<SongDto> GetByIdAsync(int id);
        Task<IEnumerable<SongDto>> GetByMovieAsync(string movieName);
        Task<IEnumerable<SongDto>> GetBySingerAsync(string singerName);
        Task<IEnumerable<SongDto>> GetByYearAsync(int year);
        Task<IEnumerable<SongDto>> SearchAsync(string keyword);
        Task<SongDto> CreateAsync(SongDto dto);
        Task<bool> UpdateAsync(int id, SongDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
