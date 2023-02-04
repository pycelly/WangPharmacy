using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPharmacy.Shared.Domain
{
    public class Medicine : BaseDomainModel
    {
        public String MedicineName { get; set; }
        public String MedicineType { get; set; }
        public String MedicineDescription { get; set; }
        public double MedicinePrice { get; set; }
        public virtual List<PrescriptionItem> PrescriptionItem { get; set; }
        public virtual List<OrderItem> OrderItem { get; set; }

    }
    
    
}
