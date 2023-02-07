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
        public int PrescriptionQuantity { get; set; }
        public int MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
        public int PrescriptionId { get; set; }
        public virtual Prescription Prescription { get; set; }
        public virtual OrderItem OrderItem { get; set; }

    }
}
