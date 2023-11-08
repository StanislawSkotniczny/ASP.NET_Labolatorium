using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Labolatorium_5_EF.Models
{
    public class Contact
    {
        [HiddenInput]
        public int Id { get; set; }
        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Imię jest wymagane!")]
        [StringLength(maximumLength: 50, ErrorMessage = "Wprowadzone imię jest za długie, wprowadź maksymalnie do 50 znaków.")]
        public string Name { get; set; }
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Numer telefonu")]
        public string Phone { get; set; }
        [Display(Name = "Data urodzin")]
        [DataType(DataType.Date)]
        public DateTime? Birth { get; set; }

       

        [HiddenInput(DisplayValue = false)]
        public DateTime Created { get; set; }
    }
}
