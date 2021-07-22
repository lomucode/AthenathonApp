using System;
using Newtonsoft.Json;

namespace AthenathonApp.Services
{
    public class DistanceEntry
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("distanz")]
        public double Distanz { get; set; }

        [JsonProperty("distanzArt")]
        public string DistanzArt { get; set; }

        [JsonProperty("aktivitätsdauer")]
        public object Aktivitätsdauer { get; set; }

        [JsonProperty("distanzManuellAnpassen")]
        public object DistanzManuellAnpassen { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("distanDatenDatum")]
        public DateTime DistanDatenDatum { get; set; }
    }
}

