using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlotaPojazdów.Infrastructure.DTO;

namespace FlotaPojazdów.Infrastructure.Services
{
    public interface ITransitTransitDriverService
    {
        public Task<IEnumerable<TransitDriverDTO>> BrowseAll();
        public Task<TransitDriverDTO> GetTransitDriver(int id);
        public Task AddTransitDriver(TransitDriverDTO transitDriver);
        public Task EditTransitDriver(TransitDriverDTO transitDriver, int id);
        public Task DeleteTransitDriver(int id);
    }
}
