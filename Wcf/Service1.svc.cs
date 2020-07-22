using System.Threading.Tasks;

namespace Wcf
{
    public class Service1 : IService1
    {
        public async Task<string> GetData()
        {
            var value = "SynchronizationContext: " +
                   (System.Threading.SynchronizationContext.Current?.ToString() ?? "null") +
                   " TaskScheduler: " + TaskScheduler.Current;
            await Task.Delay(1);
            return value;
        }
    }
}
