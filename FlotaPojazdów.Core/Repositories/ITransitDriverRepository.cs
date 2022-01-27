using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlotaPojazdów.Core.Domain;

namespace FlotaPojazdów.Core.Repositories
{
    public interface ITransitDriverRepository
    {
        Task<IEnumerable<TransitDriver>> GetAllAsync();
        Task<TransitDriver> GetAsync(int id);
        Task DelAsync(TransitDriver transitDriver);
        Task UpdateAsync(TransitDriver transitDriver);
        Task CreateAsync(TransitDriver transitDriver);
    }
}
