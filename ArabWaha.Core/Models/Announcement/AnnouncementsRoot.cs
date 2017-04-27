using Newtonsoft.Json;
using System.Collections.Generic;

namespace ArabWaha.Models
{
    public class AnnouncementsRoot
    {
        [JsonProperty("announcements")]
        public Announcements Announcements { get; set; }

        [JsonProperty("featured")]
        public List<FeaturedAnnouncement> Featured { get; set; }
    }
}
