using Microsoft.EntityFrameworkCore;
using Music.Data;
using Music.Models;
using Music.Repositories;


namespace Music.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly MusicDbContext _context;
        public SongRepository(MusicDbContext context) => _context = context;

        public async Task<IEnumerable<Song>> GetAllAsync() =>
            await _context.Songs.Include(s => s.Movie).Include(s => s.Singer).ToListAsync();

        public async Task<Song> GetByIdAsync(int id) =>
            await _context.Songs.Include(s => s.Movie).Include(s => s.Singer)
                .FirstOrDefaultAsync(s => s.Id == id);

        public async Task<IEnumerable<Song>> GetByMovieAsync(string movieName) =>
            await _context.Songs.Include(s => s.Movie).Include(s => s.Singer)
                .Where(s => s.Movie.Name.Contains(movieName)).ToListAsync();

        public async Task<IEnumerable<Song>> GetBySingerAsync(string singerName) =>
            await _context.Songs.Include(s => s.Movie).Include(s => s.Singer)
                .Where(s => s.Singer.Name.Contains(singerName)).ToListAsync();

        public async Task<IEnumerable<Song>> GetByYearAsync(int year) =>
            await _context.Songs.Include(s => s.Movie).Include(s => s.Singer)
                .Where(s => s.Year == year).ToListAsync();

        public async Task<IEnumerable<Song>> SearchAsync(string keyword) =>
            await _context.Songs.Include(s => s.Movie).Include(s => s.Singer)
                .Where(s => s.Title.Contains(keyword)
                         || s.Movie.Name.Contains(keyword)
                         || s.Singer.Name.Contains(keyword))
                .ToListAsync();

        public async Task AddAsync(Song song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Song song)
        {
            _context.Songs.Update(song);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song != null)
            {
                _context.Songs.Remove(song);
                await _context.SaveChangesAsync();
            }
        }
    }
}
