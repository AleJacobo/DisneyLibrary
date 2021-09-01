using Disney.Domain.DTOs;
using Disney.Domain.Entities;
using Disney.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Infrastructure.Repositories
{
    public class GenresRepository : IBaseRepository<Genre>
    {
        #region DataContext and Constructor
        private readonly DataContext context;
        public GenresRepository(DataContext context) => 
            this.context = context;
        #endregion

        public async Task<IEnumerable<Genre>> GetAll()
        {
            var result = await context.Genres
                 .Where(x => x.Status == true)
                 .OrderBy(x => x.Name)
                 .ToListAsync();

            return (IQueryable<Genre>)result;
        }
        public async Task<Genre> GetbyId(int id)
        {
            var result = context.Genres
                .Where(x => x.ID == id)
                .FirstOrDefault();

            return result;
        }
        public async Task<IQueryable<MovieSerie>> GetMoviesSeriesbyGenre(GenreDTO genreDTO)
        {
            var result = await context.Genres
               .Where(x => x.Name == genreDTO.Name)
               .Include(x => x.associatedMovieSerie)
                            .OrderByDescending(x => x.associatedMovieSerie.ReleaseDate)
                            .ToListAsync();

            return (IQueryable<MovieSerie>)result;
        }

        public Genre GetbyName(string name)
        {
            var result = context.Genres
                .Where(x => x.Name.Contains(name) && x.Status == true)
                .FirstOrDefault();

            return result;
        }
        public async Task Create(Genre entity)
        {
            await context.Genres.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public async Task Update(Genre entity)
        {
            context.Genres.Update(entity);
            await context.SaveChangesAsync();
        }
        public bool GenreExists(Genre entity)
        {
            bool result = true;

            var search = context.Genres
                .Where(x => x.ID == entity.ID)
                .FirstOrDefault();

            if (search == null)
            {
                result = false;
            }

            return result;
        }


    }
}
