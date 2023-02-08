using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WangPharmacy.Shared.Domain
{
    public class Appointment : BaseDomainModel
    {
        [Required]
        public DateTime AppointmentDateTime { get; set; }
        [Required]
        public string AppointmentTime { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual List<Prescription> Prescription { get; set; }


    }
}

