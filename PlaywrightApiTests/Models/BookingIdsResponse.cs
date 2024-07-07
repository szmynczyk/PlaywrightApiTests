using System.Text.Json.Serialization;

namespace PlaywrightApiTests.Models
{
    internal class BookingIdsResponse
    {
        [JsonPropertyName("bookingid")]
        public int BookingId { get; set; }
    }
}