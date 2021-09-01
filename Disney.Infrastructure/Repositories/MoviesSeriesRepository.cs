using Disney.Domain.Entities;
using Disney.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
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

        public Task<IEnumerable<MovieSerie>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<MovieSerie> GetbyId(int id)
        {
            throw new NotImplementedException();
        }
        public MovieSerie GetbyName(string name)
        {
            throw new NotImplementedException();
        }
        public Task Create(MovieSerie entity)
        {
            throw new NotImplementedException();
        }
        public Task Update(MovieSerie entity)
        {
            throw new NotImplementedException();
        }

    }
}
