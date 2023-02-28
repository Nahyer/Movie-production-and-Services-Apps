using MoviesApp.Entities;

namespace MoviesApp.Models
{
    public class MoviesByGenreViewModel
    {
        public List<Movie>? Movies { get; set; }

        public string? ActiveGenreName { get; set; }
    }
}
