using Grpc.Net.Client;
using Grpc.Service;
using System;
using System.Threading.Tasks;

namespace Grpc.Client
{
    public static class Program
    {
        private static async Task Main()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new SyncContextService.SyncContextServiceClient(channel);
            var reply = await client.CheckSyncContextAsync(new CheckSyncContextRequest());
            Console.WriteLine(reply.Message);
            Console.ReadKey();
        }
    }
}
