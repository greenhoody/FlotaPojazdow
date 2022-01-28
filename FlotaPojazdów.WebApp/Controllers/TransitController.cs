using Microsoft.AspNetCore.Mvc;

namespace FlotaPojazdów.WebApp.Controllers
{
    public class TransitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
