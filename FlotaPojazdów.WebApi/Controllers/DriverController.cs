using FlotaPojazdów.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlotaPojazdów.WebApi.Controllers
{
    [Route("[Controller]")]
    public class DriverController : Controller
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
