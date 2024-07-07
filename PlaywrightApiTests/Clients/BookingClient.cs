using PlaywrightApiTests.Models;

namespace PlaywrightApiTests.Clients
{
    internal class BookingClient : ApiClientBase
    {
        public override string BaseUrl => "https://restful-booker.herokuapp.com/";

        public async Task<ApiResponse<List<BookingIdsResponse>>?> GetBookingIds()
        {
            var request = await playwright.APIRequest.NewContextAsync(new()
            {
                BaseURL = BaseUrl
            });

            var response = await request.GetAsync("booking");
            var serializedResponse = await ApiResponse<List<BookingIdsResponse>>.SerializeResponse(response);

            return serializedResponse;
        }

        public async Task<ApiResponse<BookingResponse>?> GetBooking(int bookingId)
        {
            var request = await playwright.APIRequest.NewContextAsync(new()
            {
                BaseURL = BaseUrl
            });

            var response = await request.GetAsync($"booking/{bookingId}");
            var serializedResponse = await ApiResponse<BookingResponse>.SerializeResponse(response);

            return serializedResponse;
        }
    }
}
