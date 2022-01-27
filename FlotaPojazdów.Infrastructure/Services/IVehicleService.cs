using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlotaPojazdów.Infrastructure.DTO;

namespace FlotaPojazdów.Infrastructure.Services
{
    public interface IVehicleService
    {
        public Task<IEnumerable<VehicleDTO>> BrowseAll();
        public Task<VehicleDTO> GetVehicle(int id);
        public Task AddVehicle(VehicleDTO vehicle);
        public Task EditVehicle(VehicleDTO vehicle, int id);
        public Task DeleteVehicle(int id);
    }
}
