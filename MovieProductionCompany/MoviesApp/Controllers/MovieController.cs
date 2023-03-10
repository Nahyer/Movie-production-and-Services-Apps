using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using MoviesApp.Entities;
using MoviesApp.Models;
using System.Text;

namespace MoviesApp.Controllers
{
    public class MovieController : Controller
    {
        
        public MovieController(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        [HttpGet("/movies")]
        public IActionResult GetAllMovies()
        {
            var allMovieSummaries = _movieDbContext.Movies.Include(m => m.Genre)
                .Include(m => m.Reviews)
                .Include(m => m.Castings).ThenInclude(c => c.Actor)
                .OrderBy(m => m.Name)
                .Select(m => new MovieSummaryViewModel() {
                    ActiveMovie = m,
                    NumberOfReviews = m.Reviews.Count,
                    AverageRating = m.Reviews.Average(r => r.Rating).GetValueOrDefault(),
                    ActorsDisplayText = GetActorsDisplayText(m)
                }).ToList();

            return View("Items", allMovieSummaries);
        }

        [HttpGet("/movies/genres/{genreId}")]
        public IActionResult GetMoviesByGenreId(string genreId)
        {
            var activeGenre = _movieDbContext.Genres.Where(g => g.GenreId == genreId).FirstOrDefault();
            var moviesInGenre = _movieDbContext.Movies.Include(m => m.Genre).Where(m => m.GenreId == genreId).OrderBy(m => m.Name).ToList();

            MoviesByGenreViewModel moviesByGenreViewModel = new MoviesByGenreViewModel() {
                Movies = moviesInGenre,
                ActiveGenreName = activeGenre.Name
            };

            return View("ItemsByGenre", moviesByGenreViewModel);
        }

        [HttpGet("/movies/add-request")]
        public async Task<IActionResult> GetAddMovieRequestAsync()
        {
            MovieViewModel movieViewModel = new()
            {
                Genres = _movieDbContext.Genres.OrderBy(g => g.Name).ToList(),
                ActiveMovie = new Movie()

            };
            

            return View("AddMovie", movieViewModel);
        }

        [HttpPost("/movies")]
        public async Task<IActionResult> AddNewMovie(MovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {
                // it's valid so we want to add the new movie to the DB:
                _movieDbContext.Movies.Add(movieViewModel.ActiveMovie);
                _movieDbContext.SaveChanges();

                var payload = new Movie 
                    {
                   Name = movieViewModel.ActiveMovie.Name,
                   Year = movieViewModel.ActiveMovie.Year,
                   GenreId = movieViewModel.ActiveMovie.GenreId,
                   
                    };
                 
                List<string> uri = await _movieDbContext.StreamingPartners
               .Select(b => b.NewPartnerURL)
               .ToListAsync();

                foreach (string ur in uri)
                { Console.WriteLine(ur); }

                TempData["LastActionMessage"] = $"The movie \"{movieViewModel.ActiveMovie.Name}\" ({movieViewModel.ActiveMovie.Year}) was added.";
                
                foreach (string url in uri) 
                {
                    await SendWebhookNotification(payload,url);
                }

                return RedirectToAction("GetAllMovies", "Movie");

            }
            else
            {
                // it's invalid so we simply return the movie object
                // to the Edit view again:
                movieViewModel.Genres = _movieDbContext.Genres.OrderBy(g => g.Name).ToList();
                return View("AddMovie", movieViewModel);
            }

        }
        public async Task SendWebhookNotification(Movie payload,string webhook)
        {
            ;
            // Serialize the payload to JSON
            var jsonPayload = JsonSerializer.Serialize(payload);
         // Send a POST request to the webhook URL with the JSON 

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(webhook, content);
                    response.EnsureSuccessStatusCode();
                }
        }
        
        [HttpGet("/movies/{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _movieDbContext.Movies.Include(m => m.Genre)
                .Include(m => m.Reviews)
                .Include(m => m.Castings).ThenInclude(c => c.Actor)
                .Where(m => m.MovieId == id).FirstOrDefault();

            MovieDetailViewModel movieDetailViewModel = new MovieDetailViewModel() {
                ActiveMovie = movie,
                AverageRating = movie.Reviews.Average(r => r.Rating).GetValueOrDefault(),
            };

            return View("Details", movieDetailViewModel);
        }

        [HttpPost("/movies/{id}/reviews")]
        public IActionResult AddReviewToMovieById(int id, MovieDetailViewModel movieDetailViewModel)
        {
            var movie = _movieDbContext.Movies.Include(m => m.Reviews)
                .Where(m => m.MovieId == id).FirstOrDefault();

            movie.Reviews.Add(movieDetailViewModel.NewReview);
            _movieDbContext.SaveChanges();

            return RedirectToAction("GetMovieById", "Movie", new { id = id });
        }


        [HttpGet("/movies/{id}/edit-request")]
        public IActionResult GetEditMovieRequestById(int id)
        {
            MovieViewModel movieViewModel = new MovieViewModel()
            {
                Genres = _movieDbContext.Genres.OrderBy(g => g.Name).ToList(),
                ActiveMovie = _movieDbContext.Movies.Find(id)
            };

            return View("EditMovie", movieViewModel);
        }

        [HttpPost("/movies/edits")]
        public IActionResult ProcessEditRequest(MovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            { 
                // it's valid so we want to update the existing movie in the DB:
                _movieDbContext.Movies.Update(movieViewModel.ActiveMovie);
                _movieDbContext.SaveChanges();

                TempData["LastActionMessage"] = $"The movie \"{movieViewModel.ActiveMovie.Name}\" ({movieViewModel.ActiveMovie.Year}) was updated.";

                return RedirectToAction("GetAllMovies", "Movie");
            }
            else
            {
                movieViewModel.Genres = _movieDbContext.Genres.OrderBy(g => g.Name).ToList();
                return View("EditMovie", movieViewModel);
            }
        }

        [HttpGet("/movies/{id}/delete-request")]
        public IActionResult GetDeleteRequestById(int id)
        {
            // Find/retrieve/select the movie to edit and then pass it to the view:
            var movie = _movieDbContext.Movies.Find(id);
            return View("DeleteConfirmation", movie);
        }

        [HttpPost("/movies/{id}/deletes")]
        public IActionResult ProcessDeleteRequestById(int id)
        {
            // Find/retrieve/select the movie to delete:
            var movie = _movieDbContext.Movies.Find(id);

            // Simply remove the movie and then redirect back to the all movies view:
            _movieDbContext.Movies.Remove(movie);
            _movieDbContext.SaveChanges();

            TempData["LastActionMessage"] = $"The movie \"{movie.Name}\" ({movie.Year}) was deleted.";

            return RedirectToAction("GetAllMovies", "Movie");
        }

        private static string GetActorsDisplayText(Movie movie)
        {
            int numActors = movie.Castings.Count;

            if (numActors == 0)
            {
                return "";
            }
            else if (numActors == 1)
            {
                return movie.Castings.ElementAt(0).Actor.FullName;
            }
            else if (numActors == 2)
            {
                return movie.Castings.ElementAt(0).Actor.FullName +
                        ", " + movie.Castings.ElementAt(1).Actor.FullName;
            }
            else
            {
                return movie.Castings.ElementAt(0).Actor.FullName +
                        ", " + movie.Castings.ElementAt(1).Actor.FullName + "...";
            }
        }
        

        public IActionResult Print()
		{
			return View("Privacy");
		}
		private MovieDbContext _movieDbContext;
    }
}
