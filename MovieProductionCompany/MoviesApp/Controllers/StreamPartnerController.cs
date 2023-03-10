using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Entities;
using MoviesApp.Models;
using System.Runtime.InteropServices;

namespace MoviesApp.Controllers
{
    public class StreamPartnerController : Controller
    {
        private MovieDbContext _movieDbContext;

        public StreamPartnerController(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        [HttpGet("/add/partner")]
        public IActionResult GetAddURLRequest()
        {
            GenerateSecret();

            URLViewModel uRLViewModel = new URLViewModel()
            {
                ActiveUrl = new StreamingPartner()
            };
          
            //var partner = _movieDbContext.StreamingPartners.Find(id);
            return View("URLpage", uRLViewModel);
        }

        [HttpPost]
        public IActionResult AddNewURL(URLViewModel uRLViewModel)
        {
            
            _movieDbContext.StreamingPartners.Add(uRLViewModel.ActiveUrl);
            _movieDbContext.SaveChanges();


                TempData["LastActionMessage"] = $"A PartnerID \"{uRLViewModel.ActiveUrl.EndpointId}\" was added.";
            Console.WriteLine(uRLViewModel.ActiveUrl.EndpointId);
            int id = uRLViewModel.ActiveUrl.EndpointId;
            return RedirectToAction("Partner", new {Id = id});
            
        }
        [HttpGet]
        public IActionResult Partner(int Id)
        {
            Console.WriteLine(Id);
            //var Notification = _movieDbContext.StreamingPartners.Find(Id);
            //Challenge = _movieDbContext.StreamingPartners.FirstOrDefault().ChallengeURL;

            //ViewData["Notification"] = Notification;
            //ViewData["Challenge"] = Challenge;
            ViewData["bag"] = HexString;
            Console.WriteLine(HexString);
            URLViewModel URLModel = new URLViewModel()
            {
                ActiveUrl = _movieDbContext.StreamingPartners.Find(Id)
            };

            return View("Partner", URLModel);
        }
        public IActionResult GenerateSecret()
        {
            Guid guid = Guid.NewGuid();
             HexString = guid.ToString("D");
            ViewBag.HexString = HexString;
            Console.WriteLine(HexString);
            return Ok();
        }

       
        public static string HexString;
        public static string Challenge;
        
    }
}
