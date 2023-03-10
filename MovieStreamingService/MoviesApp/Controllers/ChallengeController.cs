using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MoviesApp.Controllers
{
	public class ChallengeController : Controller
	{


		[HttpPost("api/Challenge")]


		public IActionResult ReceiveWebhook()
		{
            Console.WriteLine("Received webhook!");
            if (!Request.Headers.TryGetValue("X-MPC-Webhook-Secret", out var webhookSecret))
            {
                // If the secret key is missing, reject the request
                Console.WriteLine(webhookSecret);
               // return BadRequest("Missing webhook secret key");

            }

            // Get the expected secret key from app settings
            var expectedSecret = _config.GetValue<string>("ProductionStudioSettings:APIKey");

            if (webhookSecret != expectedSecret)
            {
                Console.WriteLine(webhookSecret);
                Console.WriteLine(expectedSecret);
                // If the secret key doesn't match, reject the request
                //return BadRequest("Invalid webhook secret key");
            }
            

            return Ok();
		}
		private readonly IConfiguration _config;

        public ChallengeController(IConfiguration config)
        {
            _config = config;
        }
    }
}
