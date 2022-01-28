using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaPojazdów.Infrastructure.Commands
{
    public class DriverWithoutId
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LicenceCategory { get; set; }
        public string LicenceNumber { get; set; }
    }
}
