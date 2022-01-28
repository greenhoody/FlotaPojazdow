using FlotaPojazdów.Infrastructure.Services;
using FlotaPojazdów.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc;
using FlotaPojazdów.Infrastructure.DTO;

namespace FlotaPojazdów.WebApi.Controllers
{
    [Route("[Controller]")]
    public class RegistrationDocumentController : Controller
    {
        private readonly IRegistrationDocumentService _registrationDocumentService;

        public RegistrationDocumentController(IRegistrationDocumentService registrationDocumentService)
        {
            _registrationDocumentService = registrationDocumentService;
        }
        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            var z = await _registrationDocumentService.BrowseAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistrationDocument(int id)
        {
            var z = await _registrationDocumentService.GetRegistrationDocument(id);
            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegistrationDocument([FromBody] RegistrationWithoutId registrationWithoutId)
        {
            RegistrationDocumentDTO r = new RegistrationDocumentDTO()
            {
                DateOfIssue = registrationWithoutId.DateOfIssue,
                ExpireDate = registrationWithoutId.ExpireDate,
                FirstRegistration = registrationWithoutId.FirstRegistration,
            };
            await _registrationDocumentService.AddRegistrationDocument(r);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditRegistrationDocument([FromBody] RegistrationWithoutId registrationWithoutId, int Id)
        {
            RegistrationDocumentDTO r = new RegistrationDocumentDTO()
            {
                FirstRegistration = registrationWithoutId.FirstRegistration,
                DateOfIssue= registrationWithoutId.DateOfIssue,
                ExpireDate= registrationWithoutId.ExpireDate,
            };
            await _registrationDocumentService.EditRegistrationDocument(r, Id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistrationDocument(int id)
        {
            await _registrationDocumentService.DeleteRegistrationDocument(id);
            return Ok();
        }
    }
}
