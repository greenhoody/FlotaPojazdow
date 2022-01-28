using Microsoft.AspNetCore.Mvc;

namespace FlotaPojazdów.WebApi.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
