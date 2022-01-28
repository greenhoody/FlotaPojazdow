using Microsoft.AspNetCore.Mvc;

namespace FlotaPojazdów.WebApp.Controllers
{
    public class TransitDriverController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
