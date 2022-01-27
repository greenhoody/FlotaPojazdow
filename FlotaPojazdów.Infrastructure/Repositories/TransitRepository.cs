using FlotaPojazdów.Core.Domain;
using FlotaPojazdów.Core.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaPojazdów.Infrastructure.Repositories
{
    public class TransitRepository : ITransitRepository
    {
        private AppDbContext _appDbContext;

        public TransitRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Transit>> GetAllAsync()
        {
            return await Task.FromResult(_appDbContext.Transit);
        }

        public async Task<Transit> GetAsync(int Id)
        {
            Transit transit = null;
            try
            {
                transit = _appDbContext.Transit.FirstOrDefault(x => x.Id == Id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
            return transit;
        }

        public async Task DelAsync(Transit transit)
        {
            try
            {
                _appDbContext.Remove(transit);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task UpdateAsync(Transit transit)
        {
            try
            {
                var d = _appDbContext.Transit.FirstOrDefault(x => x.Id == transit.Id);
                d.Destination = transit.Destination;
                d.Start = transit.Start;
                d.StartDate = transit.StartDate;
                d.EndDate = transit.EndDate;
                d.Vehicle = transit.Vehicle;
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task CreateAsync(Transit transit)
        {
            try
            {
                _appDbContext.Transit.Add(transit);
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
