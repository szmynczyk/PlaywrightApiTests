using PlaywrightApiTests.Clients;
using PlaywrightApiTests.Helpers;

namespace PlaywrightApiTests.Tests
{
    internal class GetBookingTests
    {
        BookingClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new BookingClient();
        }

        [Test]
        public async Task GetBookingReturnsProperBooking()
        {
            var bookingId = (await _client.GetBookingIds()).Data.FirstOrDefault().BookingId;

            var response = await _client.GetBooking(bookingId);
            
            ResponseVerifier.SimpleVerifyProperResponse(response);
        }
    }
}
