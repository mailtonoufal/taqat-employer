using Newtonsoft.Json;

namespace ArabWaha.Models
{
    public class ObligationsListRoot
    {
        [JsonProperty("d")]
        public ObligationsList ObligationsListRootItem { get; set; }
    }
}
