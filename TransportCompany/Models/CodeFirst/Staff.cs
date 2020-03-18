using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompany.Models.CodeFirst
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string FioStaff { get; set; }

        public int Age { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        [MaxLength(12)]
        public string Telephone { get; set; }

        [MaxLength(50)]
        public string Passport { get; set; }

        [Required]
        public int PositionId { get; set; }
        
        public Position Position { get; set; }
        
        public ICollection<Trip> TripsOperator { get; set; }
        public ICollection<Trip> TripsDriver { get; set; }
    }
}
