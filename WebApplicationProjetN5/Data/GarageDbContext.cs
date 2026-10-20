using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationProjetN5.Models.Entities;

namespace WebApplicationProjetN5.Data
{
    public class GarageDBContext : IdentityDbContext<ApplicationUser>
    {
        public GarageDBContext(DbContextOptions<GarageDBContext> options)
       : base(options)
        {
        }

        //Entities
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarFinish> CarFinishes { get; set; }
        public DbSet<Reparation> Reparations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Visitor> Visitors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GarageDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure relationships and constraints here if needed
            modelBuilder.Entity<CarModel>()
                .HasMany(c => c.CarFinishes)
                .WithMany(cf => cf.CarModels);
            
            modelBuilder.Entity<Car>()
                .Property(c => c.PurchasePrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Car>()
                .Property(c => c.SellingPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Car>()
                .Property(c => c.ReparationCost)
                .HasPrecision(18, 2);


        }
    }
}