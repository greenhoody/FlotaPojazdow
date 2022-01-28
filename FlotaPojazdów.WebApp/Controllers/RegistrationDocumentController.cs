using Microsoft.AspNetCore.Mvc;

namespace FlotaPojazdów.WebApp.Controllers
{
    public class RegistrationDocumentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
