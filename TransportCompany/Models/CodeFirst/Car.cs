using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportCompany.Models.CodeFirst
{
    public class Car
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Требуется: Регистрационный номер")]
        [MaxLength(10)]
        [Display(Name = "Регистрационный номер")]
        public string RegistrationNumber { get; set; }

        [Required(ErrorMessage = "Требуется: Номер гузова")]
        [MaxLength(20)]
        [Display(Name = "Номер гузова")]
        public string BodyNumber { get; set; }

        [Required(ErrorMessage = "Требуется: Номер двигателя")]
        [MaxLength(20)]
        [Display(Name = "Номер двигателя")]
        public string EngineNumber { get; set; }

        [Required(ErrorMessage = "Треюбуется: Дата выпуска")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата выпуска")]
        public DateTime YearCreation { get; set; }

        [Required(ErrorMessage = "Требуется: Пробег")]
        [Range(0, double.MaxValue, ErrorMessage = "Неккоректный пробег")]
        [Display(Name = "Пробег")]
        public double Mileage { get; set; }

        [Required(ErrorMessage = "Требуется: Дата последнего ТО")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата последнего ТО")]
        public DateTime LastMaintenanceDate { get; set; }

        [Display(Name = "Модель машины")]
        public int CarModelId { get; set; }

        public CarModel CarModel { get; set; }

        public ICollection<Trip> Trips { get; set; }
    }
}
