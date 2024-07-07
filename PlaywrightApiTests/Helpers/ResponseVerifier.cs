using PlaywrightApiTests.Models;

namespace PlaywrightApiTests.Helpers
{
    internal static class ResponseVerifier
    {
        public static void SimpleVerifyProperResponse<T>(ApiResponse<T>? response) where T : class
        {
            Assert.That(response, Is.Not.Null, "Response is null");
            Assert.That(response.ErrorContent, Is.Null, "For proper request ErrorContent should be null");
            Assert.That(response.Data, Is.Not.Null, "Response Data is null");
            Assert.That(response.Data, Is.TypeOf(typeof(T)), "Response Data has wrong type");
        }
    }
}
