using PlaywrightApiTests.Clients;
using PlaywrightApiTests.Helpers;

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
            var response = await _client.GetTokenSimple();
            ResponseVerifier.SimpleVerifyProperResponse(response);
            Assert.That(response.Data.Token, Is.Not.Empty);
        }

        [Test]
        public async Task GetTokenWithSerializedBodyReturnsProperToken()
        {
            var response = await _client.GetTokenSerialized();

            ResponseVerifier.SimpleVerifyProperResponse(response);
            Assert.That(response.Data.Token, Is.Not.Empty);
        }
    }
}