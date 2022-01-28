using Microsoft.AspNetCore.Mvc;

namespace FlotaPojazdów.WebApi.Controllers
{
    public class TransitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
