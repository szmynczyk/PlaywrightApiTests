using Microsoft.Playwright;
using PlaywrightApiTests.Models;
using System.Text.Json;

namespace PlaywrightApiTests.Clients
{
    internal class TokenClient : ApiClientBase
    {
        internal async Task<TokenResponse?> GetToken()
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

        internal async Task<TokenResponse?> GetTokenSerialized()
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
