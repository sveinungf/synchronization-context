using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspNet.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "SynchronizationContext: " +
                              (System.Threading.SynchronizationContext.Current?.ToString() ?? "null") +
                              " TaskScheduler: " + TaskScheduler.Current;
            return View();
        }
    }
}