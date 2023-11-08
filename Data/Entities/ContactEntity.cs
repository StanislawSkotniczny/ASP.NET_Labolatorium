using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{

    [Table("contacts")]

    public class ContactEntity
    {
        
        public int Id { get; set; }
        [Column("name")]
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        
        public string? Phone { get; set; }

        public DateTime Birth { get; set; }
    }
}
