using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace donet_dev_day_2024
{
    public class UserName {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string FullName => FirstName ?? string.Empty;
    }

    public class TriggerHTTP(ILoggerFactory loggerFactory)
    {
        private readonly ILogger _logger = loggerFactory.CreateLogger<TriggerHTTP>();

        [Function("TriggerHTTP")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            
            var user = await req.ReadFromJsonAsync<UserName>() ?? new UserName();

            await response.WriteAsJsonAsync(new {
                message = $"Hello {user.FullName} from Azure Functions!"
            });

            return response;
        }
    }
}
