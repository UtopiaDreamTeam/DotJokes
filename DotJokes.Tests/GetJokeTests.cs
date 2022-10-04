using DotJokes.RequestModels;

namespace DotJokes.Tests
{
    [TestClass]
    public class GetJokeTests
    {
        private readonly JokesManager endPoint = new JokesManager();
        [TestMethod]
        public async Task GettingSameLanguage()
        {
            foreach (var lang in (Language[]) Enum.GetValues(typeof(Language)))
            {
                await TestLanguage(lang);
            }
            var joke = (await endPoint.GetJoke(new JokeRequestInfo() { })).Joke!;
            Assert.AreEqual(joke.Language, Language.en);

            async Task TestLanguage(Language language)
            {
                var joke2 = (await endPoint.GetJoke(new JokeRequestInfo() { Language = language })).Joke!;
                Assert.AreEqual(joke2.Language, language);
            }
        }
        [TestMethod]
        public async Task GettingNoFlags()
        {
            for (int i = 0; i < 10; i++)
            {
                var info=new JokeRequestInfo()
                {
                    BlackList = new List<Flag>() { Flag.Nsfw, Flag.Religious, Flag.Political, Flag.Racist, Flag.Sexist, Flag.Explicit },
                };
                var joke = (await endPoint.GetJoke(info)).Joke!;
                Assert.IsNull(joke.FlagList);
            }
        }
        [TestMethod]
        public async Task RangeTest()
        {
            int i = 32;
            var info = new JokeRequestInfo()
            {
                FilterEnd = i,
                FilterStart = i,
            };
            var joke = (await endPoint.GetJoke(info)).Joke!;
            Assert.AreEqual(joke.Id,i);
        }
        [TestMethod]
        public async Task JokeTypeTest()
        {
            var info = new JokeRequestInfo()
            {
                Type=JokeType.TwoPart
            };
            var joke = (await endPoint.GetJoke(info)).Joke!;
            Assert.IsNotNull(joke.Delivery);
            Assert.IsNotNull(joke.Setup);
            Assert.IsNull(joke.Joke);
            var info2 = new JokeRequestInfo()
            {
                Type = JokeType.Single
            };
            var joke2 = (await endPoint.GetJoke(info2)).Joke!;
            Assert.IsNull(joke2.Delivery);
            Assert.IsNull(joke2.Setup);
            Assert.IsNotNull(joke2.Joke);
        }
        [TestMethod]
        public async Task Categories()
        {
            foreach (var c in (JokeCategory[])Enum.GetValues(typeof(JokeCategory)))
            {
                await TestCategory(c);
            }
            async Task TestCategory(JokeCategory category)
            {
                var joke2 = (await endPoint.GetJoke(new JokeRequestInfo() { Categories = new List<JokeCategory> { category } })).Joke!;
                Assert.AreEqual(joke2.Category, category);
            }
            var joke2 = (await endPoint.GetJoke(new JokeRequestInfo() { Categories = new List<JokeCategory> { JokeCategory.Programming, JokeCategory.Pun } })).Joke!;
            Assert.IsTrue(joke2.Category == JokeCategory.Pun||joke2.Category==JokeCategory.Programming);
        }
        [TestMethod]
        [DataRow("Mom")]
        [DataRow("Bill")]
        public async Task Search(string str)
        {
            var joke = (await endPoint.GetJoke(new JokeRequestInfo()
            {
                SearchString= str
            })).Joke!;
            if (joke.Type == JokeType.Single)
                Assert.IsTrue(joke.Joke?.Contains(str,StringComparison.CurrentCultureIgnoreCase));
            else 
                Assert.IsTrue((joke.Delivery!.Contains(str, StringComparison.CurrentCultureIgnoreCase) || joke.Setup!.Contains(str)));
        }
        [TestMethod]
        public async Task GetJokes()
        {
            var jokes = await endPoint.GetJokes(new JokeRequestInfo() { Language=Language.fr}, 10);
            Assert.AreEqual(10, jokes.Amount);
            Assert.AreEqual(10, jokes.Jokes!.Count);
            foreach (var joke in jokes.Jokes)
            {
                Assert.AreEqual(joke.Language, Language.fr);
            }
        }
    }
}
