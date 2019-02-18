 
namespace Countries.Models
{
    using Newtonsoft.Json;
    public class Currency
    {
        [JsonProperty(PropertyName = "code")]
        public string code { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string symbol { get; set; }
    }
}
