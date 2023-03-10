using Microsoft.AspNetCore.Mvc;
using MoviesApp.Entities;
using MoviesApp.Models;
using System.Text;


namespace MoviesApp.Controllers
{

	public class ChallengeController : Controller
	{
        private MovieDbContext _movieDbContext;

        [HttpPost]
		public async Task<IActionResult> SendVerification(int id)
		{ 
			//Retrieve the webhook endpoint URL and secret key
			var webhookSecret = StreamPartnerController.HexString;
			var partner=_movieDbContext.StreamingPartners.Find(id);
            string challenge = partner.ChallengeURL;
			Console.WriteLine(id);

			using (var httpClient = new HttpClient())
			{
				var content = new StringContent("", Encoding.UTF8, "text/json");
				httpClient.DefaultRequestHeaders.Add("X-MPC-Webhook-Secret", webhookSecret);
				var response = await httpClient.PostAsync(challenge, content);
				response.EnsureSuccessStatusCode();
				if (response.IsSuccessStatusCode)
				{
                    // Success handling
                    // await UpdateVerified(56);
                    int newId = id;
					Console.WriteLine(newId);
                    return RedirectToAction("GetVerificationById", new { Id = newId });
				}
				else
				{ 
					// Error handling
					return BadRequest($"Failed to send webhook notification: {response.ReasonPhrase}");
				}
			}
			//return Ok();
		}

		[HttpGet()]
		public IActionResult GetVerificationById(int Id)
		{
			Console.WriteLine(Id);
			var partner = _movieDbContext.StreamingPartners.Find(Id);
			return RedirectToAction("UpdateVerified", partner);

		}

		public async Task<IActionResult> UpdateVerified(StreamingPartner partner)
		{
			partner.VerificationStatus = "VERIFIED";
			_movieDbContext.StreamingPartners.Update(partner);
            await _movieDbContext.SaveChangesAsync();
			int id = partner.EndpointId;
			return RedirectToAction("Partner","StreamPartner",new { Id = id });
		}

        public ChallengeController(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;

        }

    }
}
