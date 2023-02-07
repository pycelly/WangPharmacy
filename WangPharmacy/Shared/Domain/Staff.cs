using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangPharmacy.Shared.Domain
{
    public class Staff: BaseDomainModel
    {
        [Required]
        public String StaffName { get; set; }
        [Required]
        public String StaffGender { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact number is invalid")]
        public String StaffContact { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is invalid")]
        [EmailAddress]
        public String StaffEmail { get; set; }
        public virtual List<Appointment> Appointment { get; set; }
    }
}
