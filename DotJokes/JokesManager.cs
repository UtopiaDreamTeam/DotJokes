using DotJokes.RequestModels;
using DotJokes.ResponeModels;
using System.Net.Http.Json;
using System.Text.Json;

namespace DotJokes
{
    public class JokesManager
    {
        private const string baseUri = "https://v2.jokeapi.dev/";
        private readonly HttpClient client = new HttpClient();
        private readonly JsonSerializerOptions serializerOptions;
        public JokesManager()
        {
            serializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };
            client.BaseAddress = new Uri(baseUri);
        }
        public async Task<PingResponse> PingAsync()
        {
            const string uri = "/ping";
            var result =await client.GetStringAsync(uri);
            var respone=JsonSerializer.Deserialize<PingResponse>(result,serializerOptions);
            if(respone is null)  
                throw new Exception("Response was null");
            return respone;
        }
        public async Task<InfoResponse> GetInfoAsync()
        {
            const string uri = "/info";
            var result = await client.GetStringAsync(uri);
            var respone = JsonSerializer.Deserialize<InfoResponse>(result, serializerOptions);
            if (respone is null)
                throw new Exception("Response was null");
            return respone;
        }

        public async Task<GetJokeResponse> GetJoke(JokeRequestInfo info)
        {
            const string uri = "/joke/";
            var result = await client.GetStringAsync(uri+info.Parse());
            var joke = JsonSerializer.Deserialize<JokeInfo>(result, serializerOptions);
            var jokeRespone= JsonSerializer.Deserialize<GetJokeResponse>(result, serializerOptions);
            if (joke is null||jokeRespone is null)
                throw new Exception("Response was null");
            jokeRespone.Joke = joke;
            return jokeRespone;
        }
        public async Task<GetJokesResponse> GetJokes(JokeRequestInfo info,int count)
        {
            const string uri = "/joke/";
            var result = await client.GetStringAsync($"{uri}{info.Parse()}amount={count}");
            var respone = JsonSerializer.Deserialize<GetJokesResponse>(result, serializerOptions);
            if (respone is null)
                throw new Exception("Response was null");
            return respone;
        }
        public async Task<PostJokeResponse> PostJokes(JokeInfo joke,bool dryRun=false)
        {
            const string uri = "/submit/";
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(
                            $"{uri}{(dryRun ? "?dry-run" : "")}", joke);
            var result = await responseMessage.Content.ReadAsStringAsync();
            var postResponse = JsonSerializer.Deserialize<PostJokeResponse>(result, serializerOptions);
            if (postResponse is null)
                throw new Exception("Response was null");
            return postResponse;
        }
    }
}