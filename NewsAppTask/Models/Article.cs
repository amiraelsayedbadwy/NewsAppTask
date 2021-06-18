using System;
using Newtonsoft.Json;

namespace NewsAppTask.Models
{
    public class Article
    {
        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "urlToImage")]
        public string UrlToImage { get; set; }
        [JsonProperty(PropertyName = "publishedAt")]
        public DateTime PublishedAt { get; set; }
    }
}
