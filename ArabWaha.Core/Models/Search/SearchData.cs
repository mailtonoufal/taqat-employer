using Newtonsoft.Json;
using System.Collections.Generic;

namespace ArabWaha.Models.Search
{
    public class SearchData
    {
        [JsonProperty("results")]
        public List<SearchResults> SearchResults { get; set; }
    }

}
