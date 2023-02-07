using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPharmacy.Shared.Domain
{
    public class Prescription : BaseDomainModel
    {
        [Required]
        public String PrescriptionName { get; set; }
        [Required]
        public String PrescriptionDescription { get; set; }
        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
        public virtual List<PrescriptionItem> PrescriptionItem { get; set; }


    }
}
