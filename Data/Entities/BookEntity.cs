using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{

    [Table("books")]
    public class BookEntity
    {
        
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength (100)]
        public string Author { get; set; }

        public string PageNumber { get; set; }

        [MaxLength(13)]
        public string ISBN { get; set; }
        public string PublicationYear { get; set; }
        public string Publisher { get; set; }

        public RentalEntity? Rental { get; set; }
        public int? RentalId { get; set; }
        
    }
}
