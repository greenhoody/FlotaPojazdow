using FlotaPojazdów.Infrastructure.Services;
using FlotaPojazdów.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc;
using FlotaPojazdów.Infrastructure.DTO;

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
        
        [HttpGet]
        public async Task<IActionResult> BroseAll()
        {
            var z = await _driverService.BrowseAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriver(int id)
        {
            var z = await _driverService.GetDriver(id);
            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] DriverWithoutId driverWithoutId)
        {
            DriverDTO d = new DriverDTO()
            {
                Name = driverWithoutId.Name,
                Surname = driverWithoutId.Surname,
                LicenceCategory = driverWithoutId.LicenceCategory,
                LicenceNumber = driverWithoutId.LicenceNumber
            };
            await _driverService.AddDriver(d);
            return Ok();
            //return RedirectToAction("BrowseAll");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditDriver([FromBody] DriverWithoutId driverWithoutId, int id)
        {
            DriverDTO d = new DriverDTO()
            {
                Name = driverWithoutId.Name,
                Surname = driverWithoutId.Surname,
                LicenceCategory = driverWithoutId.LicenceCategory,
                LicenceNumber = driverWithoutId.LicenceNumber
            };
            await _driverService.EditDriver(d, id);
            return Ok();
        }

    }
}
