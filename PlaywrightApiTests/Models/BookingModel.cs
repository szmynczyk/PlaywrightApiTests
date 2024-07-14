using System.Text.Json.Serialization;

namespace PlaywrightApiTests.Models
{
	internal class BookingModel
	{
		[JsonPropertyName("firstname")]
		public string? FirstName { get; set; }
		[JsonPropertyName("lastname")]
		public string? LastName { get; set; }
		[JsonPropertyName("totalprice")]
		public int TotalPrice { get; set; }
		[JsonPropertyName("depositpaid")]
		public bool DepositPaid { get; set; }
		[JsonPropertyName("bookingdates")]
		public BookingDates? BookingDates { get; set; }
		[JsonPropertyName("additionalneeds")]
		public string? AdditionalNeeds { get; set; }
	}

	internal class BookingDates
	{
		[JsonPropertyName("checkin")]
		public DateOnly CheckIn { get; set; }
		[JsonPropertyName("checkout")]
		public DateOnly CheckOut { get; set; }
	}
}
