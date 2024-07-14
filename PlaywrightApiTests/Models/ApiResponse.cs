using Microsoft.Playwright;
using System.Text.Json;

namespace PlaywrightApiTests.Models
{
	internal class ApiResponse<T> where T : class
	{
		public int StatusCode { get; set; }
		public bool IsSuccess => StatusCode is >= 200 and <= 299;
		public required string ResponseUrl { get; set; }
		public T? Data { get; set; }
		public string? ErrorContent { get; set; } = null;

		internal static async Task<ApiResponse<T>> SerializeResponse(IAPIResponse response, bool caseInsensitive = true)
		{
			return new ApiResponse<T>
			{
				StatusCode = response.Status,
				ResponseUrl = response.Url,
				Data = response.Ok ? await response.JsonAsync<T>(new JsonSerializerOptions()
				{
					PropertyNameCaseInsensitive = caseInsensitive
				}) : null,
				ErrorContent = !response.Ok ? await response.TextAsync() : null
			};
		}
	}
}
