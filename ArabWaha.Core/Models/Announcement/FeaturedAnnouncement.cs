using Newtonsoft.Json;

namespace ArabWaha.Models
{
    public class FeaturedAnnouncement
    {
        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
