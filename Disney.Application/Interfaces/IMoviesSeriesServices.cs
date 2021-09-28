using Disney.Domain.Common;
using Disney.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Application.Interfaces
{
    public interface IMoviesSeriesServices
    {
        Task<IEnumerable<MovieSerieDTO>> GetAllMoviesSeries();
        MovieSerieDTO GetMovieSerieByName(string name);
        Task<IEnumerable<MovieSerieDTO>> GetMovieSerieByGenre(MovieSerieDTO movieSerieDTO);
        Result CreateMovieSerie(MovieSerieDTO movieSerieDTO);
        Result UpdateMovieSerie(MovieSerieDTO movieSerieDTO);
        Result DeleteMovieSerie(MovieSerieDTO movieSerieDTO);
    }
}
