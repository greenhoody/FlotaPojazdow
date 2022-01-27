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
    public class TransitService : ITransitService
    {
        private readonly ITransitRepository _transitRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public TransitService(ITransitRepository transitRepository, IVehicleRepository vehicleRepository)
        {
            _transitRepository = transitRepository;
            _vehicleRepository = vehicleRepository;
        }

        public async Task AddTransit(TransitDTO transit)
        {
            var t = new Transit()
            {
                Destination = transit.Destination,
                Start = transit.Start,
                StartDate = transit.StartDate,
                EndDate = transit.EndDate,
                Vehicle = _vehicleRepository.GetAsync(transit.VehicleId).Result
            };
            await _transitRepository.CreateAsync(t);
        }

        public async Task<IEnumerable<TransitDTO>> BrowseAll()
        {
            var z = await _transitRepository.GetAllAsync();
            return z.Select(x => new TransitDTO()
            {
                Id = x.Id,
                Destination = x.Destination,
                Start = x.Start,
                StartDate= x.StartDate,
                EndDate= x.EndDate,
                VehicleId = x.Vehicle.Id
            });
        }

        public async Task DeleteTransit(int id)
        {
            await _transitRepository.DelAsync(_transitRepository.GetAsync(id).Result);
        }

        public async Task EditTransit(TransitDTO transit, int id)
        {
           var t = new Transit()
           {
               Id = id,
               Destination = transit.Destination,
               Start = transit.Start,
               StartDate = transit.StartDate,
               EndDate = transit.EndDate,
               Vehicle = _vehicleRepository.GetAsync(transit.VehicleId).Result
           };
           await _transitRepository.UpdateAsync(t);
        }

        public async Task<TransitDTO> GetTransit(int id)
        {
            var transit = await _transitRepository.GetAsync(id);
            var t = new TransitDTO()
            {
                Id = transit.Id,
                Destination = transit.Destination,
                Start = transit.Start,
                StartDate = transit.StartDate,
                EndDate = transit.EndDate,
                VehicleId = transit.Vehicle.Id
            };
            return t;
        }
    }
}
