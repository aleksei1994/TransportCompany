using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransportCompany.Models.CodeFirst
{
    public class TariffPlan
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Требуется: Название тарифа")]
        [MaxLength(50)]
        [Display(Name = "Название тарифа")]
        public string TitlePlan { get; set; }

        [Required(ErrorMessage = "Требуется: Описание тарифа")]
        [MaxLength(50)]
        [Display(Name = "Описание тарифа")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Требуется: Стоимость тарифа")]
        [Range(0, double.MaxValue, ErrorMessage = "Неккоретная стоимость")]
        [Display(Name = "Стоимость тарифа")]
        public double CostPlan { get; set; }

        public ICollection<Trip> Trips { get; set; }
    }
}
