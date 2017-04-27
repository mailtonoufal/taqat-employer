using Newtonsoft.Json;

namespace ArabWaha.Models
{
    public class NMeta
    {
        [JsonProperty("paginator")]
        public NPaginatorLink Paginator { get; set; }
    }

}
