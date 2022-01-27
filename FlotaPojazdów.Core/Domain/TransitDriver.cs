using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaPojazdów.Core.Domain
{
    public class TransitDriver
    {
        public int Id { get; set; }
        public Driver Driver { get; set; }
        public Transit Transit { get; set; }
    }
}
