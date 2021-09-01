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
    public class CharactersRepository : IBaseRepository<Character>
    {
        #region DataContext and Constructor
        private readonly DataContext context;
        public CharactersRepository(DataContext context)
            => this.context = context;
        #endregion

        public async Task<IQueryable<Character>> GetAll()
        {
            var response = await context.Characters
                .Where(x => x.Status == true)
                .OrderBy(x => x.Name)
                .ToListAsync();

            return (IQueryable<Character>)response;
        }
        public Character GetbyName(string name)
        {
            var response = context.Characters
                .Where(x => x.Name.Contains(name) && x.Status == true)
                .FirstOrDefault();

            return response;
        }
        public async Task<Character> GetbyId(int id)
        {
            var response = context.Characters
                .Where(x => x.ID == id)
                .FirstOrDefault();

            return response;
        }
        public async Task<IQueryable<Character>> GetbyAge(int age)
        {
            var response =  await context.Characters
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
        public async Task Create(Character entity)
        {
            await context.Characters.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public async Task Update(Character entity)
        {
            context.Characters.Update(entity);
            await context.SaveChangesAsync();
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
