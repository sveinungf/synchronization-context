using Grpc.Core;
using System.Threading.Tasks;

namespace Grpc.Service.Services
{
    public class SyncContextService : Service.SyncContextService.SyncContextServiceBase
    {
        public override Task<CheckSyncContextReply> CheckSyncContext(CheckSyncContextRequest request, ServerCallContext context)
        {
            var value = "SynchronizationContext: " +
                        (System.Threading.SynchronizationContext.Current?.ToString() ?? "null") +
                        " TaskScheduler: " + TaskScheduler.Current;

            return Task.FromResult(new CheckSyncContextReply
            {
                Message = value
            });
        }
    }
}
