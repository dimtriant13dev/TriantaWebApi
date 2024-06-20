using Microsoft.EntityFrameworkCore;
using TriantaWeb.API.Models.Domain;

namespace TriantaWeb.API.Data
{
    public class TriantaDbContext : DbContext
    {
        //DbContext communicates with the database.
        public TriantaDbContext(DbContextOptions<TriantaDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        //DbSet Represent Entinties 

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<Image> Images { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data for Difficalty

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.NewGuid(),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.NewGuid(),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.NewGuid(),
                    Name = "Hard"
                },
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            //seed Data For Regions

            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.NewGuid(),
                    Code = "ACK",
                    Name= "ACKLAND",
                    RegionImageUrl = null,
                },
                new Region()
                {
                    Id = Guid.NewGuid(),
                    Code = "EK",
                    Name= "EKLAND",
                    RegionImageUrl = null,
                },
                new Region()
                {
                    Id = Guid.NewGuid(),
                    Code = "AML",
                    Name= "AMLAND",
                    RegionImageUrl = null,
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
