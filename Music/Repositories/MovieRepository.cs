using Microsoft.EntityFrameworkCore;
using Music.Data;
using Music.Models;
using Music.Repositories;


namespace Music.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MusicDbContext _context;
        public MovieRepository(MusicDbContext context) => _context = context;

        public async Task<IEnumerable<Movie>> GetAllAsync() => await _context.Movies.ToListAsync();
        public async Task<Movie> GetByIdAsync(int id) => await _context.Movies.FindAsync(id);
    }
}
