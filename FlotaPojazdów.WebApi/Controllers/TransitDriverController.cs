using FlotaPojazdów.Infrastructure.Services;
using FlotaPojazdów.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc;
using FlotaPojazdów.Infrastructure.DTO;

namespace FlotaPojazdów.WebApi.Controllers
{
    [Route("[Controller]")]
    public class TransitDriverController : Controller
    {
        private readonly ITransitDriverService _transitDriverService;

        public TransitDriverController(ITransitDriverService transitDriverService)
        {
            _transitDriverService = transitDriverService;
        }

        [HttpGet]
        public async Task<IActionResult> BroseAll()
        {
            var z = await _transitDriverService.BrowseAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransitDriver(int id)
        {
            var z = await _transitDriverService.BrowseAll();
            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> AddTransitDriver([FromBody] TransitDriverWithoutId transitDriverWithoutId)
        {
            TransitDriverDTO t = new TransitDriverDTO()
            {
                DriverId = transitDriverWithoutId.DriverId,
                TransitId = transitDriverWithoutId.TransitId,
            };
            await _transitDriverService.AddTransitDriver(t);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditTransitDriver([FromBody] TransitDriverWithoutId transitDriverWithoutId, int id)
        {
            TransitDriverDTO t = new TransitDriverDTO() 
            { 
                TransitId = transitDriverWithoutId.TransitId, 
                DriverId = transitDriverWithoutId.DriverId 
            };
            await _transitDriverService.EditTransitDriver(t, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransitDriver(int id)
        {
            await _transitDriverService.DeleteTransitDriver(id);
            return Ok();
        }
    }
}
