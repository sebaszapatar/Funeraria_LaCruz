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
        public DbSet<FunerariaCategory> FunerariaCategories { get; set; }
        public DbSet<FunerariaImage> FunerariaImages { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Plan> Plans { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Deceased> deceased { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex("CountryId", "Name").IsUnique();
            modelBuilder.Entity<City>().HasIndex("StateId", "Name").IsUnique();

            modelBuilder.Entity<Category>().HasIndex(y => y.Name).IsUnique();
            modelBuilder.Entity<FunerariaCategory>().HasIndex("CategoryId", "Name").IsUnique();
            modelBuilder.Entity<Product>().HasIndex("FunerariaCategoryId", "Name").IsUnique();

            modelBuilder.Entity<Employee>().HasIndex(x => x.Cedula).IsUnique();

            modelBuilder.Entity<Plan>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<Service>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<Deceased>().HasIndex(x => x.Cedula).IsUnique();
        }
    }
}

