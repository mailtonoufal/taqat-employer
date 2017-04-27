using Newtonsoft.Json;

namespace ArabWaha.Models
{
    public class NPaginatorLink
    {
        [JsonProperty("next")]
        public object Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }
    }
}
