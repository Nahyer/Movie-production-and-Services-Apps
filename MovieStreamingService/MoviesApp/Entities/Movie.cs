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

        [Required(ErrorMessage = "Please enter a rating.")]
        [Range(1, 5, ErrorMessage = "Rating must be btween 1 and 5.")]
        public int ? Rating { get; set; }

        // Add a Genre by adding "a foreign key relationship". We do this by adding
        // BOTH an id prop that is named to reflect the FK relationship (i.e. the name
        // here must be the PK name in the Genre class) AND we add a full Genre object
        // as a 2nd prop
        [Required(ErrorMessage = "Please specify a genre.")]
        public string? GenreId { get; set; }

        public Genre? Genre { get; set; }

        [Required(ErrorMessage = "Please specify a production studio.")]
        public int? ProductionStudioId { get; set; }
         
        public ProductionStudio? ProductionStudio { get; set; }

    }
}
