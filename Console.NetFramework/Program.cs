using System.Threading.Tasks;

namespace Console.NetFramework
{
    public static class Program
    {
        private static void Main()
        {
            var value = "SynchronizationContext: " +
                        (System.Threading.SynchronizationContext.Current?.ToString() ?? "null") +
                        " TaskScheduler: " + TaskScheduler.Current;
            System.Console.WriteLine(value);
            System.Console.ReadLine();
        }
    }
}