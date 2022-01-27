using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlotaPojazdów.Infrastructure.DTO
{
    public class RegistrationDocumentDTO
    {
        public int Id { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime FirstRegistration { get; set; }
    }
}
