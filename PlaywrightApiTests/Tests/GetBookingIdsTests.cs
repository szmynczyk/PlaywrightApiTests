using PlaywrightApiTests.Clients;
using PlaywrightApiTests.Helpers;

namespace PlaywrightApiTests.Tests
{
    internal class GetBookingIdsTests
    {
        BookingClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new BookingClient();
        }

        [Test]
        public async Task GetBookingIdsReturnsListOfBookingIds()
        {
            var response = await _client.GetBookingIds();
            
            ResponseVerifier.SimpleVerifyProperResponse(response);
        }
    }
}
