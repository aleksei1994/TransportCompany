using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransportCompany.Models.CodeFirst
{
    public class Position
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Требуется: Название должости")]
        [MaxLength(100)]
        [Display(Name = "Название должности")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Требуется: Оплата")]
        [Range(0, int.MaxValue, ErrorMessage = "Оклад не может быть отрицательным")]
        [Display(Name = "Оклад")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Требуется: Обязанности")]
        [Display(Name = "Обязанности")]
        public string Responsibilities { get; set; }

        [Required(ErrorMessage = "Требуется: Требования")]
        [Display(Name = "Требования")]
        public string Requirements { get; set; }

        public ICollection<Staff> Staffs { get; set; }
    }
}
