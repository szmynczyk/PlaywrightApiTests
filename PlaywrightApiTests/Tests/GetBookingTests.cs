using PlaywrightApiTests.Clients;
using PlaywrightApiTests.Models;

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
            
            Assert.That(response, Is.Not.Null);
            Assert.That(response.ErrorContent, Is.Null);
            Assert.That(response.Data, Is.TypeOf(typeof(BookingResponse)));
            Assert.That(response.Data.FirstName, Is.Not.Empty);
        }
    }
}
