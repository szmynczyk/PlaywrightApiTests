using PlaywrightApiTests.Clients;

namespace PlaywrightApiTests.Tests
{
    internal class TokenTests
    {
        TokenClient _client;

        [SetUp]
        public void TokenTestsSetup()
        {
            _client = new TokenClient();
        }

        [Test]
        public async Task GetTokenReturnsProperToken()
        {
            var jsonResponse = await _client.GetTokenSimple();
            Assert.That(jsonResponse.Data.Token, Is.Not.Empty);
        }

        [Test]
        public async Task GetTokenWithSerializedBodyReturnsProperToken()
        {
            var jsonResponse = await _client.GetTokenSerialized();
            Assert.That(jsonResponse.Data.Token, Is.Not.Empty);
        }
    }
}