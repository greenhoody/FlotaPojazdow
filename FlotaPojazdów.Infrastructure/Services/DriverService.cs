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
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task AddDriver(DriverDTO driver)
        {
            var d = new Driver()
            {
                Name = driver.Name,
                Surname = driver.Surname,
                LicenceCategory = driver.LicenceCategory,
                LicenceNumber = driver.LicenceNumber
            };
            await _driverRepository.CreateAsync(d);
        }

        public async Task<IEnumerable<DriverDTO>> BrowseAll()
        {
            var z = await _driverRepository.GetAllAsync();
            return z.Select(x => new DriverDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                LicenceCategory = x.LicenceCategory,
                LicenceNumber = x.LicenceNumber
            });
        }

        public async Task DeleteDriver(int id)
        {
            await _driverRepository.DelAsync(_driverRepository.GetAsync(id).Result);
        }
        public async Task EditDriver(DriverDTO driver, int id)
        {
            var d = new Driver()
            {
                Id = id,
                Name = driver.Name,
                Surname=driver.Surname,
                LicenceCategory=driver.LicenceCategory,
                LicenceNumber=driver.LicenceNumber
            };
            await _driverRepository.UpdateAsync(d);
        }

        public async Task<DriverDTO> GetDriver(int id)
        {
            var driver = await _driverRepository.GetAsync(id);
            var d = new DriverDTO()
            {
                Id = driver.Id,
                Name = driver.Name,
                Surname = driver.Surname,
                LicenceCategory = driver.LicenceCategory,
                LicenceNumber = driver.LicenceNumber
            };
            return d;
        }
    }
}
