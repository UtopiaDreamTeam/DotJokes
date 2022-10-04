using System.Text.Json.Serialization;

namespace DotJokes.ResponeModels
{
    public class InfoResponse:BaseResponse
    {
        public string? Version { get; set; }
        [JsonPropertyName("Jokes")]
        public JokesGeneralInfo? GeneralInfo { get; set; }
        public string? Info { get; set; }
    }

    public class JokesGeneralInfo
    {
        public int TotalCount { get; set; }
        public Dictionary<Language, List<int>>? IdRange { get; set; }
        public List<SafeJoke>? SafeJokes { get; set; }
    }
    public class SafeJoke
    {
        [JsonPropertyName("Lang")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Language Language { get; set; }
        public int Count { get; set; }
    }
}
