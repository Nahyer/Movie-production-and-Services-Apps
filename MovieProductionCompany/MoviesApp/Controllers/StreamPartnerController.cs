using Microsoft.AspNetCore.Mvc;
using MoviesApp.Entities;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    public class StreamPartnerController : Controller
    {
        private MovieDbContext _movieDbContext;

        public StreamPartnerController(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddURLRequestAsync()
        {
         
              return View("URLpage");
        }

        [HttpPost]
        public IActionResult AddNewURL( URLViewModel uRLViewModel)
        {
            
                var newMovie = new StreamingPartner()
                {
                    NewPartnerURL = uRLViewModel.ActiveUrl.NewPartnerURL,
                    ChallengeURL = uRLViewModel.ActiveUrl.ChallengeURL,
                    APIkey = uRLViewModel.ActiveUrl.APIkey

                };

                _movieDbContext.StreamingPartners.Add(newMovie);
                _movieDbContext.SaveChanges();

                TempData["LastActionMessage"] = $"A PartnerID \"{uRLViewModel.ActiveUrl.EndpointId}\" was added.";

                return RedirectToAction("GetAllMovies", "Movie"); 
            
        }
        public IActionResult partnerReg()
        {
            return View("URLpage");
        }

        
    }
}
