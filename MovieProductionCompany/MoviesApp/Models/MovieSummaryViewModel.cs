using MoviesApp.Entities;

namespace MoviesApp.Models
{
    public class MovieSummaryViewModel : BaseMovieViewModel
    {
        public int NumberOfReviews { get; set; }

        public string? ActorsDisplayText { get; set; }
    }
}
