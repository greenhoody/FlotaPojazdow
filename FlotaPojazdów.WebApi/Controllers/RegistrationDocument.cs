using Microsoft.AspNetCore.Mvc;

namespace FlotaPojazdów.WebApi.Controllers
{
    [Route("[Controller]")]
    public class RegistrationDocument : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
