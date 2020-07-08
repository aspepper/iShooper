using System;
using Newtonsoft.Json;

namespace Ishooper.Api.Models
{
	public class ProfessionalSearchRequest
	{

		[JsonProperty("longitude")]
		public double Longitude { get; set; } = 0;

		[JsonProperty("latitude")]
		public double Latitude { get; set; } = 0;

		[JsonProperty("profession_id")]
		public string ProfessionId { get; set; } = string.Empty;

	}

	public class ProfessionalSearchResponse
	{

		[JsonProperty("professional_id")]
		public string ProfessionalId { get; set; } = string.Empty;

        [JsonProperty("photo")]
        public string Photo { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("profession")]
        public string Profession { get; set; } = string.Empty;

        [JsonProperty("calls")]
        public int Calls { get; set; } = 0;

        [JsonProperty("points")]
        public double Points { get; set; } = 0;

        [JsonProperty("price")]
        public double Price { get; set; } = 0;

    }

}
