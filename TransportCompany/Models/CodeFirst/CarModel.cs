using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransportCompany.Models.CodeFirst
{
    public class CarModel
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Требуется: Модель")]
        [MaxLength(50)]
        [Display(Name = "Модель автомобиля")]
        public string NameModel { get; set; }

        [Required(ErrorMessage = "Требуется: Спецификация")]
        [MaxLength(50)]
        [Display(Name = "Спецификация")]
        public string Specifications { get; set; }

        [Required(ErrorMessage = "Требуется: Стоимость")]
        [Range(0, double.MaxValue, ErrorMessage = "Неккоректный ввод")]
        [Display(Name = "Стоимость")]
        public double CostModel { get; set; }

        [Required(ErrorMessage = "Требуется: Специфика")]
        [MaxLength(50)]
        [Display(Name = "Специфика")]
        public string Specificity { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
