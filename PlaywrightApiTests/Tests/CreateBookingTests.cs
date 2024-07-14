using PlaywrightApiTests.Clients;
using PlaywrightApiTests.Helpers;
using PlaywrightApiTests.Models;

namespace PlaywrightApiTests.Tests
{
	internal class CreateBookingTests
	{
		private BookingClient _client;

		[SetUp]
		public void Setup()
		{
			_client = new BookingClient();
		}

		[Test]
		public async Task SuccessfulCreateBooking()
		{
			var booking = new BookingModel
			{
				FirstName = "Marcin",
				LastName = "Szymczyk",
				BookingDates = new BookingDates
				{
					CheckIn = DateOnly.FromDateTime(DateTime.Now),
					CheckOut = DateOnly.FromDateTime(DateTime.Now.AddDays(3))
				},
				AdditionalNeeds = "Personal bathroom",
				TotalPrice = 550,
				DepositPaid = false
			};

			var response = await _client.CreateBooking(booking);

			ResponseVerifier.SimpleVerifyProperResponse(response);
		}
	}
}
