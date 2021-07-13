using System;
using Newtonsoft.Json;

namespace AthenathonApp.Services
{
    public class User
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("NormalizedUserName")]
        public string NormalizedUserName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("NormalizedEmail")]
        public string NormalizedEmail { get; set; }

        [JsonProperty("EmailConfirmed")]
        public bool EmailConfirmed { get; set; }
    }
}

