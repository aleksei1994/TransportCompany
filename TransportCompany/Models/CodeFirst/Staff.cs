using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransportCompany.Models.CodeFirst
{
    public class Staff
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Требуется: ФИО")]
        [MaxLength(50)]
        [Display(Name = "ФИО сотрудника")]
        public string FioStaff { get; set; }

        [Required(ErrorMessage = "Требуется: Возраст")]
        [Range(18, 65, ErrorMessage = "Возраст от 18 до 65")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Требуется: Пол")]
        [MaxLength(10)]
        [Display(Name = "Пол")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Требуется: Адрес")]
        [MaxLength(50)]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Требуется: Телефон")]
        [MaxLength(12)]
        [Range(375250000000, 375449999999, ErrorMessage = "Неккоректный номер")]
        [Display(Name = "Номер телефона")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Требуется: Паспорт")]
        [MaxLength(50)]
        [Display(Name = "Паспортные данные")]
        public string Passport { get; set; }

        [Required]
        [Display(Name = "Должность")]
        public int PositionId { get; set; }

        public Position Position { get; set; }

        public ICollection<Trip> TripsOperator { get; set; }
        public ICollection<Trip> TripsDriver { get; set; }
    }
}
