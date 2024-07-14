using PlaywrightApiTests.Clients;
using PlaywrightApiTests.Helpers;

namespace PlaywrightApiTests.Tests
{
	internal class PatchBookingTests
	{
		private BookingClient _client;

		[SetUp]
		public void Setup()
		{
			_client = new BookingClient();
		}

		[Test]
		public async Task PartiallyUpdateBooking()
		{
			var propertiesToChange = new Dictionary<string, string>()
			{
				{ "firstname", "Klaudiusz" }
			};

			var response = await _client.PartiallyUpdateBooking(500, propertiesToChange);

			ResponseVerifier.SimpleVerifyProperResponse(response);

			Assert.That(response.Data.FirstName, Is.EqualTo("Klaudiusz"));
		}

		[TestCase(1289, "firstname", "Klaudiusz", true)]
		[TestCase(1290, "firstname", "Klaudiusz", false)]
		public async Task PartiallyUpdateBookingTestCase(int bookingId, string property, string value, bool isResponseSuccess)
		{
			var propertiesToChange = new Dictionary<string, string>()
			{
				{ property, value }
			};

			var response = await _client.PartiallyUpdateBooking(bookingId, propertiesToChange);

			Assert.That(response.IsSuccess, Is.EqualTo(isResponseSuccess));
		}

		[TestCaseSource(nameof(PartiallyUpdateBookingTestData))]
		public async Task PartiallyUpdateBookingTestCaseSource(int bookingId, string property, string value, bool isResponseSuccess)
		{
			var propertiesToChange = new Dictionary<string, string>()
			{
				{ property, value }
			};

			var response = await _client.PartiallyUpdateBooking(bookingId, propertiesToChange);

			Assert.That(response.IsSuccess, Is.EqualTo(isResponseSuccess));
		}

		public static object[] PartiallyUpdateBookingTestData =
		{
			new object[] { 1289, "firstname", "Klaudiusz", true },
			new object[] { 1290, "firstname", "Klaudiusz", false }
		};
	}
}
