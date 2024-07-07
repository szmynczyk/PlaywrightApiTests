using log4net;
using Microsoft.Playwright;
using PlaywrightApiTests.Helpers;
using PlaywrightApiTests.Models;

namespace PlaywrightApiTests.Clients
{
    internal class TokenClient : ApiClientBase
    {
        private readonly LoggingHelper _loggingHelper;

        public TokenClient()
        {
            logger = LogManager.GetLogger(typeof(TokenClient));
            _loggingHelper = new LoggingHelper(logger);
        }

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

            _loggingHelper.LogRequest("Token request", HttpMethod.Post, $"{BaseUrl}auth", headers, data);

            var response = await request.PostAsync("auth", new APIRequestContextOptions()
            {
                DataObject = data,
                Headers = headers
            });

            await _loggingHelper.LogResponse("Get token response", response);

            return await ApiResponse<TokenResponse>.SerializeResponse(response);
        }
    }
}
