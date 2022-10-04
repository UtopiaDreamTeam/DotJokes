namespace DotJokes.Tests
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public async Task PingReturnTrue()
        {
            bool? pingSucces = (await new JokesManager().PingAsync()).PingSucces;
            Assert.IsTrue(pingSucces);
        }
        [TestMethod]
        public async Task Info()
        {
            string? version = (await new JokesManager().GetInfoAsync()).Version;
            Assert.IsNotNull(version);
        }
    }
}