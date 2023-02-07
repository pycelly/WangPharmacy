using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WangPharmacy.Shared.Domain
{
    public class Appointment : BaseDomainModel, IValidatableObject
    {       
        [Required]
        public DateTime? AppointmentDateTime { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual List<Prescription> Prescription { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (AppointmentDateTime != null)
            {
                if (AppointmentDateTime < DateTime.Now)
                {
                    yield return new ValidationResult("Appointment date cannot be in the past", new[] { "Appointment date" });
                }
            }
        }
    }
}
