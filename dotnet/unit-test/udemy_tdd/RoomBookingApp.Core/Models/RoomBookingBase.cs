using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoomBookingApp.Core.Models
{
    public abstract class RoomBookingBase : IValidatableObject
    {
        [Required]
        [StringLength(80)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(80)]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Date < DateTime.Now.Date)  // Date should be in the future
            {
                yield return new ValidationResult("Date Must be in the future", [nameof(Date)]);
            }
        }
    }
}