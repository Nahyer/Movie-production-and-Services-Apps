﻿using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Entities
{
    public class StreamingPartner
    {
        //PK:
        public int EndpointId { get; set; }

        [Required(ErrorMessage = "Please enter a Partner URL")]
        public string NewPartnerURL { get; set; }

        [Required(ErrorMessage = "Please enter a Challenge URL.")]
        public string ChallengeURL { get; set; }


        public string VerificationStatus { get; set; }

       
    }
}
