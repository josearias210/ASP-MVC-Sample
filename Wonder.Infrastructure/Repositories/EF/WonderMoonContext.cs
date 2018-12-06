using System.Data.Entity;
using Wonder.Core.Models;
using Wonder.Infrastructure.Seeders;

namespace Wonder.Infrastructure.EF
{
    public class WonderMoonContext : DbContext
    {
        public WonderMoonContext() : base("WonderMoonContext")
        {
            var db = new SeederInitalize();
            Database.SetInitializer(db);
        }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().HasIndex(x => x.Name).IsUnique();
        }

    }
}
