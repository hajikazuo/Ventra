using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Ventra.Domain.Entities
{
    [Owned]
    public class Address
    {
        [Required]
        [MaxLength(100)]
        public string Street { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Number")]
        public string Number { get; set; }

        [MaxLength(100)]
        public string Complement { get; set; }

        [Required]
        [MaxLength(50)]
        public string Neighborhood { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(2)]
        public string State { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{8}$")]
        [MaxLength(8)]
        [UIHint("_CepTemplate")]
        public string ZipCode { get; set; }

        [MaxLength(100)]
        [Display(Name = "Reference")]
        public string Reference { get; set; }
    }

}
