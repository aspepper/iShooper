using Newtonsoft.Json;

namespace ishooper.com.Models
{

    public class ProfessionResponse
    {


        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("admnistrative")]
        public bool Administrative { get; set; }

    }

}
