using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Newtonsoft.Json;

namespace Ishooper.Api.Models
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
