using Disney.Domain.Enums;
using System;

namespace Disney.Domain.DTOs
{
    public class MovieSerieDTO
    {
        public string urlImage { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public eRating Rating { get; set; }
        public virtual CharacterDTO associatedCharacters { get; set; }
        public virtual GenreDTO associatedGenre { get; set; }
        public bool Status { get; set; }
    }
}
