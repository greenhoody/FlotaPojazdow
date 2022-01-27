using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaPojazdów.Core.Domain
{
    public class Transit
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public string Start { get; set;}

        public Vehicle Vehicle { get; set; }
    }
}
