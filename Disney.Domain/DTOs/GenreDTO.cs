namespace Disney.Domain.DTOs
{
    public class GenreDTO
    {
        public string Name { get; set; }
        public virtual MovieSerieDTO associatedMoviesSeries { get; set; }
        public bool Status { get; set; }
    }
}
