using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaPojazdów.Infrastructure.DTO
{
    public class TransitDTO
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public string Start { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int VehicleId { get; set; }
    }
}
