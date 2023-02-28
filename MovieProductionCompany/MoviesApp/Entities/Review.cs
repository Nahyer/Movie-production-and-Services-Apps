using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Entities
{
    public class Review
    {
        // PK:
        public int ReviewId { get; set; }

        [Required(ErrorMessage = "Please enter a rating.")]
        [Range(1, 5, ErrorMessage = "Rating must be btween 1 and 5.")]
        public int? Rating { get; set; }

        public string? Comments { get; set; }

        // FK to Movie:
        public int MovieId { get; set; }

        // And nav to Movie:
        public Movie? Movie { get; set; }
    }
}
