using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlotaPojazdów.Core.Domain;


namespace FlotaPojazdów.Core.Repositories
{
    public interface IRegistrationDocumentRepository
    {
        Task<IEnumerable<RegistrationDocument>> GetAllAsync();
        Task<RegistrationDocument> GetAsync(int id);
        Task DelAsync(RegistrationDocument registrationDocument);
        Task UpdateAsync(RegistrationDocument registrationDocument);
        Task CreateAsync(RegistrationDocument registrationDocument);
    }
}
