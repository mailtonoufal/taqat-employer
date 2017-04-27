using Newtonsoft.Json;
using System.Collections.Generic;

namespace ArabWaha.Models
{
    public class Announcements
    {
        [JsonProperty("data")]
        public List<Announcement> Data { get; set; }

        [JsonProperty("meta")]
        public NMeta Meta { get; set; }
    }
}
