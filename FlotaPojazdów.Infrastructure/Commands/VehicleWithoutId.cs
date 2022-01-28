using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaPojazdów.Infrastructure.Commands
{
    public class VehicleWithoutId
    {
        public string Vin { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int RegistrationDocumentId { get; set; }
    }
}
