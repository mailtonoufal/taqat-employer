using Newtonsoft.Json;

namespace ArabWaha.Models.Search
{
    public class SearchRoot
    {
        [JsonProperty("d")]
        public SearchData SearchData { get; set; }
    }

}
