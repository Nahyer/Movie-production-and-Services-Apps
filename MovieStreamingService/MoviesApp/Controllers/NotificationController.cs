using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Entities;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    
	public class NotificationController : Controller
	{

        [HttpPost("api/Notification")]
        public IActionResult AddDataTODatabase([FromBody] Movie payload)
        {

            if (payload == null)
            {
                return BadRequest("Invalid payload.");
            }

            var NewMovie = new Movie()
            {
                Name = payload.Name,
                Year = payload.Year,
                GenreId = payload.GenreId,
                Rating = 0,
                ProductionStudioId = 2,
                StreamId = false
            };
                       
            _movieDbContext.Movies.Add(NewMovie);
            _movieDbContext.SaveChanges();
            return Ok();

        }

        private MovieDbContext _movieDbContext;
		public NotificationController(MovieDbContext movieDbContext)
		{
			_movieDbContext = movieDbContext;
		}	
	}
}
