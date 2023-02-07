using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPharmacy.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        [Required]
        public String CustomerName { get; set; }
        [Required]
        public String CustomerGender { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact number is invalid")]
        public String CustomerContact { get; set; }
        [Required]
        public String CustomerDOB { get; set; }
        [Required]
        public String CustomerAddress { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is invalid")]
        [EmailAddress]
        public String CustomerEmail { get; set; }
        public virtual List<Appointment> Appointment { get; set; }
        public virtual List<Order> Order { get; set; }
    }
}
