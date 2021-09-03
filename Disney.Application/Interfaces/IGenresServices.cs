using Disney.Domain.Common;
using Disney.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Application.Interfaces
{
    public interface IGenresServices
    {
        Task<IEnumerable<GenreDTO>> GetAllGenres();
        Task<IEnumerable<MovieSerieDTO>> GetMovieSeriebyGenre(GenreDTO genreDTO);
        Result CreateGenre(GenreDTO genreDTO);
        Result UpdateGenre(GenreDTO genreDTO);
        Result DeleteGenre(GenreDTO genreDTO);

    }
}
