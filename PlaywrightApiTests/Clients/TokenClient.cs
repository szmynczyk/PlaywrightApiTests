using Microsoft.Playwright;
using PlaywrightApiTests.Models;

namespace PlaywrightApiTests.Clients
{
    internal class TokenClient : ApiClientBase
    {
        Dictionary<string, string> headers = new Dictionary<string, string>
        {
            { "Content-Type", "application/json" }
        };

        public override string BaseUrl { get => "https://restful-booker.herokuapp.com/"; }

        internal async Task<ApiResponse<TokenResponse>?> GetTokenSimple()
        {
            var data = new Dictionary<string, string>()
            {
                { "username", "admin" },
                { "password", "password123" }
            };

            return await GetToken(data);
        }

        internal async Task<ApiResponse<TokenResponse>?> GetTokenSerialized()
        {
            var data = new TokenRequest()
            {
                UserName = "admin",
                Password = "password123"
            };

            return await GetToken(data);
        }
        
        internal async Task<ApiResponse<TokenResponse>?> GetToken(object data)
        {
            var request = await playwright.APIRequest.NewContextAsync(new()
            {
                BaseURL = BaseUrl
            });

            var response = await request.PostAsync("auth", new APIRequestContextOptions()
            {
                DataObject = data,
                Headers = headers
            });

            return await ApiResponse<TokenResponse>.SerializeResponse(response);
        }
    }
}
