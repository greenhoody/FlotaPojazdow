using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlotaPojazdów.Infrastructure.DTO;

namespace FlotaPojazdów.Infrastructure.Services
{
    public interface IRegistrationDocumentService
    {
        public Task<IEnumerable<RegistrationDocumentDTO>> BrowseAll();
        public Task<RegistrationDocumentDTO> GetRegistrationDocument(int id);
        public Task AddRegistrationDocument(RegistrationDocumentDTO rd);
        public Task EditRegistrationDocument(RegistrationDocumentDTO rd, int id);
        public Task DeleteRegistrationDocument(int id);
    }
}
