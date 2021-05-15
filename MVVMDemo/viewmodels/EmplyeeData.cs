using Newtonsoft.Json;

namespace MVVMDemo.viewmodels
{
    public class EmplyeeData
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("salary")]
        public string Salary { get; set; }
        [JsonProperty("age")]
        public string Age { get; set; }

    }
}