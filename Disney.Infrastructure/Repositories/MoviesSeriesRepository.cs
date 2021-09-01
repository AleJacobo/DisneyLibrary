﻿using Disney.Domain.DTOs;
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
    public class MoviesSeriesRepository : IBaseRepository<MovieSerie>
    {
        #region DataContext and Constructor
        private readonly DataContext context;
        public MoviesSeriesRepository(DataContext context)
            => this.context = context;
        #endregion

        public async Task<IQueryable<MovieSerie>> GetAll()
        {
            var response = await context.MoviesSeries
                 .Where(x => x.Status == true)
                 .OrderBy(x => x.Name)
                 .ToListAsync();

            return (IQueryable<MovieSerie>)response;
        }
        public async Task<MovieSerie> GetbyId(int id)
        {
            var response = context.MoviesSeries
                .Where(x => x.ID == id && x.Status == true)
                .FirstOrDefault();

            return response;
        }
        public MovieSerie GetbyName(string name)
        {
            var response = context.MoviesSeries
                .Where(x => x.Name.Contains(name) && x.Status == true)
                .FirstOrDefault();

            return response;
        }
        public async Task<IQueryable<Genres>> GetAssociatedCharacters(MovieSerieDTO movieSerieDTO)
        {
            var response = await context.MoviesSeries
                .Where(x => x.Name == movieSerieDTO.Name)
                .Include(x => x.associatedCharacter)
                            .OrderBy(x => x.associatedCharacter.Name)
                            .ToListAsync();

            return (IQueryable<Genres>)response;
        }
        public async Task Create(MovieSerie entity)
        {
            await context.MoviesSeries.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public async Task Update(MovieSerie entity)
        {
            context.MoviesSeries.Update(entity);
            await context.SaveChangesAsync();
        }
        public bool MovieSerieExists(MovieSerie entity)
        {
            bool response = true;

            var search = context.MoviesSeries
                .Where(x => x.ID == entity.ID)
                .FirstOrDefault();

            if (search == null)
            {
                response = false;
            }

            return response;
        }
    }
}
