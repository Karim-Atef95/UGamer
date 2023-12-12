using UGamer.Models;

namespace UGamer.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Device> Devices { get; set; }

        public DbSet<GameDevice> GameDevices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Device>().HasData(
                new Device[]
                {
                    new Device { Id = 1, Name="Playstation", Icon="bi bi-playstation"},
                    new Device { Id = 2, Name="Xbox", Icon="bi bi-xbox"},
                    new Device { Id = 3, Name="Nintendo", Icon="bi bi-nintendo-switch"},
                    new Device { Id = 4, Name="PC", Icon="bi bi-pc-display"},
                });

            modelBuilder.Entity<Category>().HasData(
                new Category[]
                {
                    new Category {Id = 1, Name="Action"},
                    new Category {Id = 2, Name="Sports"},
                    new Category {Id = 3, Name="Adventure"},
                    new Category {Id = 4, Name="MMO"},
                    new Category {Id = 5, Name="Strategy"},
                    new Category {Id = 6, Name="Puzzle"},
                });

            modelBuilder.Entity<GameDevice>().HasKey(e => new { e.GameId, e.DeviceId });
            base.OnModelCreating(modelBuilder);

        }
    }
}
