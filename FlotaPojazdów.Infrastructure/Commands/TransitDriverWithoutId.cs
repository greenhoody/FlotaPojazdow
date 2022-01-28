using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaPojazdów.Infrastructure.Commands
{
    public class TransitDriverWithoutId
    {
        public int DriverId { get; set; }
        public int TransitId { get; set; }
    }
}
