using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Entities
{
    public class Movie
    {
        // EF Core will configure this to be an auto-incremented primary key:
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a year.")]
        [Range(1850, int.MaxValue, ErrorMessage = "Year must be after 1850.")]
        public int? Year { get; set; }

        // Add a Genre by adding "a foreign key relationship". We do this by adding
        // BOTH an id prop that is named to reflect the FK relationship (i.e. the name
        // here must be the PK name in the Genre class) AND we add a full Genre object
        // as a 2nd prop
        [Required(ErrorMessage = "Please specify a genre.")]
        public string? GenreId { get; set; }

        // Genre nav'n prop:
        public Genre? Genre { get; set; }

        // nav to all reviews of this movie:
        public ICollection<Review>? Reviews { get; set; }

        // Casting nav'g prop:
        public ICollection<Casting>? Castings { get; set; }
    }
}
