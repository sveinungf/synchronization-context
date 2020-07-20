using System.Threading.Tasks;
using Xunit;

namespace xUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var value = "SynchronizationContext: " +
                        (System.Threading.SynchronizationContext.Current?.ToString() ?? "null") +
                        " TaskScheduler: " + TaskScheduler.Current;
            Assert.Null(value);
        }
    }
}
