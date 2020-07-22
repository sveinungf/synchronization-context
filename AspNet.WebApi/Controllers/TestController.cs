using System.Threading.Tasks;
using System.Web.Http;

namespace AspNet.WebApi.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "SynchronizationContext: " +
                   (System.Threading.SynchronizationContext.Current?.ToString() ?? "null") +
                   " TaskScheduler: " + TaskScheduler.Current;
        }
    }
}
