using Music.Models;

namespace Music.Repositories
{
    public interface ISingerRepository
    {
        Task<IEnumerable<Singer>> GetAllAsync();
        Task<Singer> GetByIdAsync(int id);
    }
}
