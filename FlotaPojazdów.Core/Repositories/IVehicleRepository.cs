using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using FlotaPojazdów.Core.Domain;

namespace FlotaPojazdów.Core.Repositories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAllAsync();
        Task<Vehicle> GetAsync (int id);
        Task DelAsync(Vehicle vehicle);
        Task UpdateAsync (Vehicle vehicle);
        Task CreateAsync (Vehicle vehicle);
    }
}
