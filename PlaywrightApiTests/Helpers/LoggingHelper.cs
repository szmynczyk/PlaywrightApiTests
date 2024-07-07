using log4net;
using Microsoft.Playwright;
using System.Text;
using System.Text.Json;

namespace PlaywrightApiTests.Helpers
{
    internal class LoggingHelper
    {
        private readonly ILog _logger;

        public LoggingHelper(ILog logger)
        {
            _logger = logger;
        }

        internal void LogRequest(string requestName, HttpMethod httpMethod, string url, Dictionary<string, string>? headers = null, object? data = null)
        {
            var curlBuilder = new StringBuilder();
            curlBuilder.AppendLine($"curl -X {httpMethod} \\");
            curlBuilder.AppendLine($"{url} \\");

            if ( headers != null )
            {
                foreach (var header in headers)
                {
                    curlBuilder.AppendLine($"-H '{header.Key}: {header.Value}' \\");
                }
            }

            if (data != null)
            {
                var dataSerialized = JsonSerializer.Serialize(data, new JsonSerializerOptions()
                {
                    WriteIndented = true
                });

                curlBuilder.AppendLine($"-d '{dataSerialized}'");
            }

            _logger.Info($"{requestName}\n{curlBuilder}");
        }

        internal async Task LogResponse(string responseName, IAPIResponse response)
        {
            var responseBuilder = new StringBuilder();
            responseBuilder.AppendLine($"Status: {response.Status} {response.StatusText}");
            
            string responseBodyAsJson;

            if (response.Ok)
            {
                responseBodyAsJson = JsonSerializer.Serialize(await response.JsonAsync(), new JsonSerializerOptions()
                {
                    WriteIndented = true
                });
            }
            else
            {
                responseBodyAsJson = JsonSerializer.Serialize(await response.TextAsync());
            }

            responseBuilder.AppendLine(responseBodyAsJson);

            _logger.Info($"{responseName}\n{responseBuilder}");
        }
    }
}
