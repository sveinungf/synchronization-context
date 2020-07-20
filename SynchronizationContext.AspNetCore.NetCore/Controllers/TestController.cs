using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNetCore.NetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "SynchronizationContext: " +
                   (System.Threading.SynchronizationContext.Current?.ToString() ?? "null") +
                   " TaskScheduler: " + TaskScheduler.Current;
        }
    }
}
