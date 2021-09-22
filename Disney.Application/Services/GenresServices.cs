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
    public class GenresServices : IGenresServices
    {
        #region Objects and Constructors
        private readonly IMapper mapper;
        private readonly IBaseRepository<Genre> baseRepository;
        private readonly GenresRepository genreRepository;

        public GenresServices(IMapper mapper, IBaseRepository<Genre> baseRepository, GenresRepository genresRepository)
        {
            this.mapper = mapper;
            this.baseRepository = baseRepository;
            this.genreRepository = genresRepository;
        }

        #endregion

        public async Task<IEnumerable<GenreDTO>> GetAllGenres()
        {
            var response = await baseRepository.GetAll();
            var result = mapper.Map<IEnumerable<GenreDTO>>(response);

            return result;
        }
        public async Task<IEnumerable<MovieSerieDTO>> GetMovieSeriebyGenre(GenreDTO genreDTO)
        {
            var response = await genreRepository.GetMoviesSeriesbyGenre(genreDTO);
            var result = mapper.Map<IEnumerable<MovieSerieDTO>>(response);

            return result;
        }
        public Result CreateGenre(GenreDTO genreDTO)
        {
            var entity = mapper.Map<Genre>(genreDTO);
            bool confirmation = baseRepository.Exists(entity);

            if (confirmation == true)
                return new Result().Fail($"Ya existe un registro previo de dicho genero");

            baseRepository.Create(entity);
            return new Result().Success($"Se ha agregado con exito el genero {entity.Name} a la base de datos!");
        }
        public Result UpdateGenre(GenreDTO genreDTO)
        {
            var entity = mapper.Map<Genre>(genreDTO);
            var confirmation = baseRepository.Exists(entity);

            if (confirmation == false)
                return new Result().NotFound();

            baseRepository.Update(entity);
            return new Result().Success($"Se ha actualizado la informacion del genero");
        }
        public Result DeleteGenre(GenreDTO genreDTO)
        {
            var entity = mapper.Map<Genre>(genreDTO);
            var confirmation = baseRepository.Exists(entity);

            if (confirmation == false)
                return new Result().NotFound();

            entity.Status = false;
            baseRepository.Update(entity);

            return new Result().Success($"Se ha borrado el genero de la base de datos");
        }

    }
}
