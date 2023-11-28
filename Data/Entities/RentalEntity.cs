using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class RentalEntity
    {
        public int Id { get; set; }
        public string RentalName { get; set; }
        public string Description { get; set; }

        public RentingPerson RentingPerson { get; set; }
        public ISet<BookEntity> Books { get; set; }
    }
}
