using MoviesApp.Entities;

namespace MoviesApp.Models
{
    public class MovieDetailViewModel : BaseMovieViewModel
    {
        public Review? NewReview { get; set; }
    }
}
