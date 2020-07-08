using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Ishooper.Api.Models
{

    public class LandPageEnroll
    {

        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("telephone")]
        public string Telephone { get; set; } = string.Empty;

        [JsonProperty("occupation")]
        public int Occupation { get; set; } = 0;

        [JsonProperty("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }

    public class LandPageEnrollRequest
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required]
        [JsonProperty("telephone")]
        public string Telephone { get; set; }

        [Required]
        [JsonProperty("occupation")]
        public int Occupation { get; set; }

    }

    public class LandPageEnrollResponse
    {

        [JsonProperty("UserID")]
        public string Id { get; set; }

    }


    public class LandPageEnrollRequestHttpForm
    {

        [Required]
        public string LandPageName { get; set; } // Name

        [Required]
        public string LandPageEmail { get; set; } // Email

        [Required]
        public string LandPageTelephone { get; set; } // Telephone

        [Required]
        public int LandPageOccupation { get; set; } // Occupation

    }


}
