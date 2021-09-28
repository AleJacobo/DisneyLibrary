using Disney.Domain.DTOs;
using Disney.Domain.Entities;
using Disney.Infrastructure.Interfaces;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Disney.Infrastructure.Repositories
{
    public class MoviesSeriesRepository : BaseRepository<MovieSerie>, IBaseRepository<MovieSerie>
    {
        #region DataContext and Constructor
        private readonly DataContext context;
        public MoviesSeriesRepository(DataContext context) : base(context) { }
        #endregion

        public async Task<IQueryable<Character>> GetAssociatedCharacters(MovieSerieDTO movieSerieDTO)
        {
            var response = await context.MoviesSeries
                .Where(x => x.Name == movieSerieDTO.Name && x.Status == true)
                .Include(x => x.associatedCharacter)
                            .OrderBy(x => x.associatedCharacter.Name)
                            .ToListAsync();

            return (IQueryable<Character>)response;
        }
        public async Task<IQueryable<MovieSerie>> GetMovieByGenre(MovieSerieDTO movieSerieDTO)
        {
            var response = await context.MoviesSeries
                .Where(x => x.Name == movieSerieDTO.Name && x.Status == true)
                .Include(x => x.associatedGenre)
                            .OrderBy(x => x.associatedGenre.Name)
                            .ToListAsync();
            return (IQueryable<MovieSerie>)response;
        }
        public bool Exists(MovieSerie entity)
        {
            bool response = false;

            var search = context.MoviesSeries
                .Where(x => x.Name.Contains(entity.Name) && x.Status == true)
                .FirstOrDefault();

            if (search == null)
            {
                response = true;
            }

            return response;
        }
    }
}
