using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlotaPojazdów.Core.Domain;
using FlotaPojazdów.Core.Repositories;

namespace FlotaPojazdów.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private AppDbContext _appDbContext;

        public VehicleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await Task.FromResult(_appDbContext.Vehicle);
        }

        public async Task<Vehicle> GetAsync(int Id)
        {
            Vehicle vehicle = null;
            try
            {
                vehicle = _appDbContext.Vehicle.FirstOrDefault(x => x.Id == Id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
            return vehicle;
        }

        public async Task DelAsync(Vehicle vehicle)
        {
            try
            {
                _appDbContext.Remove(vehicle);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task UpdateAsync(Vehicle vehicle)
        {
            try
            {
                var d = _appDbContext.Vehicle.FirstOrDefault(x => x.Id == vehicle.Id);
                d.Vin = vehicle.Vin;
                d.BrandName = vehicle.BrandName;
                d.Model = vehicle.Model;
                d.Type = vehicle.Type;
                d.RegistrationDocument = vehicle.RegistrationDocument;
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task CreateAsync(Vehicle vehicle)
        {
            try
            {
                _appDbContext.Vehicle.Add(vehicle);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
