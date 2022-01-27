using FlotaPojazdów.Core.Domain;
using FlotaPojazdów.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaPojazdów.Infrastructure.Repositories
{
    public class DriverRepository:IDriverRepository
    {
        private AppDbContext _appDbContext;

        public DriverRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Driver>> GetAllAsync()
        {
            return await Task.FromResult(_appDbContext.Driver);
        }

        public async Task<Driver> GetAsync(int Id)
        {
            Driver driver = null;
            try
            {
                driver = _appDbContext.Driver.FirstOrDefault(x => x.Id == Id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
            return driver;
        }

        public async Task DelAsync(Driver driver)
        {
            try
            {
                _appDbContext.Remove(driver);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task UpdateAsync(Driver driver)
        {
            try
            {
                var d = _appDbContext.Driver.FirstOrDefault(x => x.Id == driver.Id);
                d.Name = driver.Name;
                d.Surname = driver.Surname;
                d.LicenceCategory = driver.LicenceCategory;
                d.LicenceNumber = driver.LicenceNumber;
                _appDbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task CreateAsync(Driver driver)
        {
            try
            {
                _appDbContext.Driver.Add(driver);
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
