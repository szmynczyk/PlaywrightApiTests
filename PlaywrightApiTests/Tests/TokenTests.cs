using PlaywrightApiTests.Clients;
using PlaywrightApiTests.Models;

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
            TokenResponse? jsonResponse = await _client.GetToken();
            Assert.That(jsonResponse.Token, Is.Not.Empty);
        }

        [Test]
        public async Task GetTokenWithSerializedBodyReturnsProperToken()
        {
            TokenResponse? jsonResponse = await _client.GetTokenSerialized();

            Assert.That(jsonResponse.Token, Is.Not.Empty);
        }
    }
}