using System;

namespace Labolatorium_2.Models
{
    public class Birth
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) && DateOfBirth < DateTime.Now;
        }

        public int CalculateAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age))
                age--;
            return age;
        }
    }
}
