using Newtonsoft.Json;

namespace ArabWaha.Models
{
    public class RegistrationObjectRoot
    {
        [JsonProperty("d")]
        public RegistrationObject RegistrationObjectItem { get; set; }
    }
}
