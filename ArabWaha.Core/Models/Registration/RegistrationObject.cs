using Newtonsoft.Json;

namespace ArabWaha.Models
{
    public class RegistrationObject
    {
        [JsonProperty("ApplicationConnectionId")]
        public string ApplicationConnectionId { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }
    }
}
