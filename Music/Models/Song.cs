using Music.Models;

namespace Music.Models
{
    public class Song : BaseEntity
    {
        public string Title { get; set; }
        public int Year { get; set; }

        public int MovieId { get; set; }
        public string? MovieImage { get; set; }
        public Movie Movie { get; set; }
        public string Actor { get; set; }

        public int SingerId { get; set; }
        public Singer Singer { get; set; }

        public string MusicComposer { get; set; }
        public string SongUrl { get; set; }
    }
}
