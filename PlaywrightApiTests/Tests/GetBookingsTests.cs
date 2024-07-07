using PlaywrightApiTests.Clients;

namespace PlaywrightApiTests.Tests
{
    internal class GetBookingsTests
    {
        BookingClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new BookingClient();
        }

        [Test]
        public async Task GetBookingReturnsListOfBookings()
        {
            var response = await _client.GetBookings();
            Assert.That(response, Is.Not.Null);
            Assert.That(response, Is.Not.Empty);
        }
    }
}
