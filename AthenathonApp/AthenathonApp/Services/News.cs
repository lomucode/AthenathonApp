using System;
using Newtonsoft.Json;

namespace AthenathonApp.Services
{
    public class News
    {
        [JsonProperty("newsId")]
        public int NewsId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("zeit")]
        public DateTime Zeit { get; set; }

        [JsonProperty("bild")]
        public object Bild { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}
