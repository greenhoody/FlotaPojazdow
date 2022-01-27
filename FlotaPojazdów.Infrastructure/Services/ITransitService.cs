using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlotaPojazdów.Infrastructure.DTO;

namespace FlotaPojazdów.Infrastructure.Services
{
    public interface ITransitService
    {
        public Task<IEnumerable<TransitDTO>> BrowseAll();
        public Task<TransitDTO> GetTransit(int id);
        public Task AddTransit(TransitDTO transit);
        public Task EditTransit(TransitDTO transit, int id);
        public Task DeleteTransit(int id);
    }
}
