using FlotaPojazdów.Infrastructure.Services;
using FlotaPojazdów.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc;
using FlotaPojazdów.Infrastructure.DTO;

namespace FlotaPojazdów.WebApi.Controllers
{
    [Route("[Controller]")]
    public class VehicleController : Controller
    {
        
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            var z = await _vehicleService.BrowseAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var z = await _vehicleService.GetVehicle(id);
            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle([FromBody] VehicleWithoutId vehicleWithoutId)
        {
            VehicleDTO v = new VehicleDTO()
            {
                Vin = vehicleWithoutId.Vin,
                BrandName = vehicleWithoutId.BrandName,
                Model = vehicleWithoutId.Model,
                Type = vehicleWithoutId.Type,
                RegistrationDocumentId = vehicleWithoutId.RegistrationDocumentId,
            };
            await _vehicleService.AddVehicle(v);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditVehicle([FromBody] VehicleWithoutId vehicleWithoutId, int id)
        {
            VehicleDTO v = new VehicleDTO()
            {
                Vin = vehicleWithoutId.Vin,
                BrandName = vehicleWithoutId.BrandName,
                Model = vehicleWithoutId.Model,
                Type = vehicleWithoutId.Type,
                RegistrationDocumentId = vehicleWithoutId.RegistrationDocumentId
            };
            await _vehicleService.EditVehicle(v, id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            await _vehicleService.DeleteVehicle(id);
            return Ok();
        }
    }
}
