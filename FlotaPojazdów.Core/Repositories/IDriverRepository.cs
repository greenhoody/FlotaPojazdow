using FlotaPojazdów.Core.Domain;

namespace FlotaPojazdów.Core.Repositories
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Driver>> GetAllAsync();
        Task<Driver> GetAsync(int id);
        Task DelAsync (Driver driver);
        Task UpdateAsync(Driver driver);
        Task CreateAsync (Driver driver);
    }
}
