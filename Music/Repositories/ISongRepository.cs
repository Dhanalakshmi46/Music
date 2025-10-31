using Music.Models;

namespace Music.Repositories
{
    public interface ISongRepository
    {
        Task<IEnumerable<Song>> GetAllAsync();
        Task<Song> GetByIdAsync(int id);
        Task<IEnumerable<Song>> GetByMovieAsync(string movieName);
        Task<IEnumerable<Song>> GetBySingerAsync(string singerName);
        Task<IEnumerable<Song>> GetByYearAsync(int year);
        Task<IEnumerable<Song>> SearchAsync(string keyword);
        Task AddAsync(Song song);
        Task UpdateAsync(Song song);
        Task DeleteAsync(int id);
    }
}
