using Disney.Domain.DTOs;
using Disney.Domain.Entities;
using Disney.Infrastructure.Interfaces;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Disney.Infrastructure.Repositories
{
    public class GenresRepository : BaseRepository<Genre>, IBaseRepository<Genre>
    {
        #region DataContext and Constructor
        private readonly DataContext context;
        public GenresRepository(DataContext context) : base(context) { }
        #endregion

        public async Task<IQueryable<MovieSerie>> GetMoviesSeriesbyGenre(GenreDTO genreDTO)
        {
            var response = await context.Genres
               .Where(x => x.Name == genreDTO.Name)
               .Include(x => x.associatedMovieSerie)
                            .OrderByDescending(x => x.associatedMovieSerie.ReleaseDate)
                            .ToListAsync();

            return (IQueryable<MovieSerie>)response;
        }
        public bool Exists(Genre entity)
        {
            bool response = false;

            var search = context.Genres
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
