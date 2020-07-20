using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace MsTest.NetCore
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var value = "SynchronizationContext: " +
                        (System.Threading.SynchronizationContext.Current?.ToString() ?? "null") +
                        " TaskScheduler: " + TaskScheduler.Current;
            Assert.IsTrue(false, value);
        }
    }
}
