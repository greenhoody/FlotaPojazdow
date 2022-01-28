using Microsoft.AspNetCore.Mvc;

namespace FlotaPojazdów.WebApi.Controllers
{
    public class TransitDriverController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
