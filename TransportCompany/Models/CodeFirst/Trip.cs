using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompany.Models.CodeFirst
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateTimeTrip { get; set; }


        [MaxLength(12)]
        public string Telephone { get; set; }

        [MaxLength(25)]
        public string DeparturePoint { get; set; }

        [MaxLength(25)]
        public string DestinationPoint { get; set; }

        public int TariffPlanId { get; set; }

        public int CarId { get; set; }

        public int OperatorId { get; set; }

        public int DriverId { get; set; }

        public Staff Operator { get; set; }

        public Staff Driver { get; set; }

        public Car Car { get; set; }

        public TariffPlan Tariff { get; set; }
    }
}
