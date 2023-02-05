using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPharmacy.Shared.Domain
{
    public class OrderItem : BaseDomainModel
    {
        public int OrderQuantity { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
