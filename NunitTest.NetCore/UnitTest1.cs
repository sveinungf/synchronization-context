using NUnit.Framework;
using System.Threading.Tasks;

namespace NunitTest.NetCore
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var value = "SynchronizationContext: " +
                        (System.Threading.SynchronizationContext.Current?.ToString() ?? "null") +
                        " TaskScheduler: " + TaskScheduler.Current;
            Assert.IsTrue(false, value);
        }
    }
}