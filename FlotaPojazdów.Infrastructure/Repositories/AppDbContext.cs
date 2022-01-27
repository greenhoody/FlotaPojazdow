using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FlotaPojazdów.Core.Domain;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaPojazdów.Infrastructure.Repositories
{
    public class AppDbContext:IdentityDbContext<IdentityUser>
    {
        public DbSet<Driver> Driver { get; set; }
        public DbSet<Transit> Transit { get; set; }
        public DbSet<TransitDriver> TransitDriver { get; set; }
        public DbSet<RegistrationDocument> RegistrationDocument { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
    }
}
