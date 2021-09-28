using Disney.Domain.Entities;
using Disney.Infrastructure.Interfaces;
using System.Linq;

namespace Disney.Infrastructure.Repositories
{
    public class UsersRepository : BaseRepository<User>, IBaseRepository<User>
    {
        #region DataContext and Constructor
        private readonly DataContext context;
        public UsersRepository(DataContext context) : base(context) { }
        #endregion

        public bool Exists(User entity)
        {
            bool response = false;

            var search = context.Users
                .Where(x => x.Email.Contains(entity.Email)
                         || x.UserName.Contains(entity.UserName)
                         && x.Status == true)
                .FirstOrDefault();

            if (search == null)
            {
                response = true;
            }

            return response;
        }

    }
}
