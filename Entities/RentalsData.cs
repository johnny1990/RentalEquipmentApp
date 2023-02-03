using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class RentalsData
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Rental Id")]
        public int RentalId { get; set; }
        public Rentals Rentals { get; set; }

        public string Nrc { get; set; }

        [Display(Name = "Equipment")]
        public int EquipmentId { get; set; }
        public Equipments Equipments { get; set; }

        [Display(Name = "Days number")]
        public int NrDays { get; set; }

        [Display(Name = "Price per day")]
        public decimal Price { get; set; }
    }
}
