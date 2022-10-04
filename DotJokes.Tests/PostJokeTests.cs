namespace DotJokes.Tests
{
    [TestClass]
    public class PostJokeTests
    {
        JokesManager jokesManager = new JokesManager();
        [TestMethod]
        public async Task Post()
        {
            await jokesManager.PostJokes(new JokeInfo()
            {
                Type = JokeType.Single,
                Category = JokeCategory.Misc,
                Joke = "I forgot my line",
                FlagList = new List<Flag>(),
                Language=Language.en,
            },true);
        }
    }
}
