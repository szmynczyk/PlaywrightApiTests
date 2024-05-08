using System.Text.Json.Serialization;

namespace PlaywrightApiTests
{
    internal class BookingResponse
    {
        [JsonPropertyName("bookingid")]
        public int BookingId { get; set; }
    }
}
