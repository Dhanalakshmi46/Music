using Microsoft.EntityFrameworkCore;
using Music.Models;

namespace Music.Data
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options) { }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Singer> Singers { get; set; }
    }
}
