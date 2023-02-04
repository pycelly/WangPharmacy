using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPharmacy.Shared.Domain
{
    public class Order : BaseDomainModel
    {
        public DateTime OrderDateTime { get; set; }
        public float OrderPayment { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<OrderItem> OrderItem { get; set; }


    }
}
