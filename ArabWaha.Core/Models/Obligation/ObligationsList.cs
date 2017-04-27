using Newtonsoft.Json;
using System.Collections.Generic;

namespace ArabWaha.Models
{
    public class ObligationsList
    {
        [JsonProperty("results")]
        public List<Obligation> Results { get; set; }
    }
}
