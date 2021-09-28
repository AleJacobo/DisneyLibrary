using Disney.Domain.DTOs;
using Disney.Domain.Entities;
using Disney.Infrastructure.Interfaces;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Disney.Infrastructure.Repositories
{
    public class CharactersRepository : BaseRepository<Character>, IBaseRepository<Character>
    {
        #region Context and Constructor
        private readonly DataContext context;
        public CharactersRepository(DataContext context) : base(context) { }
        #endregion

        public async Task<IQueryable<Character>> GetbyAge(int age)
        {
            var response = await context.Characters
                .Where(x => x.Status == true && x.Age == age)
                .ToListAsync();

            return (IQueryable<Character>)response;
        }
        public async Task<IQueryable<Character>> GetbyMovieSerie(MovieSerieDTO movieSerieDTO)
        {
            var response = await context.MoviesSeries
                .Where(x => x.Name == movieSerieDTO.Name)
                .Include(x => x.associatedCharacter)
                             .OrderBy(x => x.associatedCharacter.Name)
                             .ToListAsync();

            return (IQueryable<Character>)response;
        }

        public bool Exists(Character entity)
        {
            bool response = false;

            var search = context.Characters
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
