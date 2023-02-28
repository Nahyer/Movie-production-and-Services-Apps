using MoviesApp.Entities;

namespace MoviesApp.Models
{
    public class BaseMovieViewModel
    {
        public Movie? ActiveMovie { get; set; }

        public double AverageRating { get; set; }
    }
}
