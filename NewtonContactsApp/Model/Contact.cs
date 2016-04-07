using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonContactsApp.Model
{
    public class Contact
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string CareOf { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string AppData { get; set; }
    }
}
