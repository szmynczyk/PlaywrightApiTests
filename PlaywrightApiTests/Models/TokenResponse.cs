using System.Text.Json.Serialization;

namespace PlaywrightApiTests.Models
{
    internal class TokenResponse
    {
        //[JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
