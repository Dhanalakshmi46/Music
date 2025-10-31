using Microsoft.EntityFrameworkCore;
using Music.Data;
using Music.Models;
using Music.Repositories;


namespace Music.Repositories
{
    public class SingerRepository : ISingerRepository
    {
        private readonly MusicDbContext _context;
        public SingerRepository(MusicDbContext context) => _context = context;

        public async Task<IEnumerable<Singer>> GetAllAsync() => await _context.Singers.ToListAsync();
        public async Task<Singer> GetByIdAsync(int id) => await _context.Singers.FindAsync(id);
    }
}
