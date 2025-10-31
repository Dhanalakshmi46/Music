namespace Music.DTOs
{
    public class SongDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string? MovieImage { get; set; }

        public string Movie { get; set; }
        public string Actor { get; set; }
        public string Singer { get; set; }
        public string MusicComposer { get; set; }
        public string SongUrl { get; set; }
    }
}
