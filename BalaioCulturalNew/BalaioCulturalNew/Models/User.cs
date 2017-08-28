using Newtonsoft.Json;
using Prism.Mvvm;

namespace BalaioCulturalNew.Models
{
    [JsonObject]
    public class FacebookData
    {
        public bool is_silhouette { get; set; }
        public string url { get; set; }
    }
    [JsonObject]
    public class FacebookPicutre
    {
        public FacebookData data { get; set; }
    }
    [JsonObject]
    public class User
    {
        [JsonProperty("email")]
        public string email { get; set; }
        [JsonProperty("picture")]
        public FacebookPicutre picture { get; set; }
        [JsonProperty("id")]
        public string id { get; set; }
    }
}