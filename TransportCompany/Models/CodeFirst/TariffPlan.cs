using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompany.Models.CodeFirst
{
    public class TariffPlan
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string NamePlan { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public double CostPlan { get; set; }

        public ICollection<Trip> Trips { get; set; }
    }
}
