using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPharmacy.Shared.Domain
{
    public class Order : BaseDomainModel
    {
        [Required]
        public DateTime OrderDateTime { get; set; }
        [Required]
        public float OrderPayment { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<OrderItem> OrderItem { get; set; }


    }
}
