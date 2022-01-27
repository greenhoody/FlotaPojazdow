using FlotaPojazdów.Core.Domain;
using FlotaPojazdów.Core.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaPojazdów.Infrastructure.Repositories
{
    public class TransitDriverRepository : ITransitDriverRepository
    {
        private AppDbContext _appDbContext;

        public TransitDriverRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<TransitDriver>> GetAllAsync()
        {
            return await Task.FromResult(_appDbContext.TransitDriver);
        }

        public async Task<TransitDriver> GetAsync(int Id)
        {
            TransitDriver transitDriver = null;
            try
            {
                transitDriver = _appDbContext.TransitDriver.FirstOrDefault(x => x.Id == Id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
            return transitDriver;
        }

        public async Task DelAsync(TransitDriver transitDriver)
        {
            try
            {
                _appDbContext.Remove(transitDriver);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task UpdateAsync(TransitDriver transitDriver)
        {
            try
            {
                var d = _appDbContext.TransitDriver.FirstOrDefault(x => x.Id == transitDriver.Id);
                d.Driver = transitDriver.Driver;
                d.Transit = transitDriver.Transit;
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task CreateAsync(TransitDriver transitDriver)
        {
            try
            {
                _appDbContext.TransitDriver.Add(transitDriver);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
}
