using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlotaPojazdów.Core.Domain;

namespace FlotaPojazdów.Core.Repositories
{
    public interface ITransitRepository
    {
        Task<IEnumerable<Transit>> GetAllAsync();
        Task<Transit> GetAsync(int id);
        Task DelAsync(Transit transit);
        Task UpdateAsync(Transit transit);
        Task CreateAsync(Transit transit);
    }
}
