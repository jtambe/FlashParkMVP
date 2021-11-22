using Microsoft.EntityFrameworkCore;

namespace FlashParkMVP.DataModels
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<ParkingLot> ParkingLots{ get; set; }
        public DbSet<ParkingSpace> ParkingSpaces { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=FlashParkMVP;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingLot>().HasData(
                new ParkingLot() { ParkingLotId = 2, ParkingLotAddress = "Garage1" },
                new ParkingLot() { ParkingLotId = 3, ParkingLotAddress = "Garage2" },
                new ParkingLot() { ParkingLotId = 1, ParkingLotAddress = "Garage3" }
            );

            modelBuilder.Entity<ParkingSpace>().HasData(
               new ParkingSpace() { ParkingSpaceId = 1, ParkingLotId = 1, IsAvailable = true },
                new ParkingSpace() { ParkingSpaceId = 2, ParkingLotId = 1, IsAvailable = false },
                new ParkingSpace() { ParkingSpaceId = 3, ParkingLotId = 1, IsAvailable = true },
                new ParkingSpace() { ParkingSpaceId = 4, ParkingLotId = 1, IsAvailable = false },
                new ParkingSpace() { ParkingSpaceId = 5, ParkingLotId = 1, IsAvailable = true },

                new ParkingSpace() { ParkingSpaceId = 6, ParkingLotId = 2, IsAvailable = true },
                new ParkingSpace() { ParkingSpaceId = 7, ParkingLotId = 2, IsAvailable = false },
                new ParkingSpace() { ParkingSpaceId = 8, ParkingLotId = 2, IsAvailable = true },
                new ParkingSpace() { ParkingSpaceId = 9, ParkingLotId = 2, IsAvailable = true },
                new ParkingSpace() { ParkingSpaceId = 10, ParkingLotId = 2, IsAvailable = true },

                new ParkingSpace() { ParkingSpaceId = 11, ParkingLotId = 3, IsAvailable = false },
                new ParkingSpace() { ParkingSpaceId = 12, ParkingLotId = 3, IsAvailable = false },
                new ParkingSpace() { ParkingSpaceId = 13, ParkingLotId = 3, IsAvailable = true }
            );
        }
    }
    
}
