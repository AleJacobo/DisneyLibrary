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
    public class UsersRepository : IBaseRepository<User>
    {
        #region DataContext and Constructor
        private readonly DataContext context;
        public UsersRepository(DataContext context)
            => this.context = context;
        #endregion

        public async Task<IQueryable<User>> GetAll()
        {
            var response = await context.Users
                .Where(x => x.Status == true)
                .OrderBy(x => x.UserName)
                .ToListAsync();

            return(IQueryable<User>)response;
        }
        public async Task<User> GetbyId(int id)
        {
            var response = context.Users
                .Where(x => x.ID == id && x.Status==true)
                .FirstOrDefault();

            return response;
        }
        public User GetbyName(string name)
        {
            var response = context.Users
                .Where(x => x.UserName.Contains(name) && x.Status == true)
                .FirstOrDefault();

            return response;
        }
        public async Task Create(User entity)
        {
            await context.Users.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public async Task Update(User entity)
        {
            context.Users.Update(entity);
            await context.SaveChangesAsync();
        }

    }
}
