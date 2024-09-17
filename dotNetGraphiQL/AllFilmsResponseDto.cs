using Newtonsoft.Json;

public class AllFilmsResponseDto
{
    public class AllFilms
    {
        [JsonProperty("films")]
        public List<Film> Films { get; set; }
    }

    public class Data
    {
        [JsonProperty("allFilms")]
        public AllFilms AllFilms { get; set; }
    }

    public class Film
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("director")]
        public string Director { get; set; }

        [JsonProperty("releaseDate")]
        public string ReleaseDate { get; set; }
    }

    [JsonProperty("data")]
    public Data TheData { get; set; }
}

