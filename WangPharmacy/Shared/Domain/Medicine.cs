using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPharmacy.Shared.Domain
{
    public class Medicine : BaseDomainModel
    {
        [Required]
        public String MedicineName { get; set; }
        [Required]
        public String MedicineType { get; set; }
        [Required]
        public String MedicineDescription { get; set; }
        [Required]
        public double MedicinePrice { get; set; }
        public virtual List<PrescriptionItem> PrescriptionItem { get; set; }
        public virtual List<OrderItem> OrderItem { get; set; }

    }
    
    
}
