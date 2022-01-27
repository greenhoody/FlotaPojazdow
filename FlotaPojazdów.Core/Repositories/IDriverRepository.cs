using FlotaPojazdów.Core.Domain;

namespace FlotaPojazdów.Core.Repositories
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Driver>> GetAllDriversAsync();
        Task<Driver> Getasync(int id);
        Task DelAsync (Driver driver);
        Task UpdateAsync(Driver driver);
        Task AddAsync (Driver driver);
    }
}
