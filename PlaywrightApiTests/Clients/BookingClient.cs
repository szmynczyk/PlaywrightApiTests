using log4net;
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

        public async Task<ApiResponse<BookingResponse>?> GetBooking(int bookingId)
        {
            var request = await playwright.APIRequest.NewContextAsync(new()
            {
                BaseURL = BaseUrl
            });

            _loggingHelper.LogRequest("GetBookingIds request", HttpMethod.Get, $"{BaseUrl}booking/{bookingId}");

            var response = await request.GetAsync($"bookings/{bookingId}");
            
            await _loggingHelper.LogResponse("Get booking response", response);

            var serializedResponse = await ApiResponse<BookingResponse>.SerializeResponse(response);

            return serializedResponse;
        }
    }
}
