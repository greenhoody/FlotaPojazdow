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
    public class TransitDriverService:ITransitDriverService
    {
        private readonly ITransitDriverRepository _transitDriverRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly ITransitRepository _transitRepository;

        public TransitDriverService(ITransitDriverRepository transitDriverRepository, ITransitRepository transitRepository, IDriverRepository driverRepository)
        {
            _transitDriverRepository = transitDriverRepository;
            _driverRepository = driverRepository;
            _transitRepository = transitRepository;
        }

        public async Task AddTransitDriver(TransitDriverDTO transitDriver)
        {
            var td = new TransitDriver()
            {
                Driver = _driverRepository.GetAsync(transitDriver.DriverId).Result,
                Transit = _transitRepository.GetAsync(transitDriver.TransitId).Result
            };
            await _transitDriverRepository.CreateAsync(td);
        }

        public async Task<IEnumerable<TransitDriverDTO>> BrowseAll()
        {
            var z = await _transitDriverRepository.GetAllAsync();
            return z.Select(x => new TransitDriverDTO
            {
                Id = x.Id,
                DriverId = x.Driver.Id,
                TransitId = x.Transit.Id,
            });
        }

        public async Task DeleteTransitDriver(int id)
        {
            await _transitDriverRepository.DelAsync(_transitDriverRepository.GetAsync(id).Result);
        }

        public async Task EditTransitDriver(TransitDriverDTO transitDriver, int id)
        {
            var td = new TransitDriver()
            {
                Id = id,
                Driver = _driverRepository.GetAsync(transitDriver.DriverId).Result,
                Transit = _transitRepository.GetAsync(transitDriver.TransitId).Result
            };
            await _transitDriverRepository.UpdateAsync(td);
        }

        public async Task<TransitDriverDTO> GetTransitDriver(int id)
        {
            var transitDriver = await _transitDriverRepository.GetAsync(id);
            var td = new TransitDriverDTO()
            {
                Id = transitDriver.Id,
                DriverId = transitDriver.Driver.Id,
                TransitId = transitDriver.Transit.Id,
            };
            return td;
        }
    }
}
