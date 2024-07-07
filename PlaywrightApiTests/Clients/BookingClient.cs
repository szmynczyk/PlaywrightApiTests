using PlaywrightApiTests.Models;

namespace PlaywrightApiTests.Clients
{
    internal class BookingClient : ApiClientBase
    {
        const string BaseUrl = "https://restful-booker.herokuapp.com/";

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
    }
}
