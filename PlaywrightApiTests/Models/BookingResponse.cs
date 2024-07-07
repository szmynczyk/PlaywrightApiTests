namespace PlaywrightApiTests.Models
{
    internal class BookingResponse
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int TotalPrice { get; set; }
        public bool DepositPaid { get; set; }
        public BookingDates? BookingDates { get; set; }
        public string? AdditionalNeeds { get; set; }
    }

    internal class BookingDates
    {
        public DateOnly CheckIn { get; set; }
        public DateOnly CheckOut { get; set; }
    }
}
