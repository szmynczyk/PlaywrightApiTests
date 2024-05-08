using System.Text.Json.Serialization;

namespace PlaywrightApiTests
{
    internal class TokenRequest
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [JsonPropertyName("password")]

        public string Password { get; set; }
    }
}
