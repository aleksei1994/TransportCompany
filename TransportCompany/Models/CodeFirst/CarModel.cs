using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompany.Models.CodeFirst
{
    public class CarModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string NameModel { get; set; }

        [MaxLength(50)]
        public string Specifications { get; set; }

        public double CostModel { get; set; }
        
        [MaxLength(50)]
        public string Specificity { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
