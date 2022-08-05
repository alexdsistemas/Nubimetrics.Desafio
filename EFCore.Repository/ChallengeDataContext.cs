using Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repository
{
    public class ChallengeDataContext : DbContext
    {

        public ChallengeDataContext(DbContextOptions<ChallengeDataContext> options) : base(options)
        {
        }
        // una por cada tabla de la base de datos
        public DbSet<User> Users => Set<User>();
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChallengeDataContext).Assembly);


        }

    }
}