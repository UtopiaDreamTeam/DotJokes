using System.Text.Json.Serialization;

namespace DotJokes.ResponeModels
{
    public class GetJokeResponse:BaseResponse
    {
        [JsonIgnore]
        public JokeInfo? Joke { get; set; }
    }
    public class GetJokesResponse : BaseResponse
    {
        public int Amount { get; set; }
        public List<JokeInfo>?Jokes{ get; set; }

    }
}
