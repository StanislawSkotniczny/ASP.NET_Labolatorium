using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_3.Models
{

   public enum Priority
    {
        [Display(Name ="Niski")]
        Low ,
        [Display(Name = "Normalny")]
        Normal ,
        [Display(Name = "Pilny")]
        Urgent
    }




    public class Contact
    {
        [HiddenInput]
        public int Id { get; set; }
        [Display(Name="Imię")]
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

        [Display(Name = "Priorytet")]
        public Priority Priority { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime Created { get; set; }


    }
}
