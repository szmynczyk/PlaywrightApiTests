using Microsoft.Playwright;
using System.Text.Json;

namespace PlaywrightApiTests
{
    public class Tests
    {
        IPlaywright playwright;

        [SetUp]
        public async Task Setup()
        {
            playwright = await Playwright.CreateAsync();
        }

        [Test]
        public async Task GetTokenReturnsProperToken()
        {
            TokenResponse? jsonResponse = await GetToken();

            Assert.That(jsonResponse.Token, Is.Not.Empty);
        }
        
        [Test]
        public async Task GetTokenWithSerializedBodyReturnsProperToken()
        {
            TokenResponse? jsonResponse = await GetTokenSerialized();

            Assert.That(jsonResponse.Token, Is.Not.Empty);
        }
        
        [Test]
        public async Task GetBookingReturnsListOfBookings()
        {
            var request = await playwright.APIRequest.NewContextAsync(new()
            {
                BaseURL = "https://restful-booker.herokuapp.com/"
            });

            var response = await request.GetAsync("booking");
            var bookings = await response.JsonAsync<List<BookingResponse>>();
            Assert.That(bookings.Count, Is.GreaterThan(0));
        }

        private async Task<TokenResponse?> GetToken()
        {
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" }
            };

            var request = await playwright.APIRequest.NewContextAsync(new()
            {
                BaseURL = "https://restful-booker.herokuapp.com/"
            });

            var data = new Dictionary<string, string>()
            {
                { "username", "admin" },
                { "password", "password123" }
            };

            var response = await request.PostAsync("auth", new APIRequestContextOptions()
            {
                DataObject = data,
                Headers = headers
            });

            var jsonResponse = await response.JsonAsync<TokenResponse>(new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            
            return jsonResponse;
        }

        private async Task<TokenResponse?> GetTokenSerialized()
        {
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" }
            };

            var request = await playwright.APIRequest.NewContextAsync(new()
            {
                BaseURL = "https://restful-booker.herokuapp.com/"
            });

            var data = new TokenRequest()
            {
                UserName = "admin",
                Password = "password123"
            };

            var response = await request.PostAsync("auth", new APIRequestContextOptions()
            {
                DataObject = data,
                Headers = headers
            });

            var jsonResponse = await response.JsonAsync<TokenResponse>(new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            return jsonResponse;
        }
    }
}