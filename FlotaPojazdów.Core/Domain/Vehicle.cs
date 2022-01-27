using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaPojazdów.Core.Domain
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Vin { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public RegistrationDocument RegistrationDocument { get; set; }

    }
}
