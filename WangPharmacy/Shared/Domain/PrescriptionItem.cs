using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPharmacy.Shared.Domain
{
    public class PrescriptionItem: BaseDomainModel
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Prescription quantity cannot be 0")]
        public int PrescriptionQuantity { get; set; }
        [Required]
        public int MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
        [Required]
        public int PrescriptionId { get; set; }
        public virtual Prescription Prescription { get; set; }
        public virtual OrderItem OrderItem { get; set; }

    }
}
