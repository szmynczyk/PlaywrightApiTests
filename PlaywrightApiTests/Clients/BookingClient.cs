using PlaywrightApiTests.Models;

namespace PlaywrightApiTests.Clients
{
    internal class BookingClient : ApiClientBase
    {
        public async Task<List<BookingResponse>?> GetBookings()
        {
            var request = await playwright.APIRequest.NewContextAsync(new()
            {
                BaseURL = "https://restful-booker.herokuapp.com/"
            });

            var response = await request.GetAsync("booking");
            return await response.JsonAsync<List<BookingResponse>>();
        }
    }
}
