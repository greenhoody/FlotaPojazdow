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
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IRegistrationDocumentRepository _registrationDocumentRepository;

        public VehicleService(IVehicleRepository vehicleRepository, IRegistrationDocumentRepository registrationDocumentRepository)
        {
            _vehicleRepository = vehicleRepository;
            _registrationDocumentRepository = registrationDocumentRepository;
        }

        public async Task AddVehicle(VehicleDTO vehicle)
        {
            var v = new Vehicle()
            {
                Vin = vehicle.Vin,
                BrandName = vehicle.BrandName,
                Model = vehicle.Model,
                Type = vehicle.Type,
                RegistrationDocument = _registrationDocumentRepository.GetAsync(vehicle.RegistrationDocumentId).Result
            };
            await _vehicleRepository.CreateAsync(v);
        }

        public async Task<IEnumerable<VehicleDTO>> BrowseAll()
        {
            var z = await _vehicleRepository.GetAllAsync();
            return z.Select(x => new VehicleDTO
            {
                Id = x.Id,
                Vin = x.Vin,
                BrandName=x.BrandName,
                Model=x.Model,
                Type=x.Type,
                RegistrationDocumentId = x.RegistrationDocument.Id
            });
        }

        public async Task DeleteVehicle(int id)
        {
            await _vehicleRepository.DelAsync(_vehicleRepository.GetAsync(id).Result);
        }

        public async Task EditVehicle(VehicleDTO vehicle, int id)
        {
            var v = new Vehicle()
            {
                Id = id,
                Vin = vehicle.Vin,
                BrandName = vehicle.BrandName,
                Model = vehicle.Model,
                Type = vehicle.Type,
                RegistrationDocument = _registrationDocumentRepository.GetAsync(vehicle.RegistrationDocumentId).Result
            };
            await _vehicleRepository.UpdateAsync(v);
        }

        public async Task<VehicleDTO> GetVehicle(int id)
        {
            var vehicle = await _vehicleRepository.GetAsync(id);
            var v = new VehicleDTO()
            {
                Id = vehicle.Id,
                Vin = vehicle.Vin,
                BrandName = vehicle.BrandName,
                Model = vehicle.Model,
                Type = vehicle.Type,
                RegistrationDocumentId = vehicle.RegistrationDocument.Id
            };
            return v;
        }
    }
}
