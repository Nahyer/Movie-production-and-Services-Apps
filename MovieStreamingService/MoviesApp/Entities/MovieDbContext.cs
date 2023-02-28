using Microsoft.EntityFrameworkCore;

namespace MoviesApp.Entities
{
    // Define our DB context class that inherits from EF Core's base DbContext:
    public class MovieDbContext : DbContext
    {
        // Define a constructor that accepts a context options object that
        // is simply passed to the base class:
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        // Define a property for accessing/querying all movies from the DB:
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<ProductionStudio> Studios { get; set; }
        
       // public DbSet<WebhookData> EventName { get; set; }

        // override the protected OnModelCreating method to seed the DB w some movies
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre() { GenreId = "A", Name = "Action" },
                new Genre() { GenreId = "C", Name = "Comedy" },
                new Genre() { GenreId = "D", Name = "Drama" },
                new Genre() { GenreId = "H", Name = "Horror" },
                new Genre() { GenreId = "M", Name = "Musical" },
                new Genre() { GenreId = "R", Name = "RomCom" },
                new Genre() { GenreId = "S", Name = "SciFi" }
            );

            modelBuilder.Entity<ProductionStudio>().HasData(
                new ProductionStudio() { ProductionStudioId = 1, Name = "Warner Brothers"},
                new ProductionStudio() { ProductionStudioId = 2, Name = "MPC Productions" },
                new ProductionStudio() { ProductionStudioId = 3, Name = "Rollins and Joffe Productions" },
                new ProductionStudio() { ProductionStudioId = 4, Name = "Omni Zoetrope" }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie() { 
                    MovieId = 1,
                    Name = "Casablanca",
                    Year = 1942,
                    Rating = 5,
                    GenreId = "D",
                    ProductionStudioId = 1
                },
                new Movie() {
                    MovieId = 2,
                    Name = "Apocalypse Now",
                    Year = 1979,
                    Rating = 4,
                    GenreId = "A",
                    ProductionStudioId = 4
                },
                new Movie() {
                    MovieId = 3,
                    Name = "Annie Hall",
                    Year = 1977,
                    Rating = 5,
                    GenreId = "C",
                    ProductionStudioId = 3
                }
            );
        }
    }
}
