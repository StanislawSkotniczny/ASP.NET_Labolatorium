using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Labolatorium_3.Models
{
    public class Contact
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Imię jest wymagane!")]
        [StringLength(maximumLength: 50, ErrorMessage = "Wprowadzone imię jest za długie, wprowadź maksymalnie do 50 znaków.")]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public DateTime? Birth { get; set; }

    }
}
