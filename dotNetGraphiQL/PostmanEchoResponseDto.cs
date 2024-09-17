using Newtonsoft.Json;

public class PostmanEchoResponseDto
{
    public class Data
    {
        [JsonProperty("hello")]
        public string Hello { get; set; }
    }
    
    [JsonProperty("Data")]
    public Data TheData { get; set; }
}

