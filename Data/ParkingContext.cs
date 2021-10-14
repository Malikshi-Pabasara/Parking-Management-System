
using Microsoft.EntityFrameworkCore;

namespace ParkingManagementSystemApi.Data
{
    public class ParkingContext : DbContext
    {
        public ParkingContext(DbContextOptions<ParkingContext> options) : base(options) //pass options
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Park> Parks { get; set; }
        public DbSet<CarParking> Parking { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
