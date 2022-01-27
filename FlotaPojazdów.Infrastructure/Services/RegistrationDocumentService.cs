using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlotaPojazdów.Core.Repositories;
using FlotaPojazdów.Infrastructure.DTO;
using FlotaPojazdów.Core.Domain;

namespace FlotaPojazdów.Infrastructure.Services
{
    public class RegistrationDocumentService : IRegistrationDocumentService
    {
        private readonly IRegistrationDocumentRepository _registraionDocumentRepository;

        public RegistrationDocumentService(IRegistrationDocumentRepository rdRepository)
        {
            _registraionDocumentRepository = rdRepository;
        }

        public async Task AddRegistrationDocument(RegistrationDocumentDTO rd)
        {
            var d = new RegistrationDocument()
            {
                DateOfIssue = rd.DateOfIssue,
                ExpireDate = rd.ExpireDate,
                FirstRegistration = rd.FirstRegistration,
            };
            await _registraionDocumentRepository.CreateAsync(d);
        }

        public async Task<IEnumerable<RegistrationDocumentDTO>> BrowseAll()
        {
            var d = await _registraionDocumentRepository.GetAllAsync();
            return d.Select(rd => new RegistrationDocumentDTO() 
            {
                Id = rd.Id,
                DateOfIssue = rd.DateOfIssue,
                ExpireDate = rd.ExpireDate,
                FirstRegistration = rd.FirstRegistration
            });
        }

        public async Task DeleteRegistrationDocument(int id)
        {
            await _registraionDocumentRepository.DelAsync(_registraionDocumentRepository.GetAsync(id).Result);
        }

        public async Task EditRegistrationDocument(RegistrationDocumentDTO rd, int id)
        {
            var d = new RegistrationDocument()
            {
                Id = id,
                DateOfIssue = rd.DateOfIssue,
                ExpireDate = rd.ExpireDate,
                FirstRegistration = rd.FirstRegistration
            };
            await _registraionDocumentRepository.UpdateAsync(d);
        }

        public async Task<RegistrationDocumentDTO> GetRegistrationDocument(int id)
        {
            var rd = await _registraionDocumentRepository.GetAsync(id);
            var d = new RegistrationDocumentDTO()
            {
                Id = rd.Id,
                DateOfIssue = rd.DateOfIssue,
                ExpireDate = rd.ExpireDate,
                FirstRegistration = rd.FirstRegistration
            };
            return d;
        }
    }
}
