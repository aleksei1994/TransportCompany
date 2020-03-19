using System;
using System.ComponentModel.DataAnnotations;

namespace TransportCompany.Models.CodeFirst
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Требуется: Дата и время рейса")]
        [Display(Name = "Дата и время рейса")]
        public DateTime DateTimeTrip { get; set; }

        [Required(ErrorMessage = "Требуется: Телефон")]
        [Range(375250000000, 375449999999, ErrorMessage = "Неккоректный телефон")]
        [MaxLength(12)]
        [Display(Name = "Телефон")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Требуется: Пункт отправки")]
        [MaxLength(25)]
        [Display(Name = "Пункт отправки")]
        public string DeparturePoint { get; set; }

        [Required(ErrorMessage = "Требуется: Пункт назначения")]
        [MaxLength(25)]
        [Display(Name = "Пункт назначения")]
        public string DestinationPoint { get; set; }

        [Display(Name = "Тариф")]
        public int TariffPlanId { get; set; }

        [Display(Name = "Автомобиль")]
        public int CarId { get; set; }

        [Display(Name = "Оператор")]
        public int OperatorId { get; set; }

        [Display(Name = "Водитель")]
        public int DriverId { get; set; }

        public Staff Operator { get; set; }

        public Staff Driver { get; set; }

        public Car Car { get; set; }

        public TariffPlan TariffPlan { get; set; }
    }
}
