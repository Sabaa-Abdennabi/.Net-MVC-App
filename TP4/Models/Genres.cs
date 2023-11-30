namespace Movie.Models
{
    public class Genres
    {
        public int Id { get; set; }
        public string? GenreName { get; set; }
        public ICollection<Movies>? Movies { get; set; }
    }
}
