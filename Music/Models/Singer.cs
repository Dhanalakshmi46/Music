using Music.Models;

namespace Music.Models
{
    public class Singer : BaseEntity
    {
        public string Name { get; set; }
        public string? Genre { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
