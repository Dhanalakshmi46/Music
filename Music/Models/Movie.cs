using Music.Models;

namespace Music.Models
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public string? MovieImage { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
