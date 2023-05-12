using Microsoft.EntityFrameworkCore;
using Funeraria_LaCruz.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Funeraria_LaCruz.API.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<City> Cities { get; set; }



        public DbSet<Category> Categories { get; set; }


        public DbSet<Service> Medicines { get; set; }

        public DbSet<FunerariaCategory> FunerariaCategories { get; set; }

        public DbSet<FunerariaImage> MedicineImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex("CountryId", "Name").IsUnique();
            modelBuilder.Entity<City>().HasIndex("StateId", "Name").IsUnique();

            modelBuilder.Entity<Category>().HasIndex(y => y.Name).IsUnique();
            modelBuilder.Entity<Service>().HasIndex(x => x.Name).IsUnique();
        }
    }
}

