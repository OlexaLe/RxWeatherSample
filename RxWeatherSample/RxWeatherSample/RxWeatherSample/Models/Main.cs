using Newtonsoft.Json;

namespace RxWeatherSample.Models
{
    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
    }
}