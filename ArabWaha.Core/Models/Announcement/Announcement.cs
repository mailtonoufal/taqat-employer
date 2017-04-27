using Newtonsoft.Json;
using SQLite;


namespace ArabWaha.Models
{
    public class Announcement
    {
        [AutoIncrement, PrimaryKey]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("ttle")]
        public string Ttle { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }


        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }




        [JsonProperty("featured")]
        public bool Featured { get; set; }



        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
