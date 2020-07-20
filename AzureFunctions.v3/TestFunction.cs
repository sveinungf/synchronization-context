using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Threading.Tasks;

namespace AzureFunctions.v3
{
    public static class TestFunction
    {
        [FunctionName("Test")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            var value = "SynchronizationContext: " +
                        (System.Threading.SynchronizationContext.Current?.ToString() ?? "null") +
                        " TaskScheduler: " + TaskScheduler.Current;
            return new OkObjectResult(value);
        }
    }
}
