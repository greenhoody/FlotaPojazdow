using FlotaPojazdów.Infrastructure.Services;
using FlotaPojazdów.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc;
using FlotaPojazdów.Infrastructure.DTO;

namespace FlotaPojazdów.WebApi.Controllers
{
    [Route("[Controller]")]
    public class TransitController : Controller
    {
        private readonly ITransitService _transitService;

        public TransitController(ITransitService transitService)
        {
            _transitService = transitService;
        }

        [HttpGet]
        public async Task<IActionResult> BroseAll()
        {
            var z = await _transitService.BrowseAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransit(int id)
        {
            var z = await GetTransit(id);
            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> AddTransit([FromBody] TransitWithouId transit)
        {
            TransitDTO t = new TransitDTO()
            {
                Start = transit.Start,
                Destination = transit.Destination,
                StartDate = transit.StartDate,
                EndDate = transit.EndDate,
            };
            await _transitService.AddTransit(t);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditTransit ([FromBody] TransitWithouId transit, int id)
        {
            TransitDTO transitDTO = new TransitDTO() 
            {
                Start = transit.Start,
                Destination = transit.Destination,
                StartDate = transit.StartDate,
                EndDate = transit.EndDate,
            };
            await _transitService.EditTransit(transitDTO, id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            await _transitService.DeleteTransit(id);
            return Ok();
        }
    }
}
