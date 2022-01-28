using Microsoft.AspNetCore.Mvc;

namespace FlotaPojazdów.WebApp.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
