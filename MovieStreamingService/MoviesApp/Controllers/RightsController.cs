using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Entities;
using System.Linq.Expressions;
using System.Text;

namespace MoviesApp.Controllers
{
    
    public class RightsController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> GetRights(int id)
        { 
            using var httpClient = new HttpClient();
            var content = new StringContent("", Encoding.UTF8, "text/plain");
            var response = await httpClient.PostAsync("https://localhost:7082/api/Rights", content);
            response.EnsureSuccessStatusCode();
            int newId= id;
            return RedirectToAction("StatusUpdate", new { Id = newId });
        }

        [HttpGet()]
        public IActionResult StatusUpdate(int Id)
        {
            var Status = _movieDbContext.Movies.Find(Id);
            return RedirectToAction("Update", Status);
        }

        public IActionResult Update(Movie Status)
        {
            Status.StreamId = true;
            _movieDbContext.Movies.Update(Status);
            _movieDbContext.SaveChanges();

            return RedirectToAction("List", "Movie");
        }
        private MovieDbContext _movieDbContext;
        public RightsController(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
    }
}
