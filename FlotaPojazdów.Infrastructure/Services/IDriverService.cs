using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlotaPojazdów.Infrastructure.DTO;

namespace FlotaPojazdów.Infrastructure.Services
{
    public interface IDriverService
    {
        public Task<IEnumerable<DriverDTO>> BrowseAll();
        public Task<DriverDTO> GetDriver(int id);
        public Task AddDriver(DriverDTO driver);
        public Task EditDriver(DriverDTO driver, int id);
        public Task DeleteDriver(int id);
    }
}
