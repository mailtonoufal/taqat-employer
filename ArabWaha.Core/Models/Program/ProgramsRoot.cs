using Newtonsoft.Json;
using System.Collections.Generic;

namespace ArabWaha.Models
{
		//CMS Model
    public class ProgramsRoot
    {
        [JsonProperty("programs")]
        public List<Program> Programs { get; set; }
    }
}
