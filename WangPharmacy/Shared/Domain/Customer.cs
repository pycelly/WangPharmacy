using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPharmacy.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        public String CustomerName { get; set; }
        public String CustomerGender { get; set; }
        public int CustomerContact { get; set; }
        public String CustomerDOB { get; set; }
        public String CustomerAddress { get; set; }
        public String CustomerEmail { get; set; }
        public virtual List<Appointment> Appointment { get; set; }
        public virtual List<Order> Order { get; set; }
    }
}
