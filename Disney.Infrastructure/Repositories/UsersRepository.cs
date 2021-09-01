using Disney.Domain.Entities;
using Disney.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Infrastructure.Repositories
{
    public class UsersRepository : IBaseRepository<User>
    {
        #region DataContext and Constructor
        private readonly DataContext context;
        public UsersRepository(DataContext context)
            => this.context = context;
        #endregion

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<User> GetbyId(int id)
        {
            throw new NotImplementedException();
        }
        public User GetbyName(string name)
        {
            throw new NotImplementedException();
        }
        public Task Create(User entity)
        {
            throw new NotImplementedException();
        }
        public Task Update(User entity)
        {
            throw new NotImplementedException();
        }

    }
}
