using Disney.Domain.Entities;
using Disney.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
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

        public Task<IEnumerable<Genre>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<Genre> GetbyId(int id)
        {
            throw new NotImplementedException();
        }
        public Genre GetbyName(string name)
        {
            throw new NotImplementedException();
        }
        public Task Create(Genre entity)
        {
            throw new NotImplementedException();
        }
        public Task Update(Genre entity)
        {
            throw new NotImplementedException();
        }


    }
}
