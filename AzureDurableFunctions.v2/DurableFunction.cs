using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AzureDurableFunctions.v2
{
    public static class DurableFunction
    {
        [FunctionName(nameof(DurableOrchestrator))]
        public static async Task<List<string>> DurableOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var outputs = new List<string>();

            var value = "Orchestrator - SynchronizationContext: " +
                        (System.Threading.SynchronizationContext.Current?.ToString() ?? "null") +
                        " TaskScheduler: " + TaskScheduler.Current;

            outputs.Add(value);
            outputs.Add(await context.CallActivityAsync<string>(nameof(DurableActivity), null));

            return outputs;
        }

        [FunctionName(nameof(DurableActivity))]
        public static string DurableActivity([ActivityTrigger] string ignore)
        {
            return "Activity - SynchronizationContext: " +
                   (System.Threading.SynchronizationContext.Current?.ToString() ?? "null") +
                   " TaskScheduler: " + TaskScheduler.Current;
        }

        [FunctionName(nameof(DurableStart))]
        public static async Task<HttpResponseMessage> DurableStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestMessage req,
            [DurableClient] IDurableOrchestrationClient starter)
        {
            var instanceId = await starter.StartNewAsync(nameof(DurableOrchestrator), null);
            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}