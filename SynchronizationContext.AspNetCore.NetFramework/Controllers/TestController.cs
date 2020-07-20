using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNetCore.NetFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
