using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlotaPojazdów.Core.Domain;
using FlotaPojazdów.Core.Repositories;

namespace FlotaPojazdów.Infrastructure.Repositories
{
    public class RegistrationDocumentRepository : IRegistraionDocumentRepository
    {
        private AppDbContext _appDbContext;

        public RegistrationDocumentRepository (AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<RegistrationDocument>> GetAllAsync()
        {
            return await Task.FromResult(_appDbContext.RegistrationDocument);
        }

        public async Task<RegistrationDocument> GetAsync(int Id)
        {
            RegistrationDocument rd = null;
            try
            {
                rd = _appDbContext.RegistrationDocument.FirstOrDefault(x => x.Id == Id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
            return rd;
        }

        public async Task DelAsync(RegistrationDocument rd)
        {
            try
            {
                _appDbContext.Remove(rd);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task UpdateAsync(RegistrationDocument rd)
        {
            try
            {
                var d = _appDbContext.RegistrationDocument.FirstOrDefault(x => x.Id == rd.Id);
                d.Vehicle = rd.Vehicle;
                d.DateOfIssue = rd.DateOfIssue;
                d.ExpireDate = rd.ExpireDate;
                d.FirstRegistration = rd.FirstRegistration;
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task CreateAsync(RegistrationDocument rd)
        {
            try
            {
                _appDbContext.RegistrationDocument.Add(rd);
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

