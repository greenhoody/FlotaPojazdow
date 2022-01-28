using System;

namespace FlotaPojazdów.WebApp.Models
{
    public class DriverVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LicenceCategory { get; set; }
        public string LicenceNumber { get; set; }
    }
}
