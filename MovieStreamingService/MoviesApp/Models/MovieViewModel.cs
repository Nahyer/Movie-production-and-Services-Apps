using MoviesApp.Entities;

namespace MoviesApp.Models
{
    public class MovieViewModel
    {
	
		public List<Genre>? Genres { get; set; }

        public List<ProductionStudio>? Studios { get; set; }

        public Movie ActiveMovie { get; set; }
    }
}
