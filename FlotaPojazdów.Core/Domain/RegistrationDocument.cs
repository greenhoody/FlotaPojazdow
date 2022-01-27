using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaPojazdów.Core.Domain
{
    public class RegistrationDocument
    {
        public int Id { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime FirstRegistration { get; set; }

    }
}
