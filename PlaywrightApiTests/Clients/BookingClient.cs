using log4net;
using Microsoft.Playwright;
using PlaywrightApiTests.Helpers;
using PlaywrightApiTests.Models;

namespace PlaywrightApiTests.Clients
{
	internal class BookingClient : ApiClientBase
	{
		public override string BaseUrl => "https://restful-booker.herokuapp.com/";
		readonly LoggingHelper _loggingHelper;

		public BookingClient()
		{
			logger = LogManager.GetLogger(typeof(BookingClient));
			_loggingHelper = new LoggingHelper(logger);
		}

		public async Task<ApiResponse<List<BookingIdsResponse>>?> GetBookingIds()
		{
			var request = await playwright.APIRequest.NewContextAsync(new()
			{
				BaseURL = BaseUrl
			});

			_loggingHelper.LogRequest("GetBookingIds request", HttpMethod.Get, $"{BaseUrl}booking");

			var response = await request.GetAsync("booking");

			await _loggingHelper.LogResponse("Get booking ids response", response);

			var serializedResponse = await ApiResponse<List<BookingIdsResponse>>.SerializeResponse(response);

			return serializedResponse;
		}

		public async Task<ApiResponse<BookingModel>?> GetBooking(int bookingId)
		{
			var request = await playwright.APIRequest.NewContextAsync(new()
			{
				BaseURL = BaseUrl
			});

			_loggingHelper.LogRequest("GetBookingIds request", HttpMethod.Get, $"{BaseUrl}booking/{bookingId}");

			var response = await request.GetAsync($"bookings/{bookingId}");

			await _loggingHelper.LogResponse("Get booking response", response);

			var serializedResponse = await ApiResponse<BookingModel>.SerializeResponse(response);

			return serializedResponse;
		}

		public async Task<ApiResponse<CreateBookingResponse>?> CreateBooking(BookingModel booking)
		{
			Dictionary<string, string> headers = new()
			{
				{ "Content-Type", "application/json" }
			};

			var request = await playwright.APIRequest.NewContextAsync(new()
			{
				BaseURL = BaseUrl
			});

			_loggingHelper.LogRequest("Post booking request", HttpMethod.Post, $"{BaseUrl}booking", headers, booking);

			var response = await request.PostAsync("booking", new APIRequestContextOptions()
			{
				DataObject = booking,
				Headers = headers
			});

			await _loggingHelper.LogResponse("Post booking response", response);

			var serializedResponse = await ApiResponse<CreateBookingResponse>.SerializeResponse(response);

			return serializedResponse;
		}
	}
}
