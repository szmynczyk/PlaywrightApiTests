using System.Text.Json.Serialization;

namespace PlaywrightApiTests.Models
{
    internal class BookingResponse
    {
        [JsonPropertyName("bookingid")]
        public int BookingId { get; set; }
    }
}
