using AutoMapper;
using Disney.Application.Interfaces;
using Disney.Domain.Common;
using Disney.Domain.DTOs;
using Disney.Domain.Entities;
using Disney.Infrastructure.Interfaces;
using Disney.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Application.Services
{
    public class MoviesSeriesServices : IMoviesSeriesServices
    {
        #region Object and Constructor
        private readonly IMapper mapper;
        private readonly IBaseRepository<MovieSerie> baseRepository;
        private readonly MoviesSeriesRepository moviesSeriesRepository;

        public MoviesSeriesServices(IMapper mapper, IBaseRepository<MovieSerie> baseRepository, MoviesSeriesRepository moviesSeriesRepository)
        {
            this.mapper = mapper;
            this.baseRepository = baseRepository;
            this.moviesSeriesRepository = moviesSeriesRepository;
        }

        #endregion

        public async Task<IEnumerable<MovieSerieDTO>> GetAllMoviesSeries()
        {
            var response = await baseRepository.GetAll();
            var result = mapper.Map<IEnumerable<MovieSerieDTO>>(response);

            return result;
        }
        public MovieSerieDTO GetMovieSerieByName(string name)
        {
            var response = baseRepository.GetbyName(name);
            var result = mapper.Map<MovieSerieDTO>(response);

            return result;
        }
        public async Task<IEnumerable<MovieSerieDTO>> GetMovieSerieByGenre(MovieSerieDTO movieSerieDTO)
        {
            var request = await moviesSeriesRepository.GetMovieByGenre(movieSerieDTO);
            var result = mapper.Map<IEnumerable<MovieSerieDTO>>(request);

            return result;
        }
        public Result CreateMovieSerie(MovieSerieDTO movieSerieDTO)
        {
            var entity = mapper.Map<MovieSerie>(movieSerieDTO);
            bool confirmation = baseRepository.Exists(entity);

            if (confirmation == true)
                return new Result().Fail($"Ya existe un registro previo de dicha pelicula o serie");

            baseRepository.Create(entity);
            return new Result().Success($"Se ha agregado con exito al personaje {entity.Name} a la base de datos!");
        }
        public Result UpdateMovieSerie(MovieSerieDTO movieSerieDTO)
        {
            var entity = mapper.Map<MovieSerie>(movieSerieDTO);
            var confirmation = baseRepository.Exists(entity);

            if (confirmation == false)
                return new Result().NotFound();

            baseRepository.Update(entity);
            return new Result().Success($"Se ha actualizado la informacion de la pelicula/serie ");
        }
        public Result DeleteMovieSerie(MovieSerieDTO movieSerieDTO)
        {
            var entity = mapper.Map<MovieSerie>(movieSerieDTO);
            var confirmation = baseRepository.Exists(entity);

            if (confirmation == false)
                return new Result().NotFound();

            entity.Status = false;
            baseRepository.Update(entity);

            return new Result().Success($"Se ha borrado la pelicula/serie de la base de datos");
        }
    }
}
