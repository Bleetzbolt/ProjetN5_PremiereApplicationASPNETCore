using Microsoft.EntityFrameworkCore;
using WebApplicationProjetN5.Models.Entities;

namespace WebApplicationProjetN5.Data
{
    public class GarageDBContext : DbContext
    {


        //Entities
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarFinish> CarFinishs { get; set; }
        public DbSet<Reparation> Reparations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Visitor> Visitors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GarageDB;Trusted_Connection=True;");
        }


    }
}
