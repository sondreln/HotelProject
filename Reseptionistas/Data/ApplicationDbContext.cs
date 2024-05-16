using HotelClassLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Reseptionistas.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql( "Host=ider-database.westeurope.cloudapp.azure.com; Database=h666949; Port=5432; Username=h666949; Password=pass");
        }
 
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<HotelTask> HotelTask { get; set; }

        public DbSet<Bookings> Bookings { get; set; }
    }
}