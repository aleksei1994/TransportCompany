using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompany.Models.CodeFirst
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        public string RegistrationNumber { get; set; }

        [MaxLength(20)]
        public string BodyNumber { get; set; }

        [MaxLength(20)]
        public string EngineNumber { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime YearCreation { get; set; }

        public double Mileage { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime LastMaintenanceDate { get; set; }

        public int CarModelId { get; set; }

        public CarModel CarModel { get; set; }

        public ICollection<Trip> Trips { get; set; }
    }
}
