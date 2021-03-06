using Disney.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Disney.Infrastructure
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("data source = Localhost; " +
                                                 "initial catalog = DisneyAlkemyChallenge; " +
                                                 "Integrated Security = true");
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<MovieSerie> MoviesSeries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
