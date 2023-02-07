using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPharmacy.Shared.Domain
{
    public class Staff: BaseDomainModel
    {
        public String StaffName { get; set; }
        public String StaffGender { get; set; }
        public String StaffContact { get; set; }
        public String StaffEmail { get; set; }
        public virtual List<Appointment> Appointment { get; set; }
    }
}
