using Newtonsoft.Json;

namespace ArabWaha.Models
{
    public class NPaginator
    {
        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }

        [JsonProperty("links")]
        public NPaginatorLink Links { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}
