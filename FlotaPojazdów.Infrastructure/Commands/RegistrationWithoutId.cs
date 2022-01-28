using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaPojazdów.Infrastructure.Commands
{
    public class RegistrationWithoutId
    {
        public DateTime DateOfIssue { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime FirstRegistration { get; set; }
    }
}
